﻿// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="VersionResultContract.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Contracts
{
    using Newtonsoft.Json;

    public class VersionResultContract
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}