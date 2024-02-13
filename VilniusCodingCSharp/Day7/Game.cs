using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp.Day7;
internal class Game
{
    private string title;
    private string type;
    private int releaseYear;
    private string[] runsOn;
    public string Title { get => title; set => title = value; }
    public string Type { get => type; set => type = value; }
    public int ReleaseYear { get => releaseYear; set => releaseYear = value; }
    public string[] RunsOn { get => runsOn; set => runsOn = value; }
    public Game() { }
    public Game(string title, string type, int releaseYear, string[] runsOn)
    {
        this.title = title;
        this.type = type;
        this.releaseYear = releaseYear;
        this.runsOn = runsOn;
    }
    public override string? ToString()
    {
        string ans = "{";
        ans += $"Game: {this.title}, type: {this.type}, release year: {this.releaseYear}, runs on: {MyUtils.StringArrayJoin(this.runsOn)}";
        ans += "}";
        return ans;
    }
}
