using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpingHand.Models
{
    public class DriverModels
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string UserID { get; set; }
        public int geoTag { get; set; }
        public int rating { get; set; }
        public string status { get; set; }
        public int rangePreference { get; set; }
        public DateTime registrationDate { get; set; }
    }
}