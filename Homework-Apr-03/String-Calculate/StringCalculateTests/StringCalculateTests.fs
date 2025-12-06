module RoundingWorkflowTests

open StringCalculateLibrary
open NUnit.Framework
open FsUnit

let calculate = StringCalculateBuilder()

[<Test>]
let ``The first monadic law should be respected. return x >>= f == f x`` () =
    calculate {
        let unwrappedNumber = 33
        let wrappedNumber = calculate { return unwrappedNumber }
        let! newUnwrappedNumber = wrappedNumber
        newUnwrappedNumber |> should equal unwrappedNumber
        return 0
    } |> ignore

[<Test>]
let ``The second monadic law should be respected. mv >>= return == mv`` () =
    calculate {
        let wrappedNumber = "322"
        let newWrappedNumber = calculate {
            let! unwrappedNumber = wrappedNumber
            return unwrappedNumber
        }
        wrappedNumber |> should equal newWrappedNumber
        return 0
    } |> ignore

[<Test>]
let ``String calculate workflow should work correct with the first example test case`` () =
    let result =
        calculate {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
    result |> should equal "3"

[<Test>]
let ``String calculate workflow should work correct with the second example test case`` () =
    let result =
        calculate {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
        }
    result |> should be null
