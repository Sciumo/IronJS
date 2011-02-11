﻿namespace IronJS.Compiler

open IronJS
open IronJS.Dlr.Operators
open IronJS.Utils.Patterns

module Utils =
  
  //----------------------------------------------------------------------------
  let compileIndex (ctx:Ctx) index =
    match index with
    | Ast.Number n ->
      match n with
      | IsNumberIndex index -> !!!index
      | _ -> ctx.Compile index

    | Ast.String s ->
      match s with
      | IsStringIndex index -> !!!index
      | _ -> ctx.Compile index

    | _ -> ctx.Compile index
    
  //----------------------------------------------------------------------------
  let ensureObject (ctx:Ctx) (expr:Dlr.Expr) ifObj ifClr =
    match expr.Type |> Utils.type2tag with
    | TypeTags.Function
    | TypeTags.Object -> Expr.blockTmp expr (fun expr -> [ifObj expr])
    | TypeTags.Clr -> Expr.blockTmp expr (fun expr -> [ifClr expr])
    | TypeTags.Bool
    | TypeTags.String
    | TypeTags.Undefined
    | TypeTags.Number -> 
      let expr = TypeConverter2.ToObject(ctx.Env, expr)
      Expr.blockTmp expr (fun expr -> [ifObj expr])

    | TypeTags.Box -> 
      Expr.blockTmp expr (fun expr ->
        [
          Dlr.ternary 
            (Expr.Box.isObject expr)
            (ifObj (Expr.Box.unboxObject expr))
            (Dlr.ternary
              (Expr.Box.isClr expr)
              (ifClr (Expr.Box.unboxClr expr))
              (ifObj (TypeConverter2.ToObject(ctx.Env, expr))))
        ])
    | tt -> failwithf "Invalid TypeTag '%i'" tt

  //----------------------------------------------------------------------------
  let ensureFunction (expr:Dlr.Expr) ifFunc ifClr =
    match expr.Type |> Utils.type2tag with
    | TypeTags.Function -> Expr.blockTmp expr (fun expr -> [ifFunc expr])
    | TypeTags.Clr -> Expr.blockTmp expr (fun expr -> [ifClr expr])
    | TypeTags.Object
    | TypeTags.Bool
    | TypeTags.String
    | TypeTags.Undefined
    | TypeTags.Number -> Expr.BoxedConstants.undefined
    | TypeTags.Box -> 
      Expr.blockTmp expr (fun expr ->
        [
          Dlr.ternary 
            (Expr.Box.isFunction expr)
            (ifFunc (Expr.Box.unboxFunction expr))
            (Dlr.ternary
              (Expr.Box.isClr expr)
              (ifClr (Expr.Box.unboxClr expr))
              (Expr.BoxedConstants.undefined))
        ])
    | tt -> failwithf "Invalid TypeTag '%i'" tt