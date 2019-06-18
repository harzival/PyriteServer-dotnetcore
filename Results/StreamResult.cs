// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="StreamResult.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Results
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using UniscanServer.Contracts;

    public class StreamResult : IActionResult
    {
        private readonly HttpRequest _request;
        private readonly StorageStream _storageStream;

        public StreamResult(StorageStream storageStream, HttpRequest request)
        {
            this._storageStream = storageStream;
            this._request = request;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = new ObjectResult(this._storageStream.Stream) {
                StatusCode = StatusCodes.Status200OK,
            };
            context.HttpContext.Response.ContentType = this._storageStream.TypeHeaderValue.ToString();
            context.HttpContext.Response.ContentLength = this._storageStream.Length;

            await response.ExecuteResultAsync(context);
        }
    }
}