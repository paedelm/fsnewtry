// Learn more about F# at http://fsharp.org

open System
open Ftest

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    do makeFileTransfers
    0 // return an integer exit code

