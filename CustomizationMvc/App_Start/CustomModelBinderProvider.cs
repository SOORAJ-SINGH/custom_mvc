using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomizationMvc.App_Start
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (HttpContext.Current.Request.ContentType.ToLower() != "text/xml")
            {
                return null;
            }
            return new CustomXMLModelBinder();
        }
    }
}