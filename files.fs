#if INTERACTIVE
module files =
#else
module files
#endif
    open System.IO
    let rec allFiles dirs =
        if Seq.isEmpty dirs then Seq.empty else
            seq { yield! dirs |> Seq.collect Directory.EnumerateFiles
                  yield! dirs |> Seq.collect Directory.EnumerateDirectories |> allFiles }

    // let rec allFilesInfo info (dirs:seq<string>) =
    //     if Seq.isEmpty dirs then Seq.empty else
    //         seq { 
    //             (for d in dirs do (yield! DirectoryInfo(d).EnumerateFiles) |> Seq.collect info
    //             yield dirs |> Seq.collect Directory.EnumerateDirectories |> allFiles
    //             }

// open files
// let peter = allFiles [@"c:\users\p_ede\projects"] |> Seq.filter (fun (n:string) -> n.EndsWith(".fs"))
