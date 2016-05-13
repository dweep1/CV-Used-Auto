using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;
using System.Data;

namespace RestServiceStackTemplate
{
    
    public class Authenticate : Service
    {
        public User_Token Any(UserRequest request)
        {

            User_Token token = new User_Token();
            token.auth_token = "";

            SqlDatabase sqlCall = new SqlDatabase();
            sqlCall.AddParameter("@username", request.username);
            sqlCall.AddParameter("@password", request.password);

            DataTable results = sqlCall.Fill("prc_Check_User");

            if (results.Rows.Count > 0){
                token.auth_token = results.Rows[0][0].ToString();
            }

            return token;
        }

        public Status Any(GenRequest request)
        {
        try
            {
                SqlDatabase sq = new SqlDatabase();
                sq.AddParameter("@username", request.username);
                sq.AddParameter("@password", request.password);
                sq.AddParameter("@address", request.address);
                sq.AddParameter("@city", request.city);
                sq.AddParameter("@state", request.state);
                sq.AddParameter("@zipcode", request.zipcode);
                sq.ExecuteNonQuery("StoreUserData");
                return new Status()
                {
                    success = true
                };
            }catch
            {
                return new Status()
                {
                    success = false
                };
            }
        }
        public Inventory Any(EmptyRequest request)
        {
            Inventory inventory = new Inventory();
            inventory.success = true;
            SqlDatabase sq = new SqlDatabase();
           DataTable table =  sq.Fill("GetInventory");
            List < Item > items = new List<Item>();
            foreach(DataRow dr in table.Rows)
            {
                items.Add(new Item()
                {
                    make    = dr["make"].ToString(),
                     model  = dr["model"].ToString(),
                    color   = dr["color"].ToString(),
                    trans   = dr["trans"].ToString(),
                    drive    = dr["drive"].ToString(),
                    miles    = dr["miles"].ToString(),
                    price   = dr["price"].ToString(),
                    car_year = dr["car_year"].ToString(),
                    vin      = dr["vin"].ToString()
                    
                });
            }
            inventory.Table = items;
            return inventory;
        }

        public Status Any(ContactRequest request)
        {
            SqlDatabase sb = new SqlDatabase();
            sb.AddParameter("@firstname", request.FirstName);
            sb.AddParameter("@lastname", request.LastName);
            sb.AddParameter("@emailaddress", request.EmailAddress);
            sb.AddParameter("@mess", request.Message);
            sb.ExecuteNonQuery("StoreContact");
            return new Status()
            {
                success = true
            };
        }
    }

}
