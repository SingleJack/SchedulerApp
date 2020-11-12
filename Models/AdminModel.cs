using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulerApp.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Duties { get; set; }
        [Required]
        public int Service { get; set; }
        [Required]
        public string UserID { get; set; }

        public AdminModel()
        {
            Id = -1;
            FirstName = "";
            LastName = "";
            Date = DateTime.Now;
            Duties = "";
            Service = 0;
        }

        public AdminModel(int id, string firstName, string lastName, DateTime date, string duties, int service, string userID)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Date = date;
            Duties = duties;
            Service = service;
            UserID = userID;
        }
    }
}