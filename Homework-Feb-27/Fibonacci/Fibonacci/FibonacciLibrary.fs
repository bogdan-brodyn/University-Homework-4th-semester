namespace Fibonacci

module Fibonacci =
    let getNumber n =
        let rec getNumberStep stepCount previousNumber currentNumber  =
            if stepCount <= 1 then
                currentNumber
            else
                getNumberStep (stepCount - 1) currentNumber (previousNumber + currentNumber)
        if n < 0 then 
            invalidArg "n" "Argument 'n' cannot be negative!!!"
        getNumberStep n 1 1
