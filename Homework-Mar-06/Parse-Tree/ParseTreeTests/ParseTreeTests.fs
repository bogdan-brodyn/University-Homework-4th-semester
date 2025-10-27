module ParseTreeTests

open ParseTree
open NUnit.Framework
open FsUnit

[<Test>]
let ``Result of call with one leaf tree should be the leaf value`` () =
    ParseTree.compute (Leaf 1) |> should equal 1

[<Test>]
let ``Result of call with three node tree should be correct`` () =
    ParseTree.compute (Tree((+), Leaf 1, Leaf 2)) |> should equal 3

[<Test>]
let ``Result of call with six leaves tree should be correct`` () =
    ParseTree.compute (Tree((+), Tree((-), Leaf 10, Tree((/), Leaf 5, Leaf 2)), Tree((*), Leaf 5, Tree((+), Leaf 3, Leaf 4))))
        |> should equal 43
