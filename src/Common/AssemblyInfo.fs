namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("DynamicsCRMProvider")>]
[<assembly: AssemblyProductAttribute("DynamicsCRMProvider")>]
[<assembly: AssemblyDescriptionAttribute("A type provider for Microsoft Dynamics CRM 2011.")>]
[<assembly: AssemblyVersionAttribute("0.2.1")>]
[<assembly: AssemblyFileVersionAttribute("0.2.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.2.1"
