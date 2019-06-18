// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="CacheHeaderActionFilter.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer
{
    using System;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class CacheControlAttribute : ActionFilterAttribute
    {
        private readonly uint maxAge;

        public CacheControlAttribute(uint maxAgeMinutes)
        {
            this.maxAge = maxAgeMinutes;
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.HttpContext.Response == null || actionExecutedContext.HttpContext.Response.StatusCode != 200)
            {
                return;
            }

            actionExecutedContext.HttpContext.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl]
             = "public, max-age=" + TimeSpan.FromMinutes(this.maxAge).ToString();
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}