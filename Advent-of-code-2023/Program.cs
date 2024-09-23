// BEFORE RUN TIME PREP
string fileLocations = "C:\\Users\\Student\\Source\\Repos\\Sovietsupporter69\\Advent-of-code-2023\\Advent-of-code-2023\\";
string[][] input = new string[3][];
for (int i = 1; i <= input.Length; i++) { input[i-1] = File.ReadAllLines(fileLocations + "Input_"+i+".txt"); } //load all input data
char[][] alphabeticalNumbers = new char[10][] { ['z','e','r','o'], ['o','n','e'], ['t','w','o'], ['t','h','r','e','e'], ['f','o','u','r'], ['f','i','v','e'], ['s','i','x'], ['s','e','v','e','n'], ['e','i','g','h','t'], ['n','i','n','e'] };

//Day1();
//Day2();
Day3();

// DAY 1
void Day1() {
    int runningTotal_1 = 0; int runningTotal_2 = 0;
    for (int i = 0; i < input[0].Length; i++) { //for each "word"
        char[] wordSplit = input[0][i].ToCharArray(); //split to char array
        List<char> numbers = new List<char>(); List<char> pureNumbers = new List<char>();
        for (int j = 0; j < wordSplit.Length; j++) {
            if (char.IsDigit(wordSplit[j])) { //check if the char is a number
                numbers.Add(wordSplit[j]); //if yes save it
                pureNumbers.Add(wordSplit[j]);
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
        runningTotal_1 += int.Parse(numbers[0].ToString() + numbers[numbers.Count - 1].ToString()); //concatinate the first and last number to make a new number
        runningTotal_2 += int.Parse(pureNumbers[0].ToString() + pureNumbers[pureNumbers.Count - 1].ToString()); 
    } //add said number to the running total
    Console.WriteLine(runningTotal_2);
    Console.WriteLine(runningTotal_1); //display answer
}

//DAY 2
void Day2() {
    int Nred = 12; int Ngreen = 13; int Nblue = 14; //what im checking for
    int runningTotal_1 = 0; int Total_2 = 0;
    for (int i = 0; i < input[1].Length; i++) {      //for each game
        string[] Cubes = input[1][i].Split(':', ';', ','); //split cube counts
        int highRed = 0; int highGreen = 0; int highBlue = 0;
        bool validGame = true;
        for (int k = 1; k < Cubes.Length; k++)
        {       //for each cube count
            string[] splitCubes = Cubes[k].Split(' ');
            int tester = 100000; //blatantly clear if something goes wrong case nothing goes thru
            switch (splitCubes[2])
            {
                case "red":
                    tester = Nred; //get the right number to check against
                    if (int.Parse(splitCubes[1]) > highRed) { highRed = int.Parse(splitCubes[1]); } //save the number if its higher than the curent highest
                    break;
                case "green":
                    tester = Ngreen;
                    if (int.Parse(splitCubes[1]) > highGreen) { highGreen = int.Parse(splitCubes[1]); }
                    break;
                case "blue":
                    tester = Nblue;
                    if (int.Parse(splitCubes[1]) > highBlue) { highBlue = int.Parse(splitCubes[1]); }
                    break;
            }
            if (int.Parse(splitCubes[1]) > tester) { validGame = false; } // if cube count is to big end game all together
            if (k == Cubes.Length - 1 && validGame == true)
            {
                runningTotal_1 += i + 1; //keep running total of the games that pass
            }
        }
        Total_2 += highRed * highGreen * highBlue;
    }
    Console.WriteLine(runningTotal_1); //display answer
    Console.WriteLine(Total_2);
}

void Day3() {
    for (int i = 0; i < input[3].Length; i++) {
        for (int j = 0; j < input[3][i].Length; j++) {
            if (input[3][i][j] != '.' && !char.IsDigit(input[3][i][j])) {
                for (int k = -1; k <= 1; k++) {
                    for (int l = -1; l <= 1; l++){
                        try {
                            if (char.IsDigit(input[3][i + k][j + l])) {
                                int o = -1; List<char> numLength = new List<char>();
                                while (true) {
                                    if (char.IsDigit(input[3][i + k][j + l + o])) {
                                        o--;
                                    }
                                    else {
                                        o++;
                                        numLength.Add(input[3][i + k][j + l + o]);
                                        if (char.IsDigit(input[3][i + k][j + l + o + numLength.Count])) {
                                            numLength.Add(input[3][i + k][j + l + o + numLength.Count]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}