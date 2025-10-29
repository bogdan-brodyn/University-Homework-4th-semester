module ParseTreeTests

open LambdaInterpreter
open NUnit.Framework
open FsUnit

let I = LambdaAbstration("x", Variable "x")
let S = LambdaAbstration("x", LambdaAbstration("y", LambdaAbstration("z",
            Aplication(Aplication(Variable "x", Variable "z"), Aplication(Variable "y", Variable "z")))))
let K = LambdaAbstration("x", LambdaAbstration("y", Variable "x"))

[<Test>]
let ``Result of call with I should be I`` () =
    LambdaInterpreter.normalize I |> should equal I

[<Test>]
let ``Result of call with I I should be I`` () =
    LambdaInterpreter.normalize (Aplication(I, I)) |> should equal I

[<Test>]
let ``Result of call with I I I should be I`` () =
    LambdaInterpreter.normalize (Aplication(Aplication(I, I), I)) |> should equal I

[<Test>]
let ``Result of call with I I I I should be I`` () =
    LambdaInterpreter.normalize (Aplication(Aplication(Aplication(I, I), I), I)) |> should equal I

[<Test>]
let ``Result of call with I I I (I (I I) I) should be I`` () =
    LambdaInterpreter.normalize (Aplication(Aplication(Aplication(I, I), I),
                                        Aplication(Aplication(I, Aplication(I, I)), I))) |> should equal I

[<Test>]
let ``Result of call with S K K should be I`` () =
    LambdaInterpreter.normalize (Aplication(Aplication(S, K), K)) |> should equal (LambdaAbstration("z", Variable "z"))

[<Test>]
let ``Result of call where alpha conversion is needed should be correct`` () =
    LambdaInterpreter.normalize (Aplication(LambdaAbstration("x", LambdaAbstration("y", Aplication(Variable "x", Variable "y"))), Variable "y"))
        |> should equal (LambdaAbstration("y'", Aplication(Variable "y", Variable "y'")))
