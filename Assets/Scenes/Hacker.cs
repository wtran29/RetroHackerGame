
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    // Game config data
    const string menuHint = "You may type 'menu' at any time.";
    string[] lvlOne = { "dog", "cat", "laptop", "books", "couch", "floor" };
    string[] lvlTwo = { "office", "pencil", "stapler", "reports", "manager", "employee" };
    string[] lvlThree = { "confidential", "investigation", "intelligence", "arbitrage", "infiltrate", "eliminate" };
    Dictionary<int, string> levelDict = new Dictionary<int, string> { { 1, "Neighbor's House" }, { 2, "Large Sums Corporation" }, { 3, "CIA" } };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

	// Use this for initialization
	void Start ()
    {
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Hack.me");
        Terminal.WriteLine("");
        Terminal.WriteLine("You have been chosen to breach these locations.");
        Terminal.WriteLine("Unhash the codes to uncover the data.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Choose a location to hack into (1-3):");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. Neighbor's House");
        Terminal.WriteLine("2. Large Sums Corporation");
        Terminal.WriteLine("3. CIA");
        // Terminal.WriteLine("");
        // Terminal.WriteLine("Hint: The codes are related to their location. Good luck.");
    }
    
    // only handles user input, no execution
    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web, close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            PasswordManager(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNum = ( input == "1" || input == "2" || input =="3" );
        if (isValidLevelNum)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        //if (input == "1")
        //{
        //    level = 1;
        //    password = lvlOne[2]; // TODO make random 
        //    StartGame();
        //}
        //else if (input == "2")
        //{
        //    level = 2;
        //    password = "ShowMeTheMoney";
        //    StartGame();
        //}
        //else if (input == "3")
        //{
        //    level = 3;
        //    password = "Russia";
        //    StartGame();
        //}
        else
        {
            Terminal.WriteLine("What are you doing?? Choose level.");
            Terminal.WriteLine(menuHint);
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        //Terminal.WriteLine("You have chosen level " + level);
        bool isValidLevelDict = (level == 1 || level == 2 || level == 3);
        if (isValidLevelDict)
        {
            Terminal.WriteLine("You are hacking " + levelDict[level]);
        }
        SetRandomPassword();
        //if (level == 1)
        //{
        //    Terminal.WriteLine("Hint: The girl next ____.");
        //}
        //else if (level == 2)
        //{
        //    Terminal.WriteLine("Hint: What Jerry Maguire says");
        //}
        //else if (level == 3)
        //{
        //    Terminal.WriteLine("Hint: Trump's campaign is allegedly connected to which country?");
        //}
        Terminal.WriteLine("Decode this password:, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = lvlOne[Random.Range(0, lvlOne.Length)];
                break;
            case 2:
                password = lvlTwo[Random.Range(0, lvlTwo.Length)];
                break;
            case 3:
                password = lvlThree[Random.Range(0, lvlThree.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void PasswordManager(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
            Terminal.WriteLine("Wrong. Invalid password!");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You found a key to access Large Sums Corp.");
                Terminal.WriteLine(@"
       ;LGGGCt.
    ,fCGC   iGGGL:GGGGGGGGGGGGf,
   ;GGG,     tGGGGtGGGGGGGGGGGf;
    iCGC.   .iCGG      GG  GG
       fGGGGGC         GG  GG.
                ");
                break;
            case 2:
                Terminal.WriteLine("You found a US government access card.");
                Terminal.WriteLine(@"
    =============================
    |                .----.     |
    |   US GOV ID   : |_|_ :    |
    |   XXX-65      : |_|_ :    |
    |                '----'     |
    =============================
                ");
                break;
            case 3:
                Terminal.WriteLine(@"
   .-.,-'''``''''-,.-.
   ;<`\`'-------'`/`>;
       \\; L337 //
        :: H4x :;
         ':::..'
          <___>
          / 1 \
        :'=====':
A winner is you.");
                break;
        }
        Terminal.WriteLine("Success!");
        Terminal.WriteLine(menuHint);
    }

    // Update is called once per frame
    void Update () {
        //int index1 = Random.Range(0, lvlOne.Length);
        //print(index1);

    }

    void ExitGame()
    {
        ShowMainMenu();
    }
}
