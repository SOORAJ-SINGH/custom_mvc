using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CustomizationMvc.Customs
{
    public class CustomModule : IHttpModule
    {

        private StreamWriter sw;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }







        private void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!File.Exists("logger.txt"))
            {
                sw = new StreamWriter(@"c:\users\sooraj\documents\visual studio 2015\Projects\CustomizationMvc\CustomizationMvc\logger.txt");
            }
            else
            {
                sw = File.AppendText("logger.txt");
            }

            sw.WriteLine("user sends request at {0}",DateTime.Now);
            sw.Flush();
            sw.Close();
        }
    }
}