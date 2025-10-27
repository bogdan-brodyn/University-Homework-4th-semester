namespace EvenNumbers

module EvenNumbers =
    let countWithMap list =
        list |> Seq.map (fun n -> (abs n  + 1) % 2) |> Seq.sum

    let countWithFilter list =
        list |> Seq.filter (fun n -> n % 2 = 0) |> Seq.length

    let countWithFold list =
        list |> Seq.fold (fun acc n -> acc + (abs n + 1) % 2) 0
