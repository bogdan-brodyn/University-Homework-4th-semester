module LocalNetworkTests

open LocalNetworkLibrary
open NUnit.Framework
open FsUnit
open Foq

let testCasePath = "../../../Statham.json"

let localNetwork = LocalNetwork testCasePath

[<Test; Order(1)>]
let ``Virus available healthy nodes search should work correct. Test case with empty list`` () =
    localNetwork.getVirusAvailableHealthyNodes []
        |> should be Empty

[<Test; Order(1)>]
let ``Virus available healthy nodes search should work correct. Test case with node 0`` () =
    localNetwork.getVirusAvailableHealthyNodes [0]
        |> should equal [0]

[<Test; Order(1)>]
let ``Virus available healthy nodes search should work correct. Test case with node 1`` () =
    localNetwork.getVirusAvailableHealthyNodes [1]
        |> should equal [7; 5; 4; 3; 1]

[<Test; Order(1)>]
let ``Virus available healthy nodes search should work correct. Test case with node 5`` () =
    localNetwork.getVirusAvailableHealthyNodes [5]
        |> should equal [7; 4; 3; 5]
        

[<Test; Order(1)>]
let ``Virus available healthy nodes search should work correct. Complex test case`` () =
    localNetwork.getVirusAvailableHealthyNodes [7; 3; 2; 1]
        |> should equal [5; 4; 1; 2; 3; 7]

[<Test; Order(2)>]
let ``Infection spread should work correctly`` () =
    let mockRandom = Mock<System.Random>()
                        .Setup(fun random -> <@ random.NextDouble() @>)
                        .Returns(0.0)
                        .Create()
    Random.random <- mockRandom
    localNetwork.infectionSpreadStep()
    let infectionStatusFirstStep = localNetwork.getInfectedNodeIDsList() |> localNetwork.getStringWithMarkedNodes
    infectionStatusFirstStep |> should equal "1 1 0 1 1 0 0 0"
    localNetwork.infectionSpreadStep()
    let infectionStatusSecodStep = localNetwork.getInfectedNodeIDsList() |> localNetwork.getStringWithMarkedNodes
    infectionStatusSecodStep |> should equal "1 1 0 1 1 1 0 0"
    localNetwork.infectionSpreadStep()
    let infectionStatusThirdStep = localNetwork.getInfectedNodeIDsList() |> localNetwork.getStringWithMarkedNodes
    infectionStatusThirdStep |> should equal "1 1 0 1 1 1 0 1"
