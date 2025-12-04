open LocalNetworkLibrary
open System

printfn "Virus spread model is running"
printf "Enter path to input json file: "
let jsonPath = Console.ReadLine()
let localNetwork = LocalNetwork jsonPath

let rec loop finalState =
    let infectionStatus =
        localNetwork.getInfectedNodeIDsList()
            |> localNetwork.getStringWithMarkedNodes
    printfn $"{infectionStatus}"
    if infectionStatus = finalState then
        printfn "Final state reached"
    else
        localNetwork.infectionSpreadStep()
        loop finalState

let finalState =
    localNetwork.getInfectedNodeIDsList()
        |> localNetwork.getVirusAvailableHealthyNodes
        |> localNetwork.getStringWithMarkedNodes
loop finalState
