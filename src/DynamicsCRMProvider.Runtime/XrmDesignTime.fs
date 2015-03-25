// Copyright (c) Microsoft Corporation 2005-2013.
// This sample code is provided "as is" without warranty of any kind. 
// We disclaim all warranties, either express or implied, including the 
// warranties of merchantability and fitness for a particular purpose.

namespace FSharp.Data.TypeProviders.XrmProvider

open System.Reflection
open Microsoft.FSharp.Core.CompilerServices

open Microsoft.Xrm.Sdk.Metadata

/// Determines how relationship names appear on generated types
type RelationshipNamingType =
    /// Relationships will be named with their schema name prefixed by 'Children of' or 'Parent of' and suffixed with the returned entity type name.
    | ParentChildPrefix = 0
    /// Relationships will be named with their schema name prefixed by 1:N, N:1 or N:N.
    | CrmStylePrefix = 1
    /// Relationships will be named only with their schema name.  You will need to examine the intelliense comments to determine which direction the relationships point.                         
    | SchemaNameOnly = 2

type OptionSetEnum  =
    | Unused = 2147483647