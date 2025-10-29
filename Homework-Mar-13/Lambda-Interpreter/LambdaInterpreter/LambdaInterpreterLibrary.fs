namespace LambdaInterpreter

type LambdaTerm =
    | Variable of string
    | Aplication of LambdaTerm * LambdaTerm
    | LambdaAbstration of string * LambdaTerm

module LambdaInterpreter =
    let rec getFreeVariables term =
        match term with
        | Variable(variable) -> set [variable]
        | Aplication(leftTerm, rightTerm) ->
            Set.union (getFreeVariables leftTerm) (getFreeVariables rightTerm)
        | LambdaAbstration(variable, subterm) ->
            Set.difference (getFreeVariables subterm) (set [variable])
    
    let rec findVariableNotContainedInSet variable set =
        let newVariable = variable + "'"
        if Set.contains newVariable set then
            findVariableNotContainedInSet newVariable set
        else
            newVariable

    let rec substitute term substituteVariable substituteTerm =
        match term with
        | Variable variable ->
            if variable = substituteVariable then
                substituteTerm
            else
                term
        | Aplication(leftTerm, rightTerm) ->
            Aplication(substitute leftTerm substituteVariable substituteTerm,
                        substitute rightTerm substituteVariable substituteTerm)
        | LambdaAbstration(variable, subterm) ->
            if variable = substituteVariable then
                term
            else
                let substituteTermFreeVariables = getFreeVariables substituteTerm
                let subtermFreeVariables = getFreeVariables subterm
                if not (Set.contains variable substituteTermFreeVariables)
                    || not (Set.contains substituteVariable subtermFreeVariables) then
                        LambdaAbstration(variable, substitute subterm substituteVariable substituteTerm)
                else
                    let newVariable = findVariableNotContainedInSet variable (Set.union substituteTermFreeVariables subtermFreeVariables)
                    let newSubterm = substitute subterm variable (Variable newVariable)
                    LambdaAbstration(newVariable, substitute newSubterm substituteVariable substituteTerm)

    let betaReduce redex =
        match redex with
        | Aplication(leftTerm, rightTerm) ->
            match leftTerm with
            | LambdaAbstration(variable, leftSubterm) ->
                Some(substitute leftSubterm variable rightTerm)
            | _ -> None
        | _ -> None

    let rec findAndReduceNormalStrategyRedex term =
        match term with
        | Variable variable -> None

        | Aplication(leftTerm, rightTerm) ->
            let termReductionResult = betaReduce term
            match termReductionResult with
            | Some newTerm -> Some newTerm
            | None ->
                let leftTermReductionResult = findAndReduceNormalStrategyRedex leftTerm
                match leftTermReductionResult with
                | Some newLeftTerm -> Some(Aplication(newLeftTerm, rightTerm))
                | None -> 
                    let rightTermReductionResult = findAndReduceNormalStrategyRedex rightTerm
                    match rightTermReductionResult with
                    | Some(newRightTerm) -> Some(Aplication(leftTerm, newRightTerm))
                    | None -> None

        | LambdaAbstration(variable, subterm) ->
            let subtermReductionResult = findAndReduceNormalStrategyRedex subterm
            match subtermReductionResult with
            | Some newSubterm -> Some(LambdaAbstration(variable, newSubterm))
            | None -> None
    
    let rec normalize term =
        let termReductionResult = findAndReduceNormalStrategyRedex term
        match termReductionResult with
        | Some newTerm ->
            normalize newTerm
        | None -> term
