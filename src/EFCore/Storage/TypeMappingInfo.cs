// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.EntityFrameworkCore.Storage
{
    /// <summary>
    ///     Describes metadata needed to decide on a type mapping for a property or type.
    /// </summary>
    public class TypeMappingInfo
    {
        /// <summary>
        ///     Creates a new instance of <see cref="TypeMappingInfo" />.
        /// </summary>
        /// <param name="property"> The property for which mapping is needed. </param>
        /// <param name="modelClrType"> The CLR type in the model for which mapping is needed. </param>
        public TypeMappingInfo(
            [CanBeNull] IProperty property = null,
            [CanBeNull] Type modelClrType = null)
        {
            Property = property;
            ModelClrType = modelClrType ?? property?.ClrType;
        }

        /// <summary>
        ///     The property for which mapping is needed.
        /// </summary>
        public virtual IProperty Property { get; }

        /// <summary>
        ///     The CLR type in the model for which mapping is needed.
        /// </summary>
        public virtual Type ModelClrType { get; }
    }
}
