using UnityEngine;
using System.Collections;

public class Game
{
    public static string planet = "Earth";
    public static PlanetInfo[] planets = { 
                                         new PlanetInfo("Earth", "Earth", new AtmosphereInfo(21, 78, 1, 0, 0), 15, 4, 4, 5, 4, 5, true, false, true, "Earth is the starting point of Humanity, and your home. Earth is about 4.5 billion years old. It's conditions are perfect for life."),
                                         new PlanetInfo("Giatingo", "BlueRingedGasGiant", new AtmosphereInfo(1, 0, 0, 80, 19), -100, 0, 0, 0, 0, 0, false, false, false, "Giatingo is a gas giant. It is completely uninhabitable."),
                                         new PlanetInfo("SDPlanet", "EarthLike1", new AtmosphereInfo(20, 78, 2, 0, 0), 21, 4, 3, 4, 3, 5, true, true, true, "SDPlanet is a earth like planet. The planet is habitable.")};

    public static string GetPlanetTextureName(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].textureName;
            }
        }

        return null;
    }

    public static string GetPlanetName(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].name;
            }
        }

        return null;
    }

    public static int GetPlanetWaterRating(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].water;
            }
        }

        return 0;
    }

    public static int GetPlanetWoodRating(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].wood;
            }
        }

        return 0;
    }

    public static int GetPlanetStoneRating(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].stone;
            }
        }

        return 0;
    }

    public static int GetPlanetFossilFuelRating(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].fossilfuel;
            }
        }

        return 0;
    }

    public static int GetPlanetFoodRating(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].food;
            }
        }

        return 0;
    }
}

public class PlanetInfo
{
    public string name;
    public string textureName;
    public AtmosphereInfo atmosphere;
    public int temperature, water, wood, stone, fossilfuel, food;
    public bool life, aliens, habitable;
    public string description;
    public bool colonized = false;

    public PlanetInfo(string name, string textureName, AtmosphereInfo atmosphere, int temperature, int water, int wood, int stone, int fossilfuel, int food, bool life, bool aliens, bool habitable, string description)
    {
        this.name = name;
        this.textureName = textureName;
        this.atmosphere = atmosphere;
        this.water = water;
        this.wood = wood;
        this.stone = stone;
        this.fossilfuel = fossilfuel;
        this.life = life;
        this.aliens = aliens;
        this.habitable = habitable;
        this.description = description;
    }

    public PlanetInfo SetColonized(bool colonized)
    {
        this.colonized = colonized;
        return this;
    }
}

public class AtmosphereInfo
{
    public int oxygen;
    public int nitrogen;
    public int carbondioxide;
    public int hydrogen;
    public int helium;

    public AtmosphereInfo(int oxygen, int nitrogen, int carbondioxide, int hydrogen, int helium)
    {
        this.oxygen = oxygen;
        this.nitrogen = nitrogen;
        this.carbondioxide = carbondioxide;
        this.hydrogen = hydrogen;
        this.helium = helium;
    }
}