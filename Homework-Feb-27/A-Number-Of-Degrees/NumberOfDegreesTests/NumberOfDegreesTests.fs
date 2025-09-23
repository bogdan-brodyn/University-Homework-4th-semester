module NumberOfDegreesTests

open NumberOfDegrees
open NUnit.Framework
open FsUnit

[<Test>]
let ``A number of 1 to 0 degrees should be an empty list`` () =
    NumberOfDegrees.getNumberOfDegrees 1 0 |> should equal List<int>.Empty

[<Test>]
let ``A number of 1 to 1 degrees should be a list of 1`` () =
    NumberOfDegrees.getNumberOfDegrees 1 1 |> should equal [1]

[<Test>]
let ``A number of 1 to 3 degrees should be a list of 1, 4 and 9`` () =
    NumberOfDegrees.getNumberOfDegrees 1 3 |> should equal [1; 4; 9]

[<Test>]
let ``A number of 5 to 10 degrees should be a list of 25, 36, 49, 64, 81 and 100`` () =
    NumberOfDegrees.getNumberOfDegrees 5 10 |> should equal [25; 36; 49; 64; 81; 100]

[<Test>]
let ``A faster version of getNumberOfDegrees from 1 to 0 should return an empty list`` () =
    NumberOfDegrees.fastGetNumberOfDegrees 1 0 |> should equal List<int>.Empty

[<Test>]
let ``A faster version of getNumberOfDegrees from 1 to 1 should return a list of 1`` () =
    NumberOfDegrees.fastGetNumberOfDegrees 1 1 |> should equal [1]

[<Test>]
let ``A faster version of getNumberOfDegrees from 1 to 3 should return a list of 1, 4 and 9`` () =
    NumberOfDegrees.fastGetNumberOfDegrees 1 3 |> should equal [1; 4; 9]

[<Test>]
let ``A faster version of getNumberOfDegrees from 5 to 10 should return a list of 25, 36, 49, 64, 81 and 100`` () =
    NumberOfDegrees.fastGetNumberOfDegrees 5 10 |> should equal [25; 36; 49; 64; 81; 100]
