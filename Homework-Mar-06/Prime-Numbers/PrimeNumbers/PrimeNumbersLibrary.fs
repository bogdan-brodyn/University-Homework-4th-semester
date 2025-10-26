namespace PrimeNumbers

module PrimeNumbers =
    let getSequence =
        let isPrime n =
            let rec isPrimeStep currentStep=
                if currentStep = n then
                    true
                else if n % currentStep = 0 then
                    false
                else
                    isPrimeStep (currentStep + 1)
            isPrimeStep 2

        let naturalNumbersFromTwo = Seq.initInfinite (fun i -> i + 1)
        naturalNumbersFromTwo |> Seq.filter isPrime 
