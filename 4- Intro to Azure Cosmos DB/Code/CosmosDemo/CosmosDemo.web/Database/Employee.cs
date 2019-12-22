using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosDemo.web.Database
{
    public class Employee
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HiringDate { get; set; }

        public string Nationality { get; set; }
    }
}
