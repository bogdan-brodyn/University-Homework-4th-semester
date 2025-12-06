namespace PrimeNumbers

open System

module PrimeNumbers =
    // returns infinite sequence of prime numbers
    let getSequence =
        let isPrime (n : int) =
            let dividerUpperBound = n |> Math.Sqrt |> int
            let rec isPrimeStep currentStep =
                if currentStep > dividerUpperBound then
                    true
                else if n % currentStep = 0 then
                    false
                else
                    isPrimeStep (currentStep + 1)
            isPrimeStep 2

        (fun i -> i + 2)
            |> Seq.initInfinite // integer numbers from 2
            |> Seq.filter isPrime 
