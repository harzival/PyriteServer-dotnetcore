// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="QueryController.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Xna.Framework;
    using UniscanServer.Contracts;

    public class QueryController : ControllerBase
    {
        [HttpGet]
        [Route("sets/{setid}/{versionId}/query/{detail}/{ax},{ay},{az}/{bx},{by},{bz}")]
        public IActionResult BoundingBoxQuery(string setId, string versionId, string detail, float ax, float ay, float az, float bx, float by, float bz)
        {
            try
            {
                IEnumerable<int[]> result = Dependency.Storage.Query(
                    setId,
                    versionId,
                    detail,
                    new BoundingBox(new Vector3(ax, ay, az), new Vector3(bx, @by, bz)));
                return this.Ok(ResultWrapper.OkResult(result));
            }
            catch (NotFoundException ex)
            {
                Trace.WriteLine(ex, "QueryController::Get");
                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("sets/{setid}/{versionId}/query/{profile}/{ax},{ay},{az}/{radius}")]
        public IActionResult BoundingBoxSphere(string setId, string versionId, string profile, float ax, float ay, float az, float radius)
        {
            try
            {
                IEnumerable<QueryDetailContract> result = Dependency.Storage.Query(
                    setId,
                    versionId,
                    profile,
                    new BoundingSphere(new Vector3(ax, ay, az), radius));
                return this.Ok(ResultWrapper.OkResult(result));
            }
            catch (NotFoundException ex)
            {
                Trace.WriteLine(ex, "QueryController::Get");
                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("sets/{setid}/{versionId}/query/3x3/{reference}/{ax},{ay},{az}")]
        public IActionResult BoundingBoxSphere(string setId, string versionId, string reference, float ax, float ay, float az)
        {
            try
            {
                IEnumerable<QueryDetailContract> result = Dependency.Storage.Query(
                    setId,
                    versionId,
                    reference,
                    new Vector3(ax, ay, az));
                return this.Ok(ResultWrapper.OkResult(result));
            }
            catch (NotFoundException ex)
            {
                Trace.WriteLine(ex, "QueryController::Get");
                return this.NotFound();
            }
        }
    }
}