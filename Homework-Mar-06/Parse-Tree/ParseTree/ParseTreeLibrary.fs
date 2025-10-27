namespace ParseTree

type ParseTree =
    | Tree of (int -> int -> int) * ParseTree * ParseTree
    | Leaf of int

module ParseTree =
    let rec compute parseTree =
        match parseTree with
        | Tree(operator, leftSubtree, rightSubtree) ->
            operator (compute leftSubtree) (compute rightSubtree)
        | Leaf(value) -> value
