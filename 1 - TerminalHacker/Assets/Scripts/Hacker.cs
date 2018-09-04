using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    protected const string _MenuAlert = "You can type menu at any time";
    protected int _Level = 0;
    protected string _RandomPassword;
    protected string[] _Level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    protected string[] _Level2Passwords = { "prisioner", "handcuffs", "holster", "uniform", "arrest" };
    protected string[] _Level3Passwords = { "technology", "rocketlaucher", "spaceshuttle", "meteorite", "astronaut" };

    enum Screen { MainMenu, Password, Win };
    Screen CurrentScreen;

	void Start ()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    void ShowWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        RunReward();
    }

    void OnUserInput(string input)
    {
        // Can always go back to menu
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If you are on the Web close the tab");
            Application.Quit();
        }
        else if(CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunAskForPassword()
    {
        CurrentScreen = Screen.Password;

        GeneratePassword();

        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password, hint: " + _RandomPassword.Anagram());
        Terminal.WriteLine(_MenuAlert);
    }

    void RunMainMenu(string input)
    {
        int level;
        bool isInt = int.TryParse(input, out level);
        if (isInt && level > 0 && level < 4)
        {
            _Level = level;
            RunAskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
            Terminal.WriteLine(_MenuAlert);
        }
    }

    void RunReward()
    {
        switch (_Level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ________
   /       //
  /       //
 /_______//
(_______(/
");
                break;
            case 2:
                Terminal.WriteLine("Have a key...");
                Terminal.WriteLine(@"
 ___
| 0 \________
\____^^vv^^v/
");
                break;
            case 3:
                Terminal.WriteLine(@"
 __   _      _      _____      _
|  \ | |    / \    |  ___|    / \
|   \| |   / A \   |_____    / A \
| |\   |  /  _  \   ___  |  /  _  \
|_| \__| /__/ \__\ |_____| /__/ \__\
");
                Terminal.WriteLine("Welcome to NASA`s internal system");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }

        Terminal.WriteLine("");
        Terminal.WriteLine(_MenuAlert);
    }

    void GeneratePassword()
    {
        switch (_Level)
        {
            case 1:
                _RandomPassword = _Level1Passwords[UnityEngine.Random.Range(0, _Level1Passwords.Length)];
                break;
            case 2:
                _RandomPassword = _Level2Passwords[UnityEngine.Random.Range(0, _Level2Passwords.Length)];
                break;
            case 3:
                _RandomPassword = _Level3Passwords[UnityEngine.Random.Range(0, _Level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(_RandomPassword == input)
        {
            ShowWinScreen();
        }
        else
        {
            RunAskForPassword();
        }
    }
}
