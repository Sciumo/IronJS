﻿namespace IronJS.Native

open System
open IronJS
open IronJS.Support.CustomOperators
open IronJS.DescriptorAttrs

///
module internal Object =
  
  ///
  let private constructor' (func:FO) (this:CO) (value:BV) =
    match value.Tag with
    | TypeTags.Undefined -> func.Env.NewObject()
    | TypeTags.Clr -> func.Env.NewObject()
    | _ -> TC.ToObject(func.Env, value)

  ///
  let setup (env:Env) =
    let ctor = Func<FO, CO, BV, CO>(constructor')
    let ctor = ctor $ Utils.createConstructor env (Some 1)

    ctor.MetaData.Name <- "Object"
    ctor.Put("prototype", env.Prototypes.Object, Immutable)

    env.Globals.Put("Object", ctor, DontEnum)
    env.Constructors <- {env.Constructors with Object = ctor}
      
  ///
  module Prototype = 

    ///
    let private toString (_:FO) (this:CO) = 
      sprintf "[object %s]" this.ClassName

    ///
    let private toLocaleString = toString

    ///
    let private valueOf (_:FO) (this:CO) = this

    ///
    let private hasOwnProperty (_:FO) (this:CO) (name:string) =
      let mutable index = 0
      if this.PropertySchema.IndexMap.TryGetValue(name, &index) 
        then this.Properties.[index].HasValue
        else false

    ///
    let private isPrototypeOf (_:FO) (this:CO) (v:CO) = 

      let rec isPrototypeOf (o:CO) (v:CO) =
        if v $ FSharp.Utils.isNull
          then false
          elif o == v.Prototype
            then true
            else isPrototypeOf o v.Prototype

      isPrototypeOf this v

    ///
    let private propertyIsEnumerable (_:FO) (this:CO) (name:string) =
      let descriptor = this.Find(name)
      descriptor.HasValue && descriptor.IsEnumerable
  
    ///    
    let create (env:Env) =
      CO(env, env.Maps.Base, null)

    ///
    let setup (env:Env) =
      let proto = env.Prototypes.Object
      proto.Put("constructor", env.Constructors.Object, DontEnum)

      let toString = FunctionReturn<string>(toString) $ Utils.createFunction env (Some 0)
      proto.Put("toString", toString, DontEnum)
    
      let toLocaleString = FunctionReturn<string>(toLocaleString) $ Utils.createFunction env (Some 0)
      proto.Put("toLocaleString", toLocaleString, DontEnum)

      let valueOf = FunctionReturn<CO>(valueOf) $ Utils.createFunction env (Some 0)
      proto.Put("valueOf", valueOf, DontEnum)

      let hasOwnProperty = FunctionReturn<string, bool>(hasOwnProperty) $ Utils.createFunction env (Some 1)
      proto.Put("hasOwnProperty", hasOwnProperty, DontEnum)
    
      let isPrototypeOf = FunctionReturn<CO, bool>(isPrototypeOf) $ Utils.createFunction env (Some 1)
      proto.Put("isPrototypeOf", isPrototypeOf, DontEnum)

      let isNumerable = FunctionReturn<string, bool>(propertyIsEnumerable) $ Utils.createFunction env (Some 1)
      proto.Put("propertyIsEnumerable", isNumerable, DontEnum)
