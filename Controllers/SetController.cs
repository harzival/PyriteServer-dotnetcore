// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="SetController.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using UniscanServer.Contracts;
    using UniscanServer.DataAccess.Json;

    public class SetController : ControllerBase
    {
        [HttpGet]
        [Route("sets/{setid}")]
        [CacheControl(15)]
        public IActionResult Get(string setid)
        {
            try
            {
                IOrderedEnumerable<VersionResultContract> result = Dependency.Storage.EnumerateSetVersions(setid).OrderBy(version => version.Name);
                return this.Ok(ResultWrapper.OkResult(result));
            }
            catch (NotFoundException ex)
            {
                Trace.WriteLine(ex, "SetController::Get");
                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("sets")]
        [CacheControl(15)]
        public IActionResult GetAll()
        {
            IOrderedEnumerable<SetResultContract> result = Dependency.Storage.EnumerateSets().OrderBy(set => set.Name);
            return this.Ok(ResultWrapper.OkResult(result));
        }
    }
}