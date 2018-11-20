﻿//-----------------------------------------------------------------------------
// Copyright (c) 2018 by mbc engineering GmbH, CH-6015 Luzern
// Licensed under the Apache License, Version 2.0
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using TwinCAT.Ads;
using TwinCAT.TypeSystem;

namespace Mbc.Pcs.Net.Command
{
    /// <summary>
    /// Base class for handler reading or writing arguments of commands.
    /// </summary>
    public abstract class CommandArgumentHandler
    {
        public abstract void WriteInputData(IAdsConnection adsConnection, string adsCommandFbPath, ICommandInput input);

        public abstract void ReadOutputData(IAdsConnection adsConnection, string adsCommandFbPath, ICommandOutput output);

        /// <summary>
        /// Reads all symbols in the same hierarchy as the function block they are flaged with the Attribute
        /// named in <para>attributeName</para>.
        /// </summary>
        protected static IDictionary<string, ITcAdsSubItem> ReadFbSymbols(IAdsConnection adsConnection, string adsCommandFbPath, string attributeName)
        {
            ITcAdsSymbol commandSymbol = adsConnection.ReadSymbolInfo(adsCommandFbPath);
            if (commandSymbol == null)
            {
                // command Symbol not found
                throw new PlcCommandException(adsCommandFbPath, string.Format(CommandResources.ERR_CommandNotFound, adsCommandFbPath));
            }

            var validTypeCategories = new[] { DataTypeCategory.Primitive, DataTypeCategory.Enum, DataTypeCategory.String };

            return ((ITcAdsSymbol5)commandSymbol)
                .DataType.SubItems
                .Where(item => item.Attributes.Any(a => string.Equals(a.Name, attributeName, StringComparison.OrdinalIgnoreCase)))
                .ToDictionary(
                    item => item.SubItemName,
                    item => item);
        }
    }
}
