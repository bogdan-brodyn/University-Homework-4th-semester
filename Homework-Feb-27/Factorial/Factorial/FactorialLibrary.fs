namespace Factorial

module Factorial =
    let compute n =
        let rec computeStep currentStep acc =
            if currentStep <= n then
                computeStep (currentStep + 1) (currentStep * acc)
            else
                Some acc
        if n >= 0 then
            computeStep 1 1
        else
            None
