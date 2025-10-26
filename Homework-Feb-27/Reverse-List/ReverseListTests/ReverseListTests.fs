module ReverseListTests

open ReverseList
open NUnit.Framework
open FsUnit

[<Test>]
let ``Reverse should return an empty list on empty list`` () =
    ReverseList.reverse List.Empty |> should equal List.Empty

[<Test>]
let ``Reverse should return the same list on one element list`` () =
    ReverseList.reverse [0] |> should equal [0]

[<Test>]
let ``Reverse usual test case`` () =
    ReverseList.reverse [1; 2; 3] |> should equal [3; 2; 1]
