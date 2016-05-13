using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RestServiceStackTemplate
{
    
  
    public class User_Token
    {
        public string auth_token { get; set; }
    }
    public class Status
    {
        public bool success { get; set; }
    }

    public class Inventory
    {
        public List<Item> Table { get; set; }

        public bool success { get; set; }
    }
    public class Item
    {
        public String make { get; set; }
        public String model { get; set; }
        public String color { get; set; }
        public String trans { get; set; }
        public String drive { get; set; }
        public String miles { get; set; }
        public String price { get; set; }

        public String car_year { get; set; }

        public String vin { get; set; }
    }
}