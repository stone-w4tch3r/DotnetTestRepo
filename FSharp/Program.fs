// For more information see https://aka.ms/fsharp-console-apps
printfn("Hello from F#")

let num = 1
// let num = 2let num = 1
let shadowed = 
    let num = 2
    num
printfn $"%d{shadowed}" // prints 2
printfn $"%d{num}" // prints 1

let sampleStructTuple = struct (1, 2)
//let thisWillNotCompile: (int*int) = struct (1, 2)

// Although you can
let convertFromStructTuple ((struct(a, b)): struct ('a * 'b)): 'a * 'b = (a, b)
let convertToStructTuple ((a, b): 'a * 'b): struct ('a * 'b) = struct(a, b)

//
module PipelinesAndComposition =

    let square x = x * x
    let addOne x = x + 1
    let isOdd x = x % 2 <> 0
    let numbers = [ 1; 2; 3; 4; 5 ]

    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    let squareOddValuesAndAddOneComposition =
        List.filter(isOdd) >> List.map(square >> addOne)
        
    let add4(x) = 4 + x
    printf $"%d{add4(1)}"
    

type Address = Address of string
type Name = Name of string
type SSN = SSN of int
type Patronymic = Patronymic of string | NoPatronymic

let address = Address "111 Alf Way"
let name = Name "Alf"
let ssn = SSN 1234567890
let patronymic = Patronymic "Bertil"

let unwrapAddress (Address a) = a
let unwrapName (Name n) = n
let unwrapSSN (SSN s) = s
let unwrapPatronymic (Patronymic p) = p //warning

//active patterns

let (|Even|Odd|Fuck|) input =
    if input % 2 = 0 then Even
    else if input < 0 then Fuck
    else Odd

let TestNumber i =
   match i with
   | Even -> printfn $"%d{i} is even"
   | Odd -> printfn $"%d{i} is odd"
   | Fuck -> printfn $"%d{i} is less than 0"

TestNumber 7
TestNumber 11
TestNumber 32

// active patterns rewritten with unions

type ValueType =
    | Even
    | Odd
    | Fuck
    
let matchIntegerType(value: int): ValueType =
    if value < 0 then Fuck
    else if value % 2 = 0 then Even
    else Odd
    
let printIntegerType(value: int): unit =
    value
    |> matchIntegerType
    |> (fun valType ->
        match valType with
        | Even -> printf "Is even"
        | Odd -> printf "Is odd"
        | Fuck -> printf "fuck")
    
printIntegerType 1
printIntegerType -1