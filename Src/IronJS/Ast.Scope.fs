﻿namespace IronJS.Ast

open IronJS
open IronJS.Aliases

type LocalMap = Map<string, LocalVar>
type ClosureMap = Map<string, ClosureVar>

type ScopeFlags 
  = HasDS = 1
  | InLocalDS = 2
  | NeedGlobals = 4
  | NeedClosure = 8

type Scope = {
  LocalVars: LocalMap
  ClosureVars: ClosureMap
  ScopeLevel: int
  Flags: ScopeFlags Set
  ArgTypes: ClrType array
} with
  member x.HasDS = x.Flags.Contains ScopeFlags.HasDS
  member x.InLocalDS = x.Flags.Contains ScopeFlags.InLocalDS

  static member New = { 
    Flags = Set.empty
    LocalVars = Map.empty
    ClosureVars = Map.empty
    ScopeLevel = 0
    ArgTypes = null
  }