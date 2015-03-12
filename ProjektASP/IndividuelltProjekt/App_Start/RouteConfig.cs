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
            routes.MapPageRoute("Person", "Start/Person/PersonReg/Person{id}", "~/Ticketregpages/ChooseTicket.aspx");

            routes.MapPageRoute("Biljett", "Start/Person/BiljettReg/Person{id}/Biljett{id2}", "~/Ticketregpages/ChooseTicket.aspx");

            routes.MapPageRoute("Start", "Start/", "~/Ticketregpages/Start.aspx");
        }
    }
}