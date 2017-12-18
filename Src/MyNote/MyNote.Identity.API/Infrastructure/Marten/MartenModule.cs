using System;
using Autofac;
using IdentityServer4.Extensions;
using Marten;
using Microsoft.Extensions.Configuration;
using MyNote.Identity.Domain.Events.User;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.API.Infrastructure.Marten
{
    public class MartenModule : Module
    {
        private readonly IConfigurationSection _configurationSection;


        public MartenModule(IConfigurationSection configurationSection)
        {
            if (configurationSection == null) throw new ArgumentNullException(nameof(configurationSection));
            _configurationSection = configurationSection;

        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IDocumentSession>((c, p) =>
            {
                var documentStore = DocumentStore.For(options =>
                {
                    var schemaName = _configurationSection.GetValue<string>("ShemaName");

                    options.Connection(_configurationSection.GetValue<string>("ConnectionString"));
                    options.AutoCreateSchemaObjects = AutoCreate.All;
                    options.Events.DatabaseSchemaName = schemaName;
                    options.DatabaseSchemaName = schemaName;

                    options.Events.InlineProjections.AggregateStreamsWith<Organization>();

                    options.Events.AddEventType(typeof(UserCreated));
                });

                return documentStore.OpenSession();
            }).SingleInstance();

            base.Load(builder);
        }
    }
}