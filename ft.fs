module Ft
    type FteAgent =
        | LinSvcApl
        | MF3
    type QueueAgent =
        | LinSvcApl
    type MainframeAgent =
        | MF1
        | MF2
        | MF3  
    type IGenerate = 
        abstract member Generate: string                  
    type FileToQueueInfo = 
        {
            /// source agent
            SrcAgent: FteAgent;
            /// sourcedirectory on the source agent
            SourceDirectory: string;
            /// an glob or regular expression
            FilePattern: string;
            DstAgent: QueueAgent;
        }
        interface IGenerate with
            member x.Generate = sprintf "generate F2Q %A" x
    type FileToFileInfo = 
        {
            /// source agent
            SrcAgent: FteAgent;
            /// sourcedirectory on the source agent
            SourceDirectory: string;
            /// an glob or regular expression
            FilePattern: string;
            DstAgent: FteAgent;
            DstDir: string
        }
        member x.Generate = sprintf "generate F2F %A" x
    type FileTransfer =
        | FileToQueue of FileToQueueInfo
        | FileToFile of FileToFileInfo
    let generate ft =
        match ft with
        | FileToQueue ftq -> ftq.Generate
        | FileToFile ftf -> ftf.Generate
    let generateAll transfers =
        for ft in transfers do
            generate ft |> printfn "%s"   
