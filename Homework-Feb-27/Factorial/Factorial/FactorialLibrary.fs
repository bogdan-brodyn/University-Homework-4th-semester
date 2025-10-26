namespace Factorial

module Factorial =
    let compute n =
        let rec computeStep currentStep acc =
            if n < currentStep then
                acc
            else
                computeStep (currentStep + 1) (currentStep * acc)
        if n < 0 then
            invalidArg "n" "Argument 'n' cannot be negative!!!"
        computeStep 1 1
