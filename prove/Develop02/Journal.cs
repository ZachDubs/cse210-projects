using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Reflection;
class Journal
{  
    private string JournalFile = "JournalFile.txt";
    public void Run()
    {
        Console.Title = "Journal App";
        DisplayIntro();
        CreateJournalFile();
        ClearJournalFile();
        Menu();        
        DisplayOutro();
    }

    private void Menu()
    {
        string choice;
        
        do 
        {

            choice = GrabChoice();
            switch (choice)
            {
                case "1":
                    AddJournalEntry();
                    break;
                case "2":
                    DisplayJournalContents();
                    break;
                case "3":
                    SaveFile();
                    break;
                case "4":
                    LoadFile();
                    break;
                case "5":
                    CreateNewFile();
                    break;
                default:
                    break;
            }
        } while (choice != "6");
    }

    private string GrabChoice()
    {
        bool isChoiceValid = false;
        string choice = "";

        do
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("- 1. Write to the journal.");
            Console.WriteLine("- 2. Display the journal.");
            Console.WriteLine("- 3. Save to a file.");
            Console.WriteLine("- 4. Load a file.");
            Console.WriteLine("- 5. Create a new file.");
            Console.WriteLine("- 6. Quit.");
            
            Console.ForegroundColor = ConsoleColor.Blue;
            choice = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.Black;

            if (choice == "1" || choice == "2"|| choice == "3" || choice == "4" || choice == "5" || choice == "6")
            {
                isChoiceValid = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\"{choice}\"is not a valid choice. Please choose 1 - 5.");
                Console.ReadKey();
            }

        } while(! isChoiceValid);

        return choice;
    }

    private void ClearJournalFile()
    {
        System.IO.File.WriteAllText(JournalFile, "");
    }

    private void CreateJournalFile()
    {
        // this is relative to our exe
        //Console.WriteLine($"Does file exist? {System.IO.File.Exists("JournalFile.txt")}");
        if (!System.IO.File.Exists(JournalFile))
        {
            System.IO.File.CreateText(JournalFile);
        }
    }

    private void DisplayIntro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the Journal Program!");
        Console.ReadKey(true);
    }


    private void DisplayOutro()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\nThank you for using the journal! Have a good day!");
        Console.ReadKey(true);
    }
    

    private void AddJournalEntry()
    {

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        List<string> prompts = new List<string>();

        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");

        Random random = new Random();
        int promptNumber = random.Next(0, prompts.Count);
        string randomString = prompts[promptNumber];
        
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"{randomString} (Type EXIT and press enter to stop.)");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(">>> ");

        string newEntry = "";
        bool shouldContinue = true;
        while (shouldContinue)
        {
            string line = Console.ReadLine();
            if (line.ToLower().Trim() == "exit")
            {
                shouldContinue = false;
            }
            else
            {
                Console.Write(">>> ");
                newEntry += line + "\n";
            }
        }
        System.IO.File.AppendAllText(JournalFile, $"\nDate: {dateText} - Prompt: {randomString}\n{newEntry}\n");



        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\nYour entry has been added!");
    }

    private void DisplayJournalContents()
    {
        string journalText = System.IO.File.ReadAllText(JournalFile);
        Console.WriteLine("Your Journal so Far:");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\n{journalText}\n");
    }

    private void SaveFile()
    {
        Console.WriteLine("What is the filename? (Make sure to add .txt).");
        string fileToSave = Console.ReadLine();
        fileToSave = fileToSave.ToUpperInvariant();

        bool fileExists = System.IO.File.Exists($"{fileToSave}");
        if (fileExists == true)
        {
            System.IO.File.AppendAllText($"{fileToSave}", System.IO.File.ReadAllText(JournalFile));
        }
        else
        {
            Console.WriteLine($"{fileToSave} does not exist.");
        }
    }
    private void LoadFile()
    {
        Console.WriteLine("what is the filename? (Make sure to add .txt)");
        string fileToLoad = Console.ReadLine();
        fileToLoad = fileToLoad.ToUpperInvariant();

        bool fileExists = System.IO.File.Exists($"{fileToLoad}");
        if (fileExists == true)
        {
            System.IO.File.WriteAllText((JournalFile), System.IO.File.ReadAllText(fileToLoad));
        }
        else
        {
            
            Console.WriteLine($"{fileToLoad} does not exist.");
        }
    }

    private void CreateNewFile()
    {
        Console.WriteLine("What do you want the filename to be? (Be sure to add .txt at the end!)");
        string newFilename = Console.ReadLine();
        newFilename = newFilename.ToUpperInvariant();

        if (System.IO.File.Exists(newFilename) == true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This file already exists!\n");
        }
        else
        {
            using (System.IO.File.Create(newFilename))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Your file has been created!\n");
            }
        }
    }
}