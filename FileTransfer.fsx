module Ft
    open System.Text.RegularExpressions
    type WinAgent =
        | WinSvcApl
    type FteAgent =
        | LinSvcApl
        | MF3
    type QueueAgent =
        | LinSvcApl
    type MainframeAgent =
        | MF1
        | MF2
        | MF3 
    let winexpr = @"^[a-zA-Z]:\\[\\\S|*\S]?.*$"
    let validate(dir) =
        let m = Regex(winexpr).Match(dir) 
        if m.Success then dir else failwith (sprintf "%s not a valid windows directory" dir)

    type WinDirectory(tdir:string) =
        let dir = validate(tdir)

        member x.Dir with get() = dir
        override x.ToString() = dir

    // type FtDirectory =
    //     | NixDirectory of string
    //     | WinDirectory of string
    //     | MainframeDataset of string                   
    type WinFileToQueueInfo = 
        {
            /// source agent
            SrcAgent: WinAgent;
            /// WinDirectory(@"c:\dir\subdir") on the source agent
            SourceDirectory: WinDirectory;
            /// an glob or regular expression
            FilePattern: string;
            DstAgent: QueueAgent;
        }
        member x.Generate = sprintf "generate WF2Q %A" x
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
    /// FileTransfer        
    type FileTransfer =
        | FileToQueue of FileToQueueInfo
        | WinFileToQueue of WinFileToQueueInfo
        | FileToFile of FileToFileInfo
    let generate ft =
        match ft with
        | FileToQueue ftq -> ftq.Generate
        | FileToFile ftf -> ftf.Generate
        | WinFileToQueue wftq -> wftq.Generate
    let generateAll transfers =
        for ft in transfers do
            generate ft |> printfn "%s"   

