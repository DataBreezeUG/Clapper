module Docs.Router

open Browser.Types
open Feliz.Router
open Fable.Core.JsInterop

type Page =
    | Install
    | Use
    | Languages
    | Compile
    | Export
    | Save
    | DataTypes
    | Section
    | NetworkSource
    | Wires
    | Block
    | PlcDataType
    | PlcProps
    | Project
    | Device
    | HardwareObjects
    | TagTable
    | PlcDataTypeOp
    | DataBlock
    | FunctionalBlock

[<RequireQualifiedAccess>]
module Page =
    let defaultPage = Install

    let parseFromUrlSegments = function
        | [ "use" ] -> Use
        | [ "languages" ] -> Languages
        | [ "compile" ] -> Compile
        | [ "export" ] -> Export
        | [ "save" ] -> Save
        | [ "datatypes" ] -> DataTypes
        | [ "section" ] -> Section
        | [ "networksource" ] -> NetworkSource
        | [ "wires" ] -> Wires
        | [ "block" ] -> Block
        | [ "plcdatatype" ] -> PlcDataType
        | [ "plcprops" ] -> PlcProps
        | [ "project" ] -> Project
        | [ "device" ] -> Device
        | [ "hardwareobjects" ] -> HardwareObjects
        | [ "tagtable" ] -> TagTable
        | [ "plcdatatypeop" ] -> PlcDataTypeOp
        | [ "datablock" ] -> DataBlock
        | [ "functionalblock" ] -> FunctionalBlock
        | [ ] -> Install
        | _ -> defaultPage

    let noQueryString segments : string list * (string * string) list = segments, []

    let toUrlSegments = function
        | Install -> [ ] |> noQueryString
        | Use -> [ "use" ] |> noQueryString
        | Languages -> [ "languages" ] |> noQueryString
        | Compile -> [ "compile" ] |> noQueryString
        | Export -> [ "export" ] |> noQueryString
        | Save -> [ "save" ] |> noQueryString
        | DataTypes -> [ "datatypes" ] |> noQueryString
        | Section -> [ "section" ] |> noQueryString
        | NetworkSource -> [ "networksource" ] |> noQueryString
        | Wires -> [ "wires" ] |> noQueryString
        | Block -> [ "block" ] |> noQueryString
        | PlcDataType -> [ "plcdatatype" ] |> noQueryString
        | PlcProps -> [ "plcprops" ] |> noQueryString
        | Project -> [ "project" ] |> noQueryString
        | Device -> [ "device" ] |> noQueryString
        | HardwareObjects -> [ "hardwareobjects" ] |> noQueryString
        | TagTable -> [ "tagtable" ] |> noQueryString
        | PlcDataTypeOp -> [ "plcdatatypeop" ] |> noQueryString
        | DataBlock -> [ "datablock" ] |> noQueryString
        | FunctionalBlock -> [ "functionalblock" ] |> noQueryString

[<RequireQualifiedAccess>]
module Router =
    let goToUrl (e:MouseEvent) =
        e.preventDefault()
        let href : string = !!e.currentTarget?attributes?href?value
        Router.navigate href

    let navigatePage (p:Page) = p |> Page.toUrlSegments |> Router.navigate

[<RequireQualifiedAccess>]
module Cmd =
    let navigatePage (p:Page) = p |> Page.toUrlSegments |> Cmd.navigate