﻿
module Ast

type LocalVar = {
  IsClosedOver: bool
}

type FuncInfo = {
  Locals: Map<string, LocalVar>
  Parameters: string list;
  ClosedOver: string list
  Parent: Option<FuncInfo ref>
}

let createFunc parent = { 
  Locals = Map.empty; 
  Parameters = [];
  ClosedOver = []; 
  Parent = parent
}

let addParameter (f:FuncInfo) name =
  { f with 
      Parameters = name :: f.Parameters; 
      Locals = Map.add name { IsClosedOver = false } f.Locals 
  }

type Number =
  | Double of double
  | Integer of int64

type BinaryOp =
  | Add = 0
  | Sub = 1
  | Div = 2
  | Mul = 3
  | Mod = 4

type UnaryOp =
  | Void = 0
  | Delete = 1

type Node =
  | Symbol of string
  | String of string
  | Number of Number
  | Block of Node list
  | Variable of string
  | Enclosed of string
  | Global of string
  | If of Node * Node * Node
  | Function of FuncInfo * Node * Node list * Node
  | Binary of BinaryOp * Node * Node
  | Unary of UnaryOp * Node
  | Invoke of Node * Node list
  | Var of Node
  | Assign of Node * Node
  | Return of Node
  | Null