namespace ReverseList

module ReverseList =
    let reverse ls =
        let rec reverseStep ls acc =
            if List.isEmpty ls then
                acc
            else
                reverseStep (List.tail ls) ((List.head ls) :: acc)
        reverseStep ls List.Empty
