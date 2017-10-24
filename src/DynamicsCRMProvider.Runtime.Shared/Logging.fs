/// [omit]
module FSharp.Data.TypeProviders.XrmProvider.Internal.Logging

open System
open System.IO
open System.Diagnostics
open Microsoft.FSharp.Reflection

/// The logging is enabled by setting the CRMPROVIDER_LOG environment variable
/// Alternatively, just change this constant to 'true' and logs will be
/// saved in the default location (see below)
let private loggingEnabled =
    true
    //System.Environment.GetEnvironmentVariable("CRM_PROVIDER_LOG") <> null

/// Log file - if the CRM_PROVIDER_LOG variable is not set, the default on
/// Windows is "C:\Users\<user>\AppData\Roaming\CrmProviderLog\log.txt" and on Mac
/// this is in "/User/<user>/.config/CrmProviderLog/log.txt")
let private logFile =
  try
    let var = System.Environment.GetEnvironmentVariable("CRM_PROVIDER_LOG")
    if var <> null then var else
      let appd = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
      if not (Directory.Exists(appd + "/CrmProviderLog")) then Directory.CreateDirectory(appd + "/CrmProviderLog") |> ignore
      appd + "/CrmProviderLog/log.txt"
  with _ -> (* Silently ignoring logging errors *) null

/// Append string to a log file
let private writeString str =
  try
    // This serializes all writes to the log file (from multiple processes)
    use fs = new FileStream(logFile, FileMode.Append, Security.AccessControl.FileSystemRights.AppendData, FileShare.Write, 4096, FileOptions.None)
    use writer = new StreamWriter(fs)
    writer.AutoFlush <- true

    let pid = Process.GetCurrentProcess().Id
    let tid = System.Threading.Thread.CurrentThread.ManagedThreadId
    let apid = System.AppDomain.CurrentDomain.Id
    writer.WriteLine(sprintf "[%s] [Pid:%d, Tid:%d, Apid:%d] %s" (System.DateTime.Now.ToString("G")) pid tid apid str)
  with _ -> (*silently ignoring logging errors*) () 

/// Log formatted string to a log file
let logf fmt =
    let f = if loggingEnabled then writeString else ignore
    Printf.kprintf f fmt