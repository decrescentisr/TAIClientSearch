using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TAIClientSearch.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        //Form validation for required field
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        //Form validation for required field
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }

        //Form validation for required field
        [Required]
        [StringLength(6, MinimumLength = 1)]
        public string Gender { get; set; }

        //Form validation for required field
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        //Form validation for required field
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Company { get; set; }

        //Form validation for required field
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string PolicyNumber { get; set; }

        //Form validation for required field
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string IssueState { get; set; }

        //Form validation for required field
        [Required]
        [DataType(DataType.Currency)]
        public string FaceAmount { get; set; }
    }

    public class ClientDBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}