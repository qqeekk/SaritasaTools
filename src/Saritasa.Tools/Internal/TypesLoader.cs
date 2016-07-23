﻿// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Saritasa.Tools.Internal
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Load types from assemblies. Also allows to load standard .NET types.
    /// </summary>
    public static class TypesLoader
    {
        /// <summary>
        /// Load type from type full name. Searchs for assemblies.
        /// </summary>
        /// <param name="fullName">Full type name.</param>
        /// <param name="assemblies">Assebmlies list.</param>
        /// <returns>Type. Null if type cannot be found.</returns>
        public static Type LoadType(string fullName, Assembly[] assemblies)
        {
            Type t = null;

            // if it is a system type try to use Type.GetType first
            if (fullName.StartsWith("System"))
            {
                Type.GetType(fullName, false, true);
                if (t != null)
                {
                    return t;
                }
            }

            // then try to load from assemblies
            for (int i = 0; i < assemblies.Length; i++)
            {
                var assembly = assemblies[i];
                t = assembly.GetType(fullName, false, true);
                if (t != null)
                {
                    return t;
                }
            }

            // last chance
            Type.GetType(fullName, false, true);
            if (t != null)
            {
                return t;
            }

            return null;
        }
    }
}
