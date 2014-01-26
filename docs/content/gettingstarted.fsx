(*** hide ***)
#I "../../bin"
#r "FSharp.Data.DynamicsNAVProvider.dll"

(**
Getting started with the DynamicsNAVProvider
============================================

Open Visual Studio 2013 and create a new F# Console application. Right-click on the project and select "Manage NuGet Packages".
Make sure the "Include Prerelease" is selected and search for "[DynamicsNAVProvider](https://nuget.org/packages/DynamicsNAVProvider)" and press "Install":

![alt text](img/NuGet.png "Install the Dynamics NAV type provider")

You also need to add a reference to "System.Data.dll" to your project.

Now you can go to the "Program.fs" file and start using the type provider:

*)

open System
open System.Linq
open FSharp.Data

// configure the Dynamics NAV type provider with a connection string to the db
type NAV = DynamicsNAV<"Data Source=OMEGA;Initial Catalog=Dev;Integrated Security=True",
                           Company="CRONUS International Ltd.">
let db = NAV.GetDataContext()

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