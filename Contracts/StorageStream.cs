// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="StorageStream.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Contracts
{
    using System.IO;
    using Microsoft.Net.Http.Headers;

    public class StorageStream
    {
        public StorageStream(Stream stream, long contentLength, MediaTypeHeaderValue contentType)
        {
            this.Stream = stream;
            this.Length = contentLength;
            this.TypeHeaderValue = contentType;
        }

        public Stream Stream { get; private set; }
        public long Length { get; private set; }
        public MediaTypeHeaderValue TypeHeaderValue { get; private set; }
    }
}