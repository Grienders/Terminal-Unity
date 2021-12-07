using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    int level; // выбранный уровень
    enum Screen {MainMenu, Password, Winer};
    Screen currentScreen;
    string password;
    string[] Level1Passwords = {"книга", "шкаф", "текст", "буква"};
    string[] Level2Passwords = {"полиция", "рапорт", "улика", "капитан", "наручники"};
    string[] Level3Passwords = {"космос", "космонавт", "планета", "спутник"};
    void Start()
    {
       ShowMainMenu ("Хакер");
       
    }

    void ShowMainMenu (string playerName) 
    {
        string wellcomeMes = "Какой терминал хотите взломать сегодня?";
        //level = 0;
        currentScreen = Screen.MainMenu;

        Terminal.ClearScreen();
        Terminal.WriteLine(wellcomeMes + playerName);
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Начнем!");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Введите 1 - городская библиотека.");
        Terminal.WriteLine("Введите 2 - полицеский участок.");
        Terminal.WriteLine("Введите 3 - NASA.");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Вашь выбор: ");

        
    }
    void OnUserInput (string input) 
    {
        if (input == "0") {
            Terminal.ClearScreen();
            ShowMainMenu ("Повтори выбор!");
        }
        else if (currentScreen == Screen.MainMenu) 
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }

    void RunMainMenu (string input){
                
        bool isValidLevelNum = (input == "1" || input == "2" || input == "3");

            if (isValidLevelNum){
                level = int.Parse(input); // перевод текста в число
                GameStart();
            }
            else if (input == "хакер") 
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Как Вам хурма мистер Андерсон.");
                Terminal.WriteLine("Для возврата к выбору цели, введите - 0.");
            }
            else if (input == "007") 
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Проснись и пой! Проснись и пой мистер Фримен.");
                Terminal.WriteLine("Для возврата к выбору цели, введите - 0.");
            }
                
                
                /*
                if (input == "1") 
                {
                    Terminal.ClearScreen();
                    level = 1;
                    password = Level1Passwords[0];
                    GameStart();
                    Terminal.WriteLine(" "); 
                }
                else if (input == "2")         
                {
                    Terminal.ClearScreen();
                    level = 2;
                    password = Level2Passwords[2];
                    GameStart();
                    Terminal.WriteLine(" "); 
                }
                else if (input == "3")         
                {
                    Terminal.ClearScreen();
                    level = 3;
                    password = "космос";
                    GameStart();
                    Terminal.WriteLine(" "); 
                }
                else         
                {
                    Terminal.ClearScreen();
                    Terminal.WriteLine("Введите корректное значение"); 
                    Terminal.WriteLine("Для возврата к выбору цели, введите - 0");
                }
                */
    }
    

    void checkPassword (string input) 
    {
        
        Terminal.WriteLine(" ");
        if (input == password) 
        {
            //Terminal.WriteLine("ВЗЛОМАН!");
            ShowWinScreen();
        }
        else 
        {
            Terminal.WriteLine("Не взломан ...");
            GameStart();
        }
    }

    void ShowWinScreen()
    {
            Terminal.ClearScreen();
            switch (level){
                case 1:
                    Terminal.WriteLine("ВЗЛОМАН!");
                    Terminal.WriteLine(
                        @"
    _______
   /      /,
  /      //
 /______//
(______(/
                        ");
                    Terminal.WriteLine("Для возврата к выбору цели, введите - 0.");
                        break;
                case 2: 
                    Terminal.WriteLine("ВЗЛОМАН!");
                    Terminal.WriteLine(
                        @"
      __,_____
     / __.==--/
    /#(-'
    `-'
                        ");
                    Terminal.WriteLine("Для возврата к выбору цели, введите - 0.");
                        break;
                case 3: 
                    Terminal.WriteLine("ВЗЛОМАН!");
                    Terminal.WriteLine(
                        @"
      ,
   \  :  /
`. __/ \__ .'
_ _\     /_ _
   /_   _\
 .'  \ /  `.
   /  :  \     
      '
                        ");
                    Terminal.WriteLine("Для возврата к выбору цели, введите - 0.");
                        break;
                default: 
                    break;
            }
    }
    void GameStart() 
    {

        // int indexNemberPasswor = Random.Range(0,Level1Passwords.Length); // рандомный выбор из массива

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        
        switch (level)
        {
            case 1: 
                password = Level1Passwords[Random.Range(0,Level1Passwords.Length)];
                    break;
            case 2: 
                password = Level2Passwords[Random.Range(0,Level2Passwords.Length)];
                    break;
            case 3: 
                password = Level3Passwords[2];
                    break;
            default: 
                    break;
        }

        switch (level)
        {
            case 1: 
                Terminal.WriteLine("Вы в городской библиотеке.");
                    break;
            case 2: 
                Terminal.WriteLine("Вы около полицейского участка.");
                    break;
            case 3: 
                Terminal.WriteLine("Вы в центре NASA.");
                    break;
            default: 
                    break;
        }
        Terminal.WriteLine("Введите код взлома - " + password.Anagram());
        Terminal.WriteLine("Подсказка - ");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Для возврата к выбору цели, введите - 0.");

    }


    void Update()
    {
        
    }
}
