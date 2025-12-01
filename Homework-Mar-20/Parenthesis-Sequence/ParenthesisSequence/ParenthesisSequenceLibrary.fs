namespace ParenthesisSequence

module ParenthesisSequence =
    let isValidParenthesisSequence str =
        let isValidParenthesisPair left right =
            left = '(' && right = ')'
            || left = '{' && right = '}'
            || left = '[' && right = ']'

        let rec isValidParenthesisSequenceEnding str position stack=
            if String.length str <= position then
                List.isEmpty stack
            else
                let currentChar = str[position]
                match currentChar with
                    | '(' | '{' | '[' -> isValidParenthesisSequenceEnding str (position + 1) (currentChar :: stack)
                    | ')' | '}' | ']' -> 
                        match stack with
                            | lastOpenParenthesis :: tail ->
                                isValidParenthesisPair lastOpenParenthesis currentChar
                                    && isValidParenthesisSequenceEnding str (position + 1) tail
                            | [] -> false
                    | _ -> isValidParenthesisSequenceEnding str (position + 1) stack

        isValidParenthesisSequenceEnding str 0 List.empty
