﻿using System.Web;
using System.Web.Mvc;

namespace Kazan_Session5_API_21_9
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
