using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp.Day7;
public class Book
{
    private string title;
    private int pages;
    private int releaseYear;
    public string Title { get => title; set => title = value; }
    public int Pages { get => pages; set => pages = value; }
    public int ReleaseYear { get => releaseYear; set => releaseYear = value; }
    public Book() { }
    public Book(string title, int pages, int releaseYear)
    {
        this.title = title;
        this.pages = pages;
        this.releaseYear = releaseYear;
    }
    public override string? ToString()
    {
        string ans = "{";
        ans += $"Book: {this.title}, pages: {this.pages}, release year: {this.releaseYear}";
        ans += "}";
        return ans;
    }
}
