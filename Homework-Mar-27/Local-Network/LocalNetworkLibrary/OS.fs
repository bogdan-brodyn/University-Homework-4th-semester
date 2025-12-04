namespace LocalNetworkLibrary

type OS =
    | Windows = 0
    | Linux = 1
    | MacOS = 2

module OS =
    // if os type is unknown then return zero
    let getInfectionProbability (os : OS) =
        match os with
            | OS.Windows -> 0.0
            | OS.Linux -> 0.5
            | OS.MacOS -> 1.0
            | _ -> 1.0
