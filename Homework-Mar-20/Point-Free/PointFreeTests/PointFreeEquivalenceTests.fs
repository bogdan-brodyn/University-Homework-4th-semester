module PointFreeEquivalenceTests

open PointFree
open NUnit.Framework
open FsCheck

[<Test>]
let ``func and func'1 should be equivalent`` () =
    Check.QuickThrowOnFailure (fun x l -> PointFree.func x l = PointFree.func'1 x l)

[<Test>]
let ``func'1 and func'2 should be equivalent`` () =
    Check.QuickThrowOnFailure (fun x l -> PointFree.func'1 x l = PointFree.func'2 x l)

[<Test>]
let ``func'2 and func'3 should be equivalent`` () =
    Check.QuickThrowOnFailure (fun x l -> PointFree.func'2 x l = PointFree.func'3 x l)

[<Test>]
let ``func'3 and func'4 should be equivalent`` () =
    Check.QuickThrowOnFailure (fun x l -> PointFree.func'3 x l = PointFree.func'4 x l)

[<Test>]
let ``func'4 and func'5 should be equivalent`` () =
    Check.QuickThrowOnFailure (fun x l -> PointFree.func'4 x l = PointFree.func'5 x l)
