module NumberSearchTests

open NumberSearch
open NUnit.Framework
open FsUnit

[<Test>]
let ``Search should return -1 on empty list`` () =
    [] |> NumberSearch.findFirstEntryOf 1 |> should equal None

[<Test>]
let ``Search should return -1 if list doesn't contain the number`` () =
    [0] |> NumberSearch.findFirstEntryOf 1 |> should equal None

[<Test>]
let ``Search test with zero element match`` () =
    [1] |> NumberSearch.findFirstEntryOf 1 |> should equal (Some 0)

[<Test>]
let ``Search test with first element match`` () =
    [0; 1] |> NumberSearch.findFirstEntryOf 1 |> should equal (Some 1)
