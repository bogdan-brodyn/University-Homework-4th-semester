namespace NumberOfDegrees

module NumberOfDegrees =
    let getNumberOfDegrees n m = 
        [n..m] |> List.map (fun x -> x * x)

    let fastGetNumberOfDegrees n m = 
        let rec step n m acc =
            if n >= m then
                acc
            else 
                step n (m - 1) (List.head acc - (m <<< 1) + 1 :: acc)
        if n > m then
            List.Empty
        else
            step n m [m * m]
