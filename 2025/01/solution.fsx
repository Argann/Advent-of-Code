open System.Text.RegularExpressions

// == PART 1 ==

let base_input = System.IO.File.ReadAllLines "./2025/01/input.txt"

let input =
    base_input
    |> Array.map (fun x -> Regex.Matches(x, @"\d+"))
    |> Array.map (fun m -> (int (m.Item 0).Value, int (m.Item 1).Value))
    
let left_numbers = input |> Array.map fst
let right_numbers = input |> Array.map snd

let result1 =
    [| Array.sort left_numbers; Array.sort right_numbers |]
    |> Array.transpose
    |> Array.map (fun (t) -> abs(Array.get t 0 - Array.get t 1))
    |> Array.fold (+) 0
    
printfn $"Part 1 result: %O{result1}"

// == PART 2 ==

let get_occurences_count number lst = lst |> Array.filter (fun n -> n = number) |> Array.length

let compute_number number = number * (get_occurences_count number right_numbers)

let result2 =
    input
    |> Array.map fst
    |> Array.map compute_number
    |> Array.fold (+) 0

printfn $"Part 2 result: %O{result2}"


