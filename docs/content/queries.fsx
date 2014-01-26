(*** hide ***)
#I "../../bin"
#r "FSharp.Data.DynamicsCRMProvider.dll"

open System
open System.Linq
open FSharp.Data

// configure the Dynamics CRM type provider with a connection string to the db
type CRM = DynamicsCRM<"Data Source=OMEGA;Initial Catalog=Dev;Integrated Security=True",
                           Company="CRONUS International Ltd.">
let db = CRM.GetDataContext()

(**
DynamicsCRMProvider - Queries
=============================
It's possible to perform LINQ queries against the Dynamics CRM database. These queries are transformed into SQL and run on the SQL Server:

*)

// count all CRM objects
db.Object.Count()
// [fsi: val it : int = 13859]

// count objects in a query expression
query{ for o in db.Object do
       count } 
// [fsi: val it : int = 13859]

// select all customers named "Steffen"
query{ for cus in db.Customer do
       where (cus.Name.StartsWith "Steffen") 
       select cus.Name } 
  |> Seq.toArray

(**
Joins
-----
*)

// select the customer name, the sales header no. and currency for all sales headers where the customer is named "Steffen"
query{ for cus in db.Customer do
       join sh in db.``Sales Header`` on (cus.``No.`` = sh.``Sell-to Customer No.``)
       where (cus.Name.StartsWith "Steffen") 
       select (cus.Name,sh.``No.``,sh.``Currency Code``) } 
  |> Seq.toArray
