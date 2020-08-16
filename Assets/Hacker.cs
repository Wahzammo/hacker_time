using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "You may type abort at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game state
    int level;
    enum Screen { LoginScreen, HackerModule, GovTargets, FinTargets, TelcoTargets, TechTargets, Citizens, Password, Win };
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
        Terminal.WriteLine("Macrohard Aperture [Version 7.0.34567.356]");
        Terminal.WriteLine("(c) 2020 Macrohard Inc. All Rights Reserved.");
    }

    void ShowHackerModule ()
    {
        currentScreen = Screen.HackerModule;
        Terminal.ClearScreen();
        Terminal.WriteLine("HackerModule loaded....");
        Terminal.WriteLine("We strongly advise the use of VPN/TOR....");
        Terminal.WriteLine("Currently accessible targets....");
        Terminal.WriteLine("Press 1 possible governmnent organisations");
        Terminal.WriteLine("Press 2 possible financial corporations");
        Terminal.WriteLine("Press 3 possible telcommunication infrastructure");
        Terminal.WriteLine("Press 4 possible technology corporations");
        Terminal.WriteLine("Press 5 possible private citizens");
    }

    void ShowGovTargets()    // TODO CREATE SHOW... FOR OTHER OPTIONS
    {
        currentScreen = Screen.GovTargets;
        Terminal.ClearScreen();
        Terminal.WriteLine("HackerModule > local targets loaded....");
        Terminal.WriteLine("We strongly advise the use of VPN/TOR....");
        Terminal.WriteLine("Currently accessible targets....");
        Terminal.WriteLine("Press 1 to target United Nations");
        Terminal.WriteLine("Press 2 to target World Heath Organization");
        Terminal.WriteLine("Press 3 to target AUS Dept. of Defence");
        Terminal.WriteLine("Press 4 to target US Secretary of State");
        Terminal.WriteLine("Press 5 to target Ministries of the PRC");
    }

    void OnUserInput(string input)
    {
        if (input == "abort") // we can always go direct to main menu
        {
            ShowLoginScreen();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.LoginScreen)
        {
            RunLoginScreen(input);
        }
        else if (currentScreen == Screen.HackerModule)
        {
            RunHackerModule(input);
        }
        else if (currentScreen == Screen.GovTargets)
        {
            RunGovTargets(input);
        }
        else if (currentScreen == Screen.FinTargets)
        {
            RunFinTargets(input);
        }
        else if (currentScreen == Screen.TelcoTargets)
        {
            RunTelcoTargets(input);
        }
        else if (currentScreen == Screen.TechTargets)
        {
            RunTechTargets(input);
        }
        else if (currentScreen == Screen.Citizens)
        {
            RunCitizens(input);
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
        else if (input == "007")
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("0 motivation, 0 skills and 7 coffee breaks," + '\n' + "does not make you a special agent!");
            Terminal.WriteLine("Get back to work you slacker, we are watching you." + '\n');
            Terminal.WriteLine(@"
               _________                   _______
    _-----____/   ========================|______|
    |           ______________/
    |    ___--_/(_)       ^
    |___ ---
");
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Please choose a valid command....");
            Terminal.WriteLine(menuHint);
        }
    }

    void RunHackerModule(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4" || input == "5");
        if (isValidLevelNumber)
        {
            if (input == "1")
            {
                ShowGovTargets();
            }
            else if (input == "2")
            {
                ShowFinTargets();
            }
            else if (input == "3")
            {
                ShowTelcoTargets();
            }
            else if (input == "4")
            {
                ShowTechTargets();
            }
            else if (input == "5")
            {
                ShowCitizens();
            }
            
        }
        else if (input == "south park")
        {
            
            Terminal.WriteLine("Hippies. They’re everywhere." + '\n' + "They wanna save Earth," + '\n' + "but all they do is smoke pot and smell bad.");
            Terminal.WriteLine(@"
   _O_        _____         _<>_          ___  
 /     \     |     |      /      \      /  _  \
|==/=\==|    |[/_\]|     |==\==/==|    |  / \  |
|  O O  |    / O O \     |   ><   |    |  |'|  |
 \  V  /    /\  -  /\  ,-\   ()   /-.   \  X  /
 /`---'\     /`---'\   V( `-====-' )V   /`---'\
 O'_:_`O     O'M|M`O   (_____:|_____)   O'_|_`O 
  -- --       -- --       ---- ----      -- --
");
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Please choose a valid command....");
            Terminal.WriteLine(menuHint);
        }
    }

    void RunLocalTargets(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4" || input == "5");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();   // TODO these needs to redirect to new screen with local targets based on user choice
        }
        else if (input == "007")  // would be the easter egg
        {

            Terminal.WriteLine("");
            Terminal.WriteLine("");
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Please choose a valid command....");
            Terminal.WriteLine(menuHint);
        }
    }

    void RunGovTargets(string input)   //  TODO CREATE RUN... FOR OTHER OPTIONS
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4" || input == "5");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram() );
        Terminal.WriteLine(menuHint);
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
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()   // needs to be personalised to current game
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
