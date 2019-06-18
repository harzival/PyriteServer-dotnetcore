﻿// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="SetContract.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.DataAccess.Json
{
    using Newtonsoft.Json;

    public class SetContract
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("versions")]
        public SetVersionContract[] Versions { get; set; }
    }
}