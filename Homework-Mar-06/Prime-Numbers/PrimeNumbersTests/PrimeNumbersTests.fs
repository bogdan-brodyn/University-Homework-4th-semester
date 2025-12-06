module PrimeNumbersTests

open PrimeNumbers
open NUnit.Framework
open FsUnit

[<Test>]
let ``First 15 prime numbers test`` () =
    PrimeNumbers.getSequence
        |> Seq.take 15
        |> should equal [2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47]
