using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity_Layer
{
    public class Payments
    {

        public String Job_Name { get; set; }
        public decimal Payment_Amount { get; set; }
        public DateTime End_Date { get; set; }

    }
}