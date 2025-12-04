namespace LocalNetworkLibrary

type NetworkNode =
    val os : OS
    val neighbours : int list

    val mutable private isInfected : bool
    member this.IsInfected
        with public get() = this.isInfected
        and private set value = this.isInfected <- value

    new(os, neighbours, isInfected) =
        {
            os = os;
            neighbours = neighbours;
            isInfected = isInfected;
        }

    member this.TryInfect() =
        if Random.getDefendProbability() < OS.getInfectionProbability this.os then
            this.isInfected <- true
