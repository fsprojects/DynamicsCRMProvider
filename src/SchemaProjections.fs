module FSharp.Data.Sql.SchemaProjections

let encapsulateCompanyName (companyName:string) =
    companyName.Replace(".","_")

let buildTableName(companyName:string, tableName:string) =
    let name = tableName.Substring(0,tableName.LastIndexOf("]")+1).Replace(companyName+"$","")
    let name = if name.StartsWith("[dbo].[") then name.Replace("[dbo].[","").TrimEnd(']') else name
    name.Replace("_",".")

let buildFieldName (fieldName:string) =
    fieldName.Replace("_",".")
