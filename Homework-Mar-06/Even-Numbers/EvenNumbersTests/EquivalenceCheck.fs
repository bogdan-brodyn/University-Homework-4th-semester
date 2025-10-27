module EquivalenceCheck

open EvenNumbers
open FsCheck.NUnit

[<Property>]
let ``Filter and Fold implementations should be equivalent`` (list : int list) =
    EvenNumbers.countWithFilter list = EvenNumbers.countWithFold list

[<Property>]
let ``Fold and Map implementations should be equivalent`` (list : int list) =
    EvenNumbers.countWithFold list = EvenNumbers.countWithMap list

[<Property>]
let ``Map and Filter implementations should be equivalent`` (list : int list) =
    EvenNumbers.countWithMap list = EvenNumbers.countWithFilter list
