// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="TextureController.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using UniscanServer.Contracts;
    using UniscanServer.Results;

    public class TextureController : ControllerBase
    {
        [HttpGet]
        [Route("sets/{setid}/{version}/textures/{detail}/{xpos},{ypos}")]
        [CacheControl(336 * 60)]
        public async Task<IActionResult> Get(string setid, string version, string detail, string xpos, string ypos)
        {
            try
            {
                StorageStream textureStream = await Dependency.Storage.GetTextureStream(setid, version, detail, xpos, ypos);
                return new StreamResult(textureStream, this.Request);
            }
            catch (NotFoundException)
            {
                return this.NotFound();
            }
        }
    }
}