namespace PointFree

module PointFree =
    // initial func
    let func x l = List.map (fun y -> y * x) l

    // applied eta conversion
    let func'1 x = List.map (fun y -> y * x)

    // pull 'y' to the rightmost position
    let func'2 x = List.map (fun y -> (*) x y)

    // applied eta conversion
    let func'3 x = List.map ((*) x)

    // used pipeline
    let func'4 x = x |> (*) |> List.map

    // applied eta conversion
    let func'5 = (*) >> List.map 
