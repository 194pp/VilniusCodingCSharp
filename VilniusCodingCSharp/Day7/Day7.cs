using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp.Day7;
public static class Day7
{

    public static void Root()
    {
        //BooksAndPlants();
        GamesTask();
    }
    private static void BooksAndPlants()
    {
        List<Book> books = new List<Book>();
        books.Add(new Book());
        books.Add(new Book());
        books.Add(new Book());

        books[0].Title = "Cooking 101";
        books[0].Pages = 90;
        books[0].ReleaseYear = 1990;

        books[1].Title = "Caverns and Taverns";
        books[1].Pages = 300;
        books[1].ReleaseYear = 2000;

        books[2].Title = "Data structures";
        books[2].Pages = 500;
        books[2].ReleaseYear = 1980;

        books.Add(new Book("How Plumbuses are made", 475, 1515));
        books.Add(new Book("Cat toys", 100, 1899));
        books.Add(new Book("How to make money", 777, 1999));

        List<Plant> plants = new List<Plant>();
        plants.Add(new Plant());
        plants.Add(new Plant());
        plants[0].Name = "Dandelion";
        plants[0].LatinName = "Taraxacum";
        plants[0].OneYear = true;
        plants[0].PlaceOfOrigin = "Eurasia/North America";
        plants[0].MatureHeight = 0.1;
        plants[0].IsEdible = false;

        plants[1].Name = "Mint";
        plants[1].LatinName = "Mentha";
        plants[1].OneYear = true;
        plants[1].PlaceOfOrigin = "the Mediterranean";
        plants[1].MatureHeight = 0.3;
        plants[1].IsEdible = true;

        plants.Add(new Plant("Oak", "Quercus", false, "Northern Hemisphere", 30, false));
        plants.Add(new Plant("Strawberry", "Fragaria", false, "Europe", 0.1, true));

        string[] booksStrings = [.. books.Select(x => x.ToString())];
        string[] plantsStrings = [.. plants.Select(x => x.ToString())];
        string answer = $"""
            booksStrings:
            {MyUtils.StringArrayJoin(booksStrings)}
            plantsStrings:
            {MyUtils.StringArrayJoin(plantsStrings)}
            """;
        MyUtils.TaskDisplay("Books", answer);
    }
    private static string[] gameActions = ["Show games list", "Add new game", "Edit a game", "Delete a game", "Exit"];
    private static int hudWidth = 60;
    private static string whitespaces = String.Join("", new char[hudWidth].Populate(' '));
    private static string horizontalBorderDouble = String.Join("", new char[hudWidth].Populate('═'));
    private static string header = "Games Task".PadBoth(hudWidth);
    private static bool crudActive = false;
    private static bool inputActive = false;
    private static string nameInput = "";
    private static string releaseYearInput = "";
    private static string typeInput = "";
    private static string runsOnInput = "";
    private static int selectedActionStage1 = 0;
    private static void InputsHandler(char ch)
    {
        switch (selectedActionStage1)
        {
            case 0:
                nameInput += ch;
                break;
            case 1:
                releaseYearInput += ch;
                break;
            case 2:
                typeInput += ch;
                break;
            case 3:
                runsOnInput += ch;
                break;
            default:
                break;
        }
    }
    private static void PrintSubHeader(string subHeader)
    {
        Console.Write("║ ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{subHeader}: ".PadRight(hudWidth));
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" ║" + Environment.NewLine);
    }
    private static void PrintRow(string str)
    {
        Console.Write("║ ");
        Console.Write(str.PadRight(hudWidth));
        Console.Write(" ║" + Environment.NewLine);
    }
    private static void PrintRowHighlighted(string str, ConsoleColor color = ConsoleColor.Green)
    {
        Console.Write("║ ");
        Console.ForegroundColor = color;
        Console.Write(str.PadRight(hudWidth));
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" ║" + Environment.NewLine);
    }
    private static void GamesTaskShowHud(int selectedAction)
    {
        Console.Clear();
        string instructions = "(w/s to navigate, Enter to select)".PadBoth(hudWidth);
        Console.WriteLine($"""
            ╔═{horizontalBorderDouble}═╗
            ║ {header} ║
            ║ {instructions} ║
            ║ {whitespaces} ║
            """);
        for (int i = 0; i < gameActions.Length; i++)
        {
            Console.Write("║ ");
            if (i == selectedAction)
                Console.ForegroundColor = ConsoleColor.Red;
            string selection = $"{i + 1}: {gameActions[i]}".PadRight(hudWidth);
            Console.Write(selection);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" ║{Environment.NewLine}");

        }
        Console.WriteLine($"╚═{horizontalBorderDouble}═╝");
    }
    private static void GamesTaskShowHud(int selectedAction, bool confirmed, List<Game> gamelist)
    {
        Console.Clear();
        Console.WriteLine($"""
            ╔═{horizontalBorderDouble}═╗
            ║ {header} ║
            ║ {whitespaces} ║
            ║ {whitespaces} ║
            """);
        for (int i = 0; i < gameActions.Length; i++)
        {
            Console.Write("║ ");
            if (i == selectedAction)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Gray;
            string selection = $"{i + 1}: {gameActions[i]}".PadRight(hudWidth);
            Console.Write(selection);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" ║{Environment.NewLine}");

        }
        Console.WriteLine($"╟─{String.Join("", new char[hudWidth].Populate('─'))}─╢");

        switch (selectedAction)
        {
            case 0:
                GamesTaskGetStyledGameList(gamelist);
                break;
            case 1:
                GamesTaskCreatePseudoForm();
                break;
            default:
                break;
        }
    }
    private static void GamesTaskGetStyledGameList(List<Game> games)
    {
        PrintSubHeader("Games");
        for (int i = 0; i < games.Count; i++)
        {
            PrintRow($"{i + 1}. {games[i].Title}. ({games[i].ReleaseYear})");
            PrintRow($"   - genre: {games[i].Type}.");
            PrintRow($"   - runs on: {MyUtils.StringArrayJoin(games[i].RunsOn)}.");

        }
        Console.WriteLine($"╚═{horizontalBorderDouble}═╝");
    }
    private static void GamesTaskCreatePseudoForm()
    {
        string[] arrow = new string[6].Select((x, y) => y == selectedActionStage1 ? ">" : " ").ToArray();
        PrintSubHeader("Create a game");
        PrintRow($"{arrow[0]} Name: {nameInput}");
        PrintRow($"{arrow[1]} Release year: {releaseYearInput}");
        PrintRow($"{arrow[2]} Type: {typeInput}");
        PrintRow($"{arrow[3]} Runs on: {runsOnInput}");
        PrintRow($"{arrow[4]} Clear");
        PrintRow($"{arrow[5]} Confirm");
        PrintRow($"sa1: {selectedActionStage1}");
        Console.WriteLine($"╚═{horizontalBorderDouble}═╝");
    }
    private static void GamesTask()
    {
        List<Game> games = new List<Game>();
        games.Add(new Game("RuneScape", "MMORPG", 2001, ["PC"]));
        games.Add(new Game("LeagueOfLegends", "MOBA", 2009, ["PC"]));

        int selectedAction = 0;

        int formStage = 0;

        // IO loop
        while (true)
        {
            switch (formStage)
            {
                case 0:
                    GamesTaskShowHud(selectedAction);
                    break;
                case 1:
                    GamesTaskShowHud(selectedAction, true, games);
                    break;
                default:
                    break;
            }

            char key = Console.ReadKey().KeyChar;
            char keyUpper = $"{key}".ToUpper()[0];
            if (!crudActive)
            {   // top-level menu navigation
                switch (keyUpper)
                {
                    case 'W':
                        if (formStage == 0)
                        {
                            if (selectedAction < 1) selectedAction = gameActions.Length - 1;
                            else selectedAction--;
                        }
                        else if (formStage == 1)
                        {
                            if (selectedAction == 1)
                            {
                                if (selectedActionStage1 < 1) selectedActionStage1 = 5;
                                else selectedActionStage1--;
                            }
                        }
                        break;
                    case 'S':
                        if (formStage == 0)
                        {
                            if (selectedAction >= gameActions.Length - 1) selectedAction = 0;
                            else selectedAction++;
                        }
                        else if (formStage == 1)
                        {
                            if (selectedAction == 1)
                            {
                                if (selectedActionStage1 >= 5) selectedActionStage1 = 0;
                                else selectedActionStage1++;
                            }
                        }
                        break;
                    case (char)27:
                        if (formStage == 0)
                        {
                            Environment.Exit(0);
                        }
                        else if (formStage == 1)
                        {
                            formStage = 0;
                            Thread.Sleep(1);
                        }
                        break;
                    case (char)13: // enter
                        if (formStage == 0)
                        {
                            formStage = 1;
                        }
                        else if (formStage == 1)
                        {
                            if (selectedAction == 1)
                            {
                                crudActive = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            if (formStage < 1) continue;
            switch (key)
            {
                case (char)27:
                    formStage = 0;
                    break;
                case (char)13:
                    if (selectedAction == 1)
                    {
                        if (selectedActionStage1 == 4)
                        {
                            Game newGame = new Game(nameInput, typeInput, int.Parse(releaseYearInput), runsOnInput.Split(","));
                            games.Add(newGame);
                            formStage = 0;
                            selectedAction = 0;
                            nameInput = "";
                            releaseYearInput = "";
                            typeInput = "";
                            runsOnInput = "";
                        }
                    }
                    break;
                default:

                    InputsHandler(key);
                    break;
            }
        }
    }
}
