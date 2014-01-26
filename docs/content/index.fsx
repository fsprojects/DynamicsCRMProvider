(*** hide ***)
#I "../../bin"

(**
DynamicsCRMProvider
===================

The DynamicsCRMProvider is a [F# type provider](http://msdn.microsoft.com/en-us/library/hh156509.aspx) which allows to access [Microsoft Dynamics CRM](http://www.microsoft.com/en-us/dynamics/crm.aspx) data in a strongly typed way.

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The library can be <a href="https://nuget.org/packages/DynamicsCRMProvider">installed from NuGet</a>:
      <pre>PM> Install-Package DynamicsCRMProvider -prerelease</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>

You can read more about it at the [F# team blog](http://blogs.msdn.com/b/fsharpteam/archive/2013/02/14/the-f-microsoft-dynamics-crm-type-provider-sample-strongly-typed-enterprise-scale-customer-data-made-simple.aspx).

Example
-------

This example demonstrates the use of the type provider from a F# script file:

*)
// reference the type provider dll
#r "System.Runtime.Serialization"   
#r "FSharp.Data.DynamicsCRMProvider.dll"
#r @"..\lib\Microsoft.Xrm.Sdk.dll"   

open System
open System.Linq
open FSharp.Data.TypeProviders

// configure the Dynamics CRM type provider
let xrm = XrmDataProvider<"http://server/org/XRMServices/2011/Organization.svc">.GetDataContext()
let accounts = xrm.accountSet |> Seq.toList

// now you have typed access to Dynamics CRM

let accounts = 
    query { for a in xrm.accountSet do 
            where (a.name.Contains "Contoso") 
            select a } |> Seq.toList

(**

Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read [library design notes][readme] to understand how it works.

The library is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: https://github.com/fsprojects/DynamicsCRMProvider/tree/master/docs/content
  [gh]: https://github.com/fsprojects/DynamicsCRMProvider
  [issues]: https://github.com/fsprojects/DynamicsCRMProvider/issues
  [readme]: https://github.com/fsprojects/DynamicsCRMProvider/blob/master/README.md
  [license]: https://github.com/fsprojects/DynamicsCRMProvider/blob/master/LICENSE.md
*)
