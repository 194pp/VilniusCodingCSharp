using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp.Day7;
internal class Plant
{
    private string name;
    private string latinName;
    private bool oneYear;
    private string placeOfOrigin;
    private double matureHeight;
    private bool isEdible;
    public string Name { get => name; set => name = value; }
    public string LatinName { get => latinName; set => latinName = value; }
    public bool OneYear { get => oneYear; set => oneYear = value; }
    public string PlaceOfOrigin { get => placeOfOrigin; set => placeOfOrigin = value; }
    public double MatureHeight { get => matureHeight; set => matureHeight = value; }
    public bool IsEdible { get => isEdible; set => isEdible = value; }

    public Plant() { }
    public Plant(string name, string latinName, bool oneYear, string placeOfOrigin, double matureHeight, bool isEdible)
    {
        this.name = name;
        this.latinName = latinName;
        this.oneYear = oneYear;
        this.placeOfOrigin = placeOfOrigin;
        this.matureHeight = matureHeight;
        this.isEdible = isEdible;
    }

    public override string? ToString()
    {
        string ans = "{";
        ans += $"name: {this.name}, latinName: {this.latinName}, oneYear: {this.oneYear}, placeOfOrigin: {this.placeOfOrigin}, matureHeight: {this.matureHeight}, isEdible: {this.isEdible}";
        ans += "}";
        return ans;
    }
}
