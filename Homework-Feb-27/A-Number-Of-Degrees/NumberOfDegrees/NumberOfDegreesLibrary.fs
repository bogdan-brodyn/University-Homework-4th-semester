namespace NumberOfDegrees

module NumberOfDegrees =
    let get n m =
        let rec step stepCount acc =
            if stepCount < m then
                step (stepCount + 1) ((List.head acc >>> 1) :: acc)
            else
                acc
        if n >= 0 && m >= 0 then
            step 0 [1 <<< (n + m)]
        else
            []
