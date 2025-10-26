module FibonacciTests

open Fibonacci
open NUnit.Framework
open FsUnit

[<Test>]
let ``getNumber should fail on call with a negative parameter!!!`` () =
    (fun () -> Fibonacci.getNumber -1 |> ignore) |> should throw typeof<System.ArgumentException>

[<Test>]
let ``0th Fibonacci number should be 1`` () =
    Fibonacci.getNumber 0 |> should equal 1

[<Test>]
let ``1st Fibonacci number should be 1`` () =
    Fibonacci.getNumber 1 |> should equal 1

[<Test>]
let ``2nd Fibonacci number should be 2`` () =
    Fibonacci.getNumber 2 |> should equal 2

[<Test>]
let ``3rd Fibonacci number should be 3`` () =
    Fibonacci.getNumber 3 |> should equal 3

[<Test>]
let ``4th Fibonacci number should be 5`` () =
    Fibonacci.getNumber 4 |> should equal 5

[<Test>]
let ``5th Fibonacci number should be 8`` () =
    Fibonacci.getNumber 5 |> should equal 8
