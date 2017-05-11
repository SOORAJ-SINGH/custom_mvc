﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomizationMvc.App_Start
{
    public class CustomValueProvider : IValueProvider
    {
        private readonly NameValueCollection _headers;
        private readonly string[] _headerKeys;

        public CustomValueProvider( NameValueCollection headers)
        {
            _headers = headers;
            _headerKeys = headers.AllKeys;
        }

        public bool ContainsPrefix(string prefix)
        {
            return _headerKeys.Any(h => h.Replace("-", "").Equals(prefix,StringComparison.OrdinalIgnoreCase));
        }

        public ValueProviderResult GetValue(string key)
        {
            var header = _headerKeys.FirstOrDefault(h => h.Replace("-", "").Equals(key,StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(_headers[header]))
            {
                return new ValueProviderResult(_headers[header], _headers[header],CultureInfo.CurrentCulture);
            }

            return null;
        }
    }

    public class CustomValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new CustomValueProvider(controllerContext.HttpContext.Request.Headers);
        }
    }
}