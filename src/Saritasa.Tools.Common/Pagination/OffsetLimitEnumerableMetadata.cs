﻿// Copyright (c) 2015-2017, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

namespace Saritasa.Tools.Common.Pagination
{
    /// <summary>
    /// Offset limit metadata.
    /// </summary>
#if !NETCOREAPP1_0 && !NETCOREAPP1_1 && !NETSTANDARD1_2 && !NETSTANDARD1_6
    [Serializable]
#endif
    public class OffsetLimitEnumerableMetadata : TotalCountEnumerableMetadata
    {
        /// <summary>
        /// Zero based offset of current page.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Count of returned items.
        /// </summary>
        public int Limit { get; set; }
    }
}