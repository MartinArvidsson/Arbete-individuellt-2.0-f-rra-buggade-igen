using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IndividuelltProjekt.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("StartPerson", "Start/Person/PersonReg", "~/Ticketregpages/RegPerson.aspx");

            routes.MapPageRoute("Person", "Start/Person/PersonReg/{id}", "~/Ticketregpages/ChooseTicket.aspx");

            routes.MapPageRoute("Biljett", "Start/Person/BiljettReg/{id}/{id2}", "~/Ticketregpages/ChooseTicket.aspx");

            routes.MapPageRoute("FinishReg", "Finishreg/{id}/{id2}", "~/Ticketregpages/FinishReg.aspx");
            
            routes.MapPageRoute("Start", "", "~/Ticketregpages/Start.aspx");            
        }
    }
}