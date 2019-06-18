// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="VersionController.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using UniscanServer.Contracts;

    public class VersionController : ControllerBase
    {
        [HttpGet]
        [Route("sets/{setid}/{versionid}")]
        [CacheControl(15)]
        public IActionResult Get(string setid, string versionid)
        {
            try
            {
                SetVersionResultContract result = Dependency.Storage.GetSetVersion(setid, versionid);
                return this.Ok(ResultWrapper.OkResult(result));
            }
            catch (NotFoundException ex)
            {
                Trace.WriteLine(ex, "SetController::Get");
                return this.NotFound();
            }
        }
    }
}