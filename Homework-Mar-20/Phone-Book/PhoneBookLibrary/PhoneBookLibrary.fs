namespace PhoneBookLibrary

open System.IO
open System.Text.Json

type Name = string
type Phone = string
type PhoneBook = (Phone * Name) list

type RecordRequestResult =
    | Success of PhoneBook
    | Failure of string

module PhoneBook =
    // If the name is not found returns an empty string, otherwise - corresponding phone number
    let findPhoneByName name (phoneBook : PhoneBook) =
        let rec searchStep phoneBook =
            match phoneBook with
                | (currentPhone, currentName) :: phoneBookTail when currentName = name -> Some currentPhone
                | (currentPhone, currentName) :: phoneBookTail -> searchStep phoneBookTail
                | [] -> None
        searchStep phoneBook

    // If the phone is not found returns an empty string, otherwise - corresponding name
    let findNameByPhone phone (phoneBook : PhoneBook) =
        let rec searchStep phoneBook =
            match phoneBook with
                | (currentPhone, currentName) :: phoneBookTail when currentPhone = phone -> Some currentName
                | (currentPhone, currentName) :: phoneBookTail -> searchStep phoneBookTail
                | [] -> None
        searchStep phoneBook

    // If the phone number is unique then returns new phoneBook, otherwise - recorded name
    let record phone name (phoneBook : PhoneBook) =
        match phoneBook |> findNameByPhone phone with
            | None -> Success ((phone, name) :: phoneBook)
            | Some recordedName when recordedName = name -> Success phoneBook
            | Some recordedName -> Failure recordedName

    let options = JsonSerializerOptions(PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true)
    let serialize =
        (fun x -> x, options) >> JsonSerializer.Serialize<PhoneBook>

    let storeTo path =
        serialize >> (fun x -> path, x) >> File.WriteAllText

    let loadFrom path =
        try
            path |> File.ReadAllText |> (fun x -> x, options) |> JsonSerializer.Deserialize<PhoneBook> |> Some
        with
            :? IOException as ex -> None
