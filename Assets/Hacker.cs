using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "You may type abort at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game state
    int level;
    enum Screen { LoginScreen, HackerModule, Password, Win };
    Screen currentScreen;
    string password;

	// Use this for initialization
	void Start ()
    {
        ShowLoginScreen ();
    }

    void ShowLoginScreen ()
    {
        currentScreen = Screen.LoginScreen;
        Terminal.ClearScreen();
        Terminal.WriteLine("Macrohard Aperture [Version 7.0.34567.356]" + '\n');
        Terminal.WriteLine("(c) 2020 Macrohard Inc. All Rights Reserved." + '\n' + '\n');
        Terminal.WriteLine(@"C:\Users\wahzammo>");
    }

    void ShowHackerModule ()
    {
        currentScreen = Screen.HackerModule;
        Terminal.ClearScreen();
        Terminal.WriteLine("HackerModule loaded...." + '\n');
        Terminal.WriteLine("We strongly advise the use of VPN/TOR...." + '\n');
        Terminal.WriteLine("Currently accessible targets...." + '\n' + '\n');
        Terminal.WriteLine("Press 1 for the local library" + '\n');
        Terminal.WriteLine("Press 2 for the police station" + '\n');
        Terminal.WriteLine("Press 3 for NASA!" + '\n' + '\n');
        Terminal.WriteLine(@"C:\Users\wahzammo>");
    }

    void OnUserInput(string input)
    {
        if (input == "abort") // we can always go direct to main menu
        {
            ShowLoginScreen();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("" + '\n'+'\n');
            Terminal.WriteLine("If on the web close the tab." + '\n' + '\n');
            Terminal.WriteLine(@"C:\Users\wahzammo>");
            Application.Quit();
        }
        else if (currentScreen == Screen.LoginScreen)
        {
            RunLoginScreen(input);
        }
        else if (currentScreen == Screen.HackerModule)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunLoginScreen(string input)
    {
        if (input == "run H@ck3rTime" || input == "load H@ck3rTime")
        {
            ShowHackerModule();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("" + '\n' + '\n');
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("" + '\n' + '\n');
            Terminal.WriteLine("Please choose a valid command...." + '\n');
            Terminal.WriteLine(menuHint + '\n' + '\n');
            Terminal.WriteLine(@"C:\Users\wahzammo>");
        }
    }

    void RunHackerModule(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("" + '\n' + '\n');
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("" + '\n' + '\n');
            Terminal.WriteLine("Please choose a valid command...." + '\n');
            Terminal.WriteLine(menuHint + '\n');
            Terminal.WriteLine(@"C:\Users\wahzammo>");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("" + '\n' + '\n');
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram() + '\n');
        Terminal.WriteLine(menuHint + '\n');
        Terminal.WriteLine(@"C:\Users\wahzammo>");
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint + '\n');
        Terminal.WriteLine(@"C:\Users\wahzammo>");
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
