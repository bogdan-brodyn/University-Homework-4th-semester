module EvenNumbersTests

open EvenNumbers
open NUnit.Framework
open FsUnit

[<Test>]
let ``Filter implementation call result with an empty list should be zero`` () =
    EvenNumbers.countWithFilter [] |> should equal 0

[<Test>]
let ``Fold implementation call result with an empty list should be zero`` () =
    EvenNumbers.countWithFold [] |> should equal 0

[<Test>]
let ``Map implementation call result with an empty list should be zero`` () =
    EvenNumbers.countWithMap [] |> should equal 0

[<Test>]
let ``Map implementation call result with one element list should be correct`` () =
    EvenNumbers.countWithMap [0] |> should equal 1

[<Test>]
let ``Map implementation call result with seven elements list should be correct`` () =
    EvenNumbers.countWithMap [1; 2; 9; 10; 41; 100; 121] |> should equal 3
