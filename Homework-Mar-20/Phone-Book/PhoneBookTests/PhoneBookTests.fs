module PhoneBookTests

open PhoneBookLibrary
open NUnit.Framework
open FsUnit
open System.IO

let testCasePath = "../../../PhoneBookTestCase.json"

[<Test>]
let ``Record request should work correct`` () =
    []  |> PhoneBook.record "8 800 535-35-35" "Saul Goodman"
        |> should equal (Success [("8 800 535-35-35", "Saul Goodman")])

[<Test>]
let ``Find name by phone request with empty phone book should work correct`` () =
    []  |> PhoneBook.findNameByPhone "8 800 535-35-35"
        |> should equal None

[<Test>]
let ``Find name by phone request should work correct`` () =
    [("8 800 535-35-35", "Saul Goodman")]
        |> PhoneBook.findNameByPhone "8 800 535-35-35"
        |> should equal (Some "Saul Goodman")

[<Test>]
let ``Find phone by name request with empty phone book should work correct`` () =
    []  |> PhoneBook.findPhoneByName "Saul Goodman"
        |> should equal None

[<Test>]
let ``Find phone by name request should work correct`` () =
    ["8 800 535-35-35", "Saul Goodman"; "8 800 333-33-33", "Saul Goodman"]
        |> PhoneBook.findPhoneByName "Saul Goodman"
        |> should equal (Some "8 800 535-35-35")

[<Test>]
let ``Serialize request should work correct`` () =
    ["8 800 535-35-35", "Saul Goodman"; "8 800 333-33-33", "Saul Goodman"; "+1(800)469-92-69", "Microsoft"; "+1 800 239-56-23", "Frank Sinatra"]
        |> PhoneBook.serialize |> should equal ((File.ReadAllText testCasePath).TrimEnd ())

[<Test>]
let ``Loading request should work correct`` () =
    PhoneBook.loadFrom testCasePath |> should equal
        (Some ["8 800 535-35-35", "Saul Goodman"; "8 800 333-33-33", "Saul Goodman"; "+1(800)469-92-69", "Microsoft"; "+1 800 239-56-23", "Frank Sinatra"])
