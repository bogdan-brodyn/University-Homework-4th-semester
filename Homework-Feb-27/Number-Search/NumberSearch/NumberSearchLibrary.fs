namespace NumberSearch

module NumberSearch =
    let find n ls =
        let rec findStep n pos ls =
            if List.isEmpty ls then
                -1
            else
                if List.head ls = n then
                    pos
                else
                    findStep n (pos + 1) (List.tail ls)
        findStep n 0 ls
