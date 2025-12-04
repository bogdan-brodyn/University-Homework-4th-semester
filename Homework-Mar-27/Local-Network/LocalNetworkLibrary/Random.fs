namespace LocalNetworkLibrary

open System

module Random =
    let mutable random = Random()

    let getDefendProbability () = random.NextDouble ()
