#nowarn "211"
// Standard NuGet or Paket location
#I "."
#I "lib/net40"

// Standard NuGet locations for CrmSdk
#I "../Microsoft.CrmSdk.CoreAssemblies.5.0.18/lib/net40"
#I "../Microsoft.IdentityModel.6.1.7600.16394/lib/net35"

// Standard Paket locations for CrmSdk
#I "../Microsoft.CrmSdk.CoreAssemblies/lib/net40"
#I "../Microsoft.IdentityModel/lib/net35"

// Try various folders that people might like
#I "bin"
#I "../bin"
#I "../../bin"
#I "lib"

// Reference DynamicsCRMProvider and CrmSdk
#r "System.Web.dll"
#r "System.Runtime.Serialization.dll"
#r "Microsoft.IdentityModel.dll"
#r "Microsoft.Xrm.Sdk.dll"
#r "Microsoft.Crm.Sdk.Proxy.dll"
#r "Microsoft.Crm.Services.Utility.dll"
#r "FSharp.Data.DynamicsCRMProvider.dll"
#r "FSharp.Data.DynamicsCRMProvider.Runtime.dll"