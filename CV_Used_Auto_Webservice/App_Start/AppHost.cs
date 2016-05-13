using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;

[assembly: WebActivator.PreApplicationStartMethod(typeof(RestServiceStackTemplate.App_Start.AppHost), "Start")]

namespace RestServiceStackTemplate.App_Start
{
	public class AppHost
		: AppHostBase
	{		
		public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("CV Used Auto Service", typeof(Authenticate).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            //Configure User Defined REST Paths
            Routes.Add<UserRequest>("/CheckUser", "POST")
                .Add<GenRequest>("/CreateUser", "POST")
                .Add<EmptyRequest>("/GetInventory", "GET")
                .Add<ContactRequest>("/StoreContact", "POST");
           

            
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}
