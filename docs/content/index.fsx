(*** hide ***)
#I "../../bin"

(**
DynamicsNAVProvider
===================

The DynamicsNAVProvider is a [F# type provider](http://msdn.microsoft.com/en-us/library/hh156509.aspx) which allows to access [Microsoft Dynamics NAV](http://www.microsoft.com/en-us/dynamics/erp-nav-overview.aspx) data from a SQL Server in a strongly typed way.
It aims to be a replacement for data access technologies like C/Front.NET but with a much easier API.

It's supporting LINQ queries, schema exploration and much more besides.

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The library can be <a href="https://nuget.org/packages/DynamicsNAVProvider">installed from NuGet</a>:
      <pre>PM> Install-Package DynamicsNAVProvider -prerelease</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>

If you are new to type providers you should read the ["Getting started" article](gettingstarted.html).

Example
-------

This example demonstrates the use of the type provider from a F# script file:

*)
// reference the type provider dll
#r "FSharp.Data.DynamicsNAVProvider.dll"
open System
open System.Linq
open FSharp.Data

// configure the Dynamics NAV type provider with a connection string to the db
// and set the company
type NAV = DynamicsNAV<"Data Source=OMEGA;Initial Catalog=Dev;Integrated Security=True",
                           Company="CRONUS International Ltd.">
let db = NAV.GetDataContext()

// now you have typed access to the whole Dynamics NAV database

// print all sales headers
for sh in db.``Sales Header`` do
    printfn "%s %s" sh.``Sell-to Customer No.`` sh.``Salesperson Code``

(**

You will even get Intellisense for all of this:

![alt text](img/TypedDynamicsNAV.png "Intellisense for Dynamics NAV")

Queries
-------

It's possible to perform LINQ queries against the Dynamics NAV database. These queries are transformed into SQL and run on the SQL Server:

*)

// select the customer name, the sales header no. and currency for all sales headers where the customer is named "Steffen"
query{ for cus in db.Customer do
       join sh in db.``Sales Header`` on (cus.``No.`` = sh.``Sell-to Customer No.``)
       where (cus.Name.StartsWith "Steffen") 
       select (cus.Name,sh.``No.``,sh.``Currency Code``) } 
  |> Seq.toArray

(**

More about queries can be found in the [Query article](queries.html).


Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read [library design notes][readme] to understand how it works.

The library is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: https://github.com/fsprojects/DynamicsNAVProvider/tree/master/docs/content
  [gh]: https://github.com/fsprojects/DynamicsNAVProvider
  [issues]: https://github.com/fsprojects/DynamicsNAVProvider/issues
  [readme]: https://github.com/fsprojects/DynamicsNAVProvider/blob/master/README.md
  [license]: https://github.com/fsprojects/DynamicsNAVProvider/blob/master/LICENSE.md
*)
