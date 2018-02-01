using System;
using System.ComponentModel.DataAnnotations;

namespace MyNote.MVC.Models.VM
{
    public class CreateProject
    {
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
    }
}