// Learn more about F# at http://fsharp.org

open System
open Ft
let makeFileTransfers =
    let gftq:FileToQueueInfo =  { 
        SrcAgent=FteAgent.LinSvcApl;
        SourceDirectory = @"c:\peter\edelman";
        FilePattern = @"*.xml";
        DstAgent=QueueAgent.LinSvcApl  }
    printfn "%s" gftq.Generate
    printfn "%A" gftq.SrcAgent
    let agentname = sprintf "%A" gftq.SrcAgent
    // let gftf:FileToFileInfo = { 
    let gftf = { 
        SrcAgent=FteAgent.LinSvcApl;
        SourceDirectory = @"c:\peter\edelman";
        FilePattern = @"*.xml";
        DstAgent=FteAgent.LinSvcApl
        DstDir = @"c:\dstdir"  }
    
    let transfers = seq {
        yield FileToQueue(gftq)
        yield FileToFile(gftf)
    }
    generateAll transfers


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    do makeFileTransfers
    0 // return an integer exit code

