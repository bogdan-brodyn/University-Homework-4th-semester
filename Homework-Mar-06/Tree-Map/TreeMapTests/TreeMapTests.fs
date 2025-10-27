module TreeMapTests

open TreeMap
open NUnit.Framework
open FsUnit

[<Test>]
let ``Result of call with an empty tree should be an empty tree`` () =
    TreeMap.map BinaryTree<int>.Nil (fun n -> n + 1) |> should equal BinaryTree<int>.Nil

[<Test>]
let ``Result of call with one node tree should be correct`` () =
    TreeMap.map (Tree(0, Nil, Nil)) (fun n -> n + 1) |> should equal (Tree(1, Nil, Nil))

[<Test>]
let ``Result of call with five node tree should be correct`` () =
    TreeMap.map (Tree(0, Tree(1, Nil, Tree(2, Nil, Nil)), Tree(3, Nil, Tree(4, Nil, Nil)))) (fun n -> n * n)
        |> should equal (Tree(0, Tree(1, Nil, Tree(4, Nil, Nil)), Tree(9, Nil, Tree(16, Nil, Nil))))
