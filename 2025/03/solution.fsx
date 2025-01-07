open System.Text.RegularExpressions

// == PART 1 ==

let base_input = System.IO.File.ReadAllLines "./2025/03/input.txt"

let find_muls_in_line line = 
    Regex.Matches(line, @"mul\(\d+,\d+\)")
    |> Seq.map _.Value
    |> Seq.toArray

let compute_mul query =
    Regex.Matches(query, @"\d+")
    |> Seq.map (fun(m) -> int m.Value)
    |> Seq.fold (*) 1
    
let compute_line line =
    line
    |> find_muls_in_line
    |> Array.map compute_mul
    |> Array.fold (+) 0

let compute_all input =
    input
    |> Array.map compute_line
    |> Array.fold (+) 0

printfn $"Part 1 result: %O{compute_all base_input}"

// == PART 2 ==

let remove_donts line = Regex.Replace(line, @"don't\(\)(.*?)(do\(\)|$)", "")
    
let cleaned_input =
    base_input
    |> Array.fold (+) ""
    |> remove_donts

printfn $"Part 2 result: %A{compute_line cleaned_input}"