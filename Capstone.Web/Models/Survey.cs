using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Survey
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ParkCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }
    }
}