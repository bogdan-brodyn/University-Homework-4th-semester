module FactorialTests

open Factorial
open NUnit.Framework
open FsUnit

[<Test>]
let ``Factorial should return None on call with a negative parameter`` () =
    Factorial.compute -1 |> should equal None

[<TestCase(0, 1)>]
[<TestCase(1, 1)>]
[<TestCase(2, 2)>]
[<TestCase(3, 6)>]
[<TestCase(4, 24)>]
[<TestCase(5, 120)>]
let ``Factorial test on small numbers`` (input, expectedResult) =
    input |> Factorial.compute |> should equal (Some expectedResult)
