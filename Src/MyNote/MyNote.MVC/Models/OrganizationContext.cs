using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyNote.MVC.Models.DTO;


namespace MyNote.MVC.Models
{
    public class OrganizationContext
    {
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> TeamsOwnership { get; set; }
        public List<Guid> ProjectsOwnership { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<AvailableTeam> AvaliableTeams { get; set; }
        public List<AvailableProject> AvailableProjects { get; set; }
        public MultiSelectList AvaliableTeamsList { get; set; }
        public MultiSelectList AvaliableProjectsList { get; set; }
        public OrganizationContext()
        {

            AvaliableTeamsList = new MultiSelectList(GetEmptyList(), "Value", "Text");
            AvaliableProjectsList = new MultiSelectList(GetEmptyList(), "Value", "Text");
        }

        public void AddAvailableTeamsList()
        {
            var items = GetEmptyList();
            AvaliableTeams?.ForEach(x => items.Add(new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));

            this.AvaliableTeamsList = new MultiSelectList(items.OrderBy(x => x.Text), "Value", "Text");
        }

        public void AddAvailableProjects()
        {
            var items = GetEmptyList();
            AvailableProjects?.ForEach(x => items.Add(new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }));
            this.AvaliableProjectsList = new MultiSelectList(items.OrderBy(x => x.Text), "Value", "Text");
        }

        private List<SelectListItem> GetEmptyList()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem()
            {
                Text = "",
                Value = ""
            });
            return items;
        }
    }
}