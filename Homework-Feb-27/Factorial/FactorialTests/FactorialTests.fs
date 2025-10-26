module FactorialTests

open Factorial
open NUnit.Framework
open FsUnit

[<Test>]
let ``compute should fail on call with a negative parameter!!!`` () =
    (fun () -> Factorial.compute -1 |> ignore) |> should throw typeof<System.ArgumentException>

[<Test>]
let ``0! should be 1`` () =
    Factorial.compute 0 |> should equal 1

[<Test>]
let ``1! should be 1`` () =
    Factorial.compute 1 |> should equal 1

[<Test>]
let ``2! should be 2`` () =
    Factorial.compute 2 |> should equal 2

[<Test>]
let ``3! should be 6`` () =
    Factorial.compute 3 |> should equal 6

[<Test>]
let ``4! should be 24`` () =
    Factorial.compute 4 |> should equal 24

[<Test>]
let ``5! should be 120`` () =
    Factorial.compute 5 |> should equal 120
