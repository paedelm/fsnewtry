#load "FileTransfer.fsx"
open Ft
let gftq:FileToQueueInfo = { 
    SrcAgent=FteAgent.LinSvcApl;
    SourceDirectory = @"c:\peter\edelman";
    FilePattern = @"*.xml";
    DstAgent=QueueAgent.LinSvcApl  }
gftq.Generate
printfn "%A" gftq.SrcAgent
let agentname = sprintf "%A" gftq.SrcAgent
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
do generateAll transfers
