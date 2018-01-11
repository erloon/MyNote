using System;
using System.Linq;
using Autofac;
using Marten;
using Marten.Events;
using Microsoft.Extensions.Configuration;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.API.Infrastructure
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

                    //options.CreateDatabasesForTenants(o =>
                    //{
                    //    o.MaintenanceDatabase(_configurationSection.GetValue<string>("ConnectionString"));
                    //    o.ForTenant()
                    //        .CheckAgainstPgDatabase()
                    //        .WithOwner("erloon")
                    //        .WithEncoding("UTF-8")
                    //        .ConnectionLimit(-1);

                    //});
                    options.Connection(_configurationSection.GetValue<string>("ConnectionString"));
                    options.AutoCreateSchemaObjects = AutoCreate.All;
                    options.Events.DatabaseSchemaName = schemaName;
                    options.DatabaseSchemaName = schemaName;
                    options.Events.InlineProjections.AggregateStreamsWith<Note>();

                    //AddEventTypes(options.Events);
                });

                return documentStore.OpenSession();
            }).SingleInstance();

            base.Load(builder);
        }

        //private void AddEventTypes(EventGraph optionsEvents)
        //{
        //    var type = typeof(IDomainEvent);
        //    var types = AppDomain.CurrentDomain.GetAssemblies()
        //        .SelectMany(s => s.GetTypes())
        //        .Where(p => type.IsAssignableFrom(p));

        //    optionsEvents.AddEventTypes(types);
        //}
    }
}