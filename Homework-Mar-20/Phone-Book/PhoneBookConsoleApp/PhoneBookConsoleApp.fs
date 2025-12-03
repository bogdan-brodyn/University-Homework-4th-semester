open PhoneBookLibrary
open System 

printfn "Phone Book Console App:"
printfn "1 - quit"
printfn "2 - add a new record"
printfn "3 - find phone number by name"
printfn "4 - find name by phone number"
printfn "5 - print phone book"
printfn "6 - store phone book"
printfn "7 - load phone book"

let rec loop phoneBook =
    printfn "Please choose an option: "
    let task = Console.ReadLine () |> int
    match task with
        | 1 -> ()
        | 2 -> 
            printfn "Enter the phone number: "
            let phone = Console.ReadLine ()
            printfn "Enter the name: "
            let name = Console.ReadLine ()
            let requestResult = phoneBook |> PhoneBook.record phone name
            match requestResult with
                | Success extendedPhoneBook ->
                    printfn "record was added successfully"
                    loop extendedPhoneBook
                | Failure name ->
                    printfn $"phone is already owned by {name}"
                    loop phoneBook
        | 3 ->
            printfn "Enter the name: "
            let name = Console.ReadLine ()
            let phoneOption = phoneBook |> PhoneBook.findPhoneByName name
            match phoneOption with
                | Some phone -> printfn $"There is the phone number: {phone}"
                | None -> printfn "The name was not found"
            loop phoneBook
        | 4 ->
            printfn "Enter the phone number: "
            let phone = Console.ReadLine ()
            let nameOption = phoneBook |> PhoneBook.findNameByPhone phone
            match nameOption with
                | Some name -> printfn $"There is the name: {name}"
                | None -> printfn "The phone number was not found"
            loop phoneBook
        | 5 ->
            printfn "There is the book: "
            printfn $"{PhoneBook.serialize phoneBook}"
            loop phoneBook
        | 6 ->
            printfn "Enter the path: "
            let path = Console.ReadLine ()
            phoneBook |> PhoneBook.storeTo path
            loop phoneBook
        | 7 ->
            printfn "Enter the path: "
            let path = Console.ReadLine ()
            let loadedPhoneBookOption = PhoneBook.loadFrom path
            match loadedPhoneBookOption with
                | Some loadedPhoneBook ->
                    printfn "Phone Book was loaded successfully"
                    loop loadedPhoneBook
                | None ->
                    printfn "An error occurred"
                    loop phoneBook
        | _ ->
            printfn "There is no such an option"
            loop phoneBook

loop []
