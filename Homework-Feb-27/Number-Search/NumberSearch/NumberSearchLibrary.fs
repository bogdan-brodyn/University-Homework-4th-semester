namespace NumberSearch

module NumberSearch =
    let findFirstEntryOf n ls =
        let rec step pos ls =
            match ls with
                | head :: tail when head = n -> Some pos
                | head :: tail -> tail |> step (pos + 1)
                | [] -> None
        ls |> step 0
