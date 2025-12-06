module NumberOfDegreesTests

open NumberOfDegrees
open NUnit.Framework
open FsUnit

[<Test>]
let ``A number of 1 to 0 degrees should be an empty list`` () =
    NumberOfDegrees.get 1 -1 |> should be Empty

[<Test>]
let ``A number of 1 to 1 degrees should be correct`` () =
    NumberOfDegrees.get 0 0 |> should equal [1]

[<Test>]
let ``A number of 1 to 2 degrees should be correct`` () =
    NumberOfDegrees.get 1 1 |> should equal [2; 4]

[<Test>]
let ``A number of 0 to 4 degrees should be correct`` () =
    NumberOfDegrees.get 0 3 |> should equal [1; 2; 4; 8]
