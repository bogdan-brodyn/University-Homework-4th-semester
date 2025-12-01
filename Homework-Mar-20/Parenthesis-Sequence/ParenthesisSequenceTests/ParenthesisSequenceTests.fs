module ParenthesisSequenceTests

open ParenthesisSequence
open NUnit.Framework
open FsUnit

[<Test>]
let ``Result of call with empty string should be correct`` () =
    ParenthesisSequence.isValidParenthesisSequence "" |> should equal true

[<Test>]
let ``Result of call with zero parenthesis string should be correct`` () =
    ParenthesisSequence.isValidParenthesisSequence "lolkek" |> should equal true

[<Test>]
let ``Result of call with one parenthesis should be correct`` () =
    ParenthesisSequence.isValidParenthesisSequence "(" |> should equal false

[<Test>]
let ``Result of call with two parenthesis valid sequence should be correct`` () =
    ParenthesisSequence.isValidParenthesisSequence "()" |> should equal true

[<Test>]
let ``Result of call with two parenthesis invalid sequence should be correct`` () =
    ParenthesisSequence.isValidParenthesisSequence ")abc(" |> should equal false

[<Test>]
let ``Result of call with nested parenthesis sequence should be correct`` () =
    ParenthesisSequence.isValidParenthesisSequence "(a(bcd))z" |> should equal true

[<Test>]
let ``Result of call with an expression in prefix notation should be correct`` () =
    ParenthesisSequence.isValidParenthesisSequence "(+) ((-) 25 3) 9" |> should equal true
