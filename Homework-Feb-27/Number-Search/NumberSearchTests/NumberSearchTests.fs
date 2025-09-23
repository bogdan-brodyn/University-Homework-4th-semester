module NumberSearchTests

open NumberSearch
open NUnit.Framework
open FsUnit

[<Test>]
let ``Search should return -1 on empty list`` () =
    NumberSearch.find 1 List.Empty |> should equal -1

[<Test>]
let ``Search should return -1 if list doesn't contain the number`` () =
    NumberSearch.find 1 [0] |> should equal -1

[<Test>]
let ``Search test with zero element match`` () =
    NumberSearch.find 1 [1] |> should equal 0

[<Test>]
let ``Search test with first element match`` () =
    NumberSearch.find 1 [0; 1] |> should equal 1
