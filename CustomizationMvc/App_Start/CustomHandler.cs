﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomizationMvc.App_Start
{
    public class CustomHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Custom Handler response!");
        }
    }
}