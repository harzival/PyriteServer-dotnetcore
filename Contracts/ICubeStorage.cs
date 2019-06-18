﻿// // //------------------------------------------------------------------------------------------------- 
// // // <copyright file="ICubeStorage.cs" company="Microsoft Corporation">
// // // Copyright (c) Microsoft Corporation. All rights reserved.
// // // </copyright>
// // //-------------------------------------------------------------------------------------------------

namespace UniscanServer.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using UniscanServer.DataAccess.Json;

    public interface ICubeStorage
    {
        IEnumerable<SetResultContract> EnumerateSets();

        IEnumerable<VersionResultContract> EnumerateSetVersions(string setId);

        SetVersionResultContract GetSetVersion(string setId, string version);

        Task<StorageStream> GetTextureStream(string setId, string version, string detail, string xpos, string ypos);

        Task<StorageStream> GetModelStream(string setId, string version, string detail, string xpos, string ypos, string zpos, string format);

        IEnumerable<int[]> Query(string setId, string versionId, string detail, BoundingBox worldBox);

        IEnumerable<QueryDetailContract> Query(string setId, string versionId, string detailProfile, BoundingSphere worldBox);

        /// <summary>3x3 cube query at all detail levels</summary>
        /// <param name="setId"></param>
        /// <param name="versionId"></param>
        /// <param name="boundaryReference"></param>
        /// <param name="worldCenter"></param>
        /// <returns></returns>
        IEnumerable<QueryDetailContract> Query(string setId, string versionId, string boundaryReference, Vector3 worldCenter);
    }
}