// Learn more about F# at http://fsharp.org

open System
open Ftest
open proc

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    do makeFileTransfers
    let outp, _ = proc.runProc "cmd" "/c hoi.cmd" None
    for line in outp do printfn "%s" line
    0 // return an integer exit code

