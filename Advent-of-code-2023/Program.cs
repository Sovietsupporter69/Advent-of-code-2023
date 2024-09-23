// BEFORE RUN TIME PREP
string fileLocations = "C:\\Users\\Student\\Source\\Repos\\Sovietsupporter69\\Advent-of-code-2023\\Advent-of-code-2023\\";
string[][] in1 = new string[2][];
for (int i = 1; i <= in1.Length; i++) { in1[i-1] = File.ReadAllLines(fileLocations + "Input_"+i+".txt"); } //load all input data
char[][] alphabeticalNumbers = new char[10][] { ['z','e','r','o'], ['o','n','e'], ['t','w','o'], ['t','h','r','e','e'], ['f','o','u','r'], ['f','i','v','e'], ['s','i','x'], ['s','e','v','e','n'], ['e','i','g','h','t'], ['n','i','n','e'] };

Day1();
Day2();

// DAY 1
void Day1() {
    int runningTotal = 0;
    for (int i = 0; i < in1[0].Length; i++) { //for each "word"
        char[] wordSplit = in1[0][i].ToCharArray(); //split to char array
        List<char> numbers = new List<char>();
        for (int j = 0; j < wordSplit.Length; j++) {
            if (char.IsDigit(wordSplit[j])) { //check if the char is a number
                numbers.Add(wordSplit[j]); //if yes save it
            }
            else {
                for (int k = 0; k <= 9; k++) { //check if char is the start of a number word
                    if (wordSplit[j] == alphabeticalNumbers[k][0] && wordSplit.Length - j >= alphabeticalNumbers[k].Length) {
                        for (int l = 1; l < alphabeticalNumbers[k].Length; l++) {
                            if (wordSplit[j + l] != alphabeticalNumbers[k][l]) { //check of the rest of the word is there
                                break; //if not to next char
                            }
                            if (l == alphabeticalNumbers[k].Length - 1) { //if all pass add number equivlent to the list
                                numbers.Add(k.ToString()[0]);
                            }
                        }
                    }
                }
            }
        }
        runningTotal += int.Parse(numbers[0].ToString() + numbers[numbers.Count - 1].ToString()); //concatinate the first and last number to make a new number
    } //add said number to the running total
    Console.WriteLine(runningTotal); //display answer
}

//DAY 2
void Day2() {
    int Nred = 12; int Ngreen = 13; int Nblue = 14; //what im checking for
    int runningTotal = 0;
    for (int i = 0; i < in1[1].Length; i++) {      //for each game
        string[] Grabs = in1[1][i].Split(':', ';'); //split into hands
        for (int j = 1; j < Grabs.Length; j++) {     //for each hand
            string[] Cubes = Grabs[j].Split(',');     //split into cube counts
            for (int k = 0;k < Cubes.Length; k++) {    //for each cube count
                string[] splitCubes = Cubes[k].Split(' ');
                int tester = 100000; //blatantly clear if something goes wrong case nothing goes thru
                switch (splitCubes[2]) { //get the right number to check by
                    case "red": tester = Nred; break;
                    case "green": tester = Ngreen; break;
                    case "blue": tester = Nblue; break;
                }
                if (int.Parse(splitCubes[1]) > tester) { goto Exit; } // if cube count is to big end game all together
            }
            if (j == Grabs.Length - 2) {
                runningTotal += i+1; //keep running total of the games that pass
            }
        }
        Exit:;
    }
    Console.WriteLine(runningTotal); //display answer
} 