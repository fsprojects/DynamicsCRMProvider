(*** hide ***)
#I "../../bin"
#r "FSharp.Data.DynamicsCRMProvider.dll"

(**
Getting started with the DynamicsCRMProvider
============================================

Open Visual Studio 2013 and create a new F# Console application. Right-click on the project and select "Manage NuGet Packages".
Make sure the "Include Prerelease" is selected and search for "[DynamicsCRMProvider](https://nuget.org/packages/DynamicsCRMProvider)" and press "Install":

![alt text](img/NuGet.png "Install the Dynamics CRM type provider")

You also need to add a reference to "System.Data.dll" to your project.

Now you can go to the "Program.fs" file and start using the type provider:

*)

open System
open System.Linq
open FSharp.Data

// configure the Dynamics CRM type provider with a connection string to the db
type CRM = DynamicsCRM<"Data Source=OMEGA;Initial Catalog=Dev;Integrated Security=True",
                           Company="CRONUS International Ltd.">
let db = CRM.GetDataContext()

[<EntryPoint>]
let main argv = 
    // print all sales headers
    for sh in db.``Sales Header`` do
        printfn "%s %s" sh.``Sell-to Customer No.`` sh.``Salesperson Code``

    Console.ReadKey() |> ignore
    0 // exit code

(**
Press F5 to run the project.
*)