﻿using System.Reflection;

namespace Mbc.Ads.Mapper
{
    /// <summary>
    /// Provides information about the destination member.
    /// </summary>
    internal interface IDestinationMemberConfiguration
    {
        /// <summary>
        /// Gets the reflection member of the destination type.
        /// </summary>
        MemberInfo Member { get; }

        /// <summary>
        /// Gets a value indicating if this member is required for mapping.
        /// </summary>
        bool IsRequired { get; }

        /// <summary>
        /// Gets a value indiciatng if a custom convertion is configured.
        /// </summary>
        bool HasConvertion { get; }

        /// <summary>
        /// Converts a source value to the destination value
        /// </summary>
        /// <param name="value">the source value</param>
        /// <returns>the converted destination value</returns>
        object Convert(object value);
    }
}
