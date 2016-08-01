using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpingHand.Models
{
    public class OrderModels
    {
        [Key]
        public int ID { get; set; }
        public CustomerModels CustomerID { get; set; }
        public DriverModels DriverID { get; set; }
        public string status { get; set; }
        public DriverModels startLocation { get; set; }
        public CustomerModels DestLocation { get; set; }
        public float payment { get; set; }
        public float fee { get; set; }
        public string orderDetails { get; set; }
        public DateTime timeFrame { get; set; }
    }
}