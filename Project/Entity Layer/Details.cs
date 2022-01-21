using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity_Layer
{
    public class Details
    { 
        public String Job_Name { get; set; }
        public String Job_Type { get; set; }
        public decimal Payment_Amount { get; set; }
        public String Pay_Type { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
    }
}