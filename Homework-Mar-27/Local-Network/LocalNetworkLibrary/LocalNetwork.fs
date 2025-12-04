namespace LocalNetworkLibrary

open System.IO
open System.Text.Json

type LocalNetwork =
    val mutable private nodesArray : NetworkNode array

    new(nodesArray : NetworkNode array) = { nodesArray = nodesArray; }

    new(jsonPath : string) = LocalNetwork(LocalNetwork.loadFrom jsonPath)

    static member serializationOptions = JsonSerializerOptions(PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true)

    static member loadFrom (jsonPath : string) : NetworkNode array =
        JsonSerializer.Deserialize (File.ReadAllText jsonPath, LocalNetwork.serializationOptions)

    member this.serialize () =
        JsonSerializer.Serialize (this.nodesArray, LocalNetwork.serializationOptions)

    member this.storeTo jsonPath =
        File.WriteAllText (jsonPath, this.serialize())

    member this.tryInfectNeighboursOf (node : NetworkNode) =
        let rec infectionSpreadStep (neighbours : int list) =
            match neighbours with
                | neighbour :: otherNeighbours ->
                    this.nodesArray[neighbour].TryInfect()
                    infectionSpreadStep otherNeighbours
                | [] -> ()
        infectionSpreadStep node.neighbours

    member this.infectionSpreadStep () =
        this.nodesArray
            |> Array.filter (fun node -> node.IsInfected)
            |> Array.iter (fun node -> this.tryInfectNeighboursOf node)

    member this.getInfectedNodeIDsList () =
        this.nodesArray
            |> Array.toList
            |> List.zip [ 0 .. this.nodesArray.Length - 1 ]
            |> List.filter (fun (id, node) -> node.IsInfected)
            |> List.map (fun (id, node) -> id)

    // return string there nodes with given ids are marked as 1 and others as 0
    member this.getStringWithMarkedNodes nodeIDs =
        [ 0 .. this.nodesArray.Length - 1 ]
            |> List.map (fun nodeID -> if nodeIDs |> List.contains nodeID then "1" else "0")
            |> String.concat " "

    // searches virus unprotected available nodes conected with given
    member this.getVirusAvailableHealthyNodesCPS (nodeIDs : int list) (acc: int list) (continuation : int list -> int list) =
        match nodeIDs with
                | nodeID :: otherNodes when not (acc |> List.contains nodeID) ->
                    let neighbours =
                        this.nodesArray[nodeID].neighbours
                            |> List.filter (fun nodeID ->
                                let node = this.nodesArray[nodeID]
                                OS.getInfectionProbability node.os > 0.0
                                && not node.IsInfected)
                    this.getVirusAvailableHealthyNodesCPS
                        <| otherNodes
                        <| nodeID :: acc
                        <| fun acc -> this.getVirusAvailableHealthyNodesCPS neighbours acc continuation
                | nodeID :: otherNodes->
                    this.getVirusAvailableHealthyNodesCPS
                        <| otherNodes
                        <| acc
                        <| continuation
                | [] -> continuation acc

    // searches virus unprotected available nodes conected with given
    member this.getVirusAvailableHealthyNodes (nodeIDs : int list) : int list=
        this.getVirusAvailableHealthyNodesCPS nodeIDs [] id
