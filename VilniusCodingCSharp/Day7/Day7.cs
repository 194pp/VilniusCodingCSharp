using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp.Day7;
public static class Day7
{
    public static void Root()
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
}
