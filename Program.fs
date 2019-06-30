// Learn more about F# at http://fsharp.org

open System
open Ftest
open proc
open Web

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    do makeFileTransfers
    async {
        let fd1,fd2 = runProc "cmd" "/c hoi.cmd" None
        for line in fd1 do printfn "fd1:%s" line
        for line in fd2 do printfn "fd2:%s" line
        } |> Async.RunSynchronously
    try 
        let result = Async.RunSynchronously(downLoadUrl("http://google.com"))
        printfn "%A" result
    with
    | exdl -> 
        printfn "%A" (exdl.GetBaseException())

    // for line in outp do printfn "%s" line
    0 // return an integer exit code

