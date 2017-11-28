// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Microsoft.EntityFrameworkCore.Storage
{
    /// <summary>
    ///     Describes metadata needed to decide on a relational type mapping for
    ///     a property, type, or provider-specific relational type name.
    /// </summary>
    public class RelationalTypeMappingInfo : TypeMappingInfo
    {
        /// <summary>
        ///     Creates a new instance of <see cref="RelationalTypeMappingInfo" />.
        /// </summary>
        /// <param name="property"> The property for which mapping is needed. </param>
        /// <param name="modelClrType"> The CLR type in the model for which mapping is needed. </param>
        /// <param name="storeTypeName"> The provider-specific relational type name for which mapping is needed. </param>
        public RelationalTypeMappingInfo(
            [CanBeNull] IProperty property = null,
            [CanBeNull] Type modelClrType = null,
            [CanBeNull] string storeTypeName = null)
            : base(property, modelClrType)
        {
            storeTypeName = storeTypeName ?? GetColumnType(property);

            if (storeTypeName == null)
            {
                var principalProperty = property?.FindPrincipal();
                if (principalProperty != null)
                {
                    storeTypeName = GetColumnType(principalProperty);
                }
            }

            StoreTypeName = storeTypeName;
        }

        private static string GetColumnType(IProperty property)
            => (string)property?[RelationalAnnotationNames.ColumnType];

        /// <summary>
        ///     The provider-specific relational type name for which mapping is needed.
        /// </summary>
        public virtual string StoreTypeName { get; }
    }
}
