namespace TreeMap

type BinaryTree<'a> =
    | Tree of 'a * BinaryTree<'a> * BinaryTree<'a>
    | Nil

module TreeMap =
    let rec map binaryTree f =
        match binaryTree with
            | Tree(value, leftSubtree, rightSubtree) ->
                Tree(f value, map leftSubtree f, map rightSubtree f)
            | Nil -> Nil
