namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("DynamicsCRMProvider")>]
[<assembly: AssemblyProductAttribute("DynamicsCRMProvider")>]
[<assembly: AssemblyDescriptionAttribute("Type providers for Dynamics CRM access.")>]
[<assembly: AssemblyVersionAttribute("0.0.1")>]
[<assembly: AssemblyFileVersionAttribute("0.0.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.0.1"
