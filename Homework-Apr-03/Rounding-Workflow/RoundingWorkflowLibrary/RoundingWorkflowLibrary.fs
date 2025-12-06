namespace RoundingWorkflowLibrary

open System

type RoundingWorkflowBuilder (computationAccuracy : int) =
    member this.Bind (number : float, expressionContinuation) : float =
        Math.Round(number, computationAccuracy)
            |> expressionContinuation

    member this.Return (number : float) =
        Math.Round(number, computationAccuracy)
