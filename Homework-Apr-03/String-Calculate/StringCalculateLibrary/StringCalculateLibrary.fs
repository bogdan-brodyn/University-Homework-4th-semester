namespace StringCalculateLibrary

open System

type StringCalculateBuilder () =
    member this.Bind (wrappedNumber : string, expressionContinuation : int -> string) =
        let isUnwrapped, unwrappedNumber = Int32.TryParse wrappedNumber
        match isUnwrapped with
        | true -> unwrappedNumber |> expressionContinuation
        | false -> null

    member this.Return (unwrappedNumber : int) =
        unwrappedNumber |> string
