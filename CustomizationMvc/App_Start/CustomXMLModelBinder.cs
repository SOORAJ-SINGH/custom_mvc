using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace CustomizationMvc.App_Start
{
    public class CustomXMLModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                //find the modelType  i.e Employee
                var model = bindingContext.ModelType;

                //create the searializer based on the model
                var data = new XmlSerializer(model);

                //get the xml data from inputStream
                var receivedStream = controllerContext.HttpContext.Request.InputStream;

                //return deserialized receivedStream
                return data.Deserialize(receivedStream);
            }
            catch (Exception ex)
            {

                bindingContext.ModelState.AddModelError("Error", "Received Model cannot be serialized");
                return null;
            }

        }


    }
}