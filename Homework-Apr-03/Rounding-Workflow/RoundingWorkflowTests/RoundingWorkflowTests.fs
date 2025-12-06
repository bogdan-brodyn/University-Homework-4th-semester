module RoundingWorkflowTests

open RoundingWorkflowLibrary
open NUnit.Framework
open FsUnit
open System

let rounding = RoundingWorkflowBuilder

// checks count of digits after the dot
let checkAccuracy (accuracy : int) number =
    let numberWithZeroFractionalPart = number * Math.Pow(10, accuracy)
    numberWithZeroFractionalPart |> int
        |> should equal numberWithZeroFractionalPart

[<Test>]
let ``Rounding workflow should work correct with only return call case`` () =
    let computationResult =
        rounding 5 {
            return 2.12423545667
        }
    computationResult |> should (equalWithin 0.00001) 2.12424
    computationResult |> checkAccuracy 5

[<Test>]
let ``Rounding workflow should work correct with example test case`` () =
    let computationResult =
        rounding 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
    computationResult |> should (equalWithin 0.001) 0.048
    computationResult |> checkAccuracy 3

[<Test>]
let ``Rounding workflow should work correct with modified example test case`` () =
    let computationResult =
        rounding 3 {
            let! a = 2.000124234
            let! b = 12.00043253534
            let! c = a / b
            let! d = 3.50021424
            let! e = c / d
            return e
        }
    computationResult |> should (equalWithin 0.001) 0.048
    computationResult |> checkAccuracy 3
