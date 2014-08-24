using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game
{
    public static string planet = "Earth";
    public static PlanetInfo[] planets = { 
                                         new PlanetInfo("Earth", "Earth", new AtmosphereInfo(21, 78, 1, 0, 0), 15, 4, 4, 5, 5, 5, true, false, true, "Earth is the starting point of Humanity, and your home. Earth is about 4.5 billion years old. It's conditions are perfect for life."),
                                         new PlanetInfo("Giatingo", "BlueRingedGasGiant", new AtmosphereInfo(1, 0, 0, 80, 19), -100, 0, 0, 0, 0, 0, false, false, false, "Giatingo is a gas giant. It is completely uninhabitable."),
                                         new PlanetInfo("SDPlanet", "EarthLike1", new AtmosphereInfo(20, 78, 2, 0, 0), 21, 5, 3, 4, 3, 5, true, true, true, "SDPlanet is an earth like planet. The planet is habitable."),
                                         new PlanetInfo("Celestia", "GreenRingedGasGiant", new AtmosphereInfo(0, 0, 80, 15, 5), 365, 0, 0, 0, 0, 0, false, false, false, "Celestia is a scorching hot gas giant. If any amount of oxygen were to be introduced to the atmosphere the entire planet would explode due to the hydrogen gas. It's not habitable."),
                                         new PlanetInfo("Mygon", "PurpleRingedGasGiant", new AtmosphereInfo(20, 20, 20, 20, 20), 107, 0, 0, 0, 0, 0, false, false, false, "Mygon is a gas giant with a balanced atmosphere. It is not habitable."),
                                         new PlanetInfo("Void", "EarthLike2", new AtmosphereInfo(22, 77, 1, 0, 0), 14, 3, 5, 5, 4, 2, false, false, true, "Void is an earth like planet that got it's name from the lack of animal life. The planet depends on volcanic activity to provide CO2.")};
    public static List<ColonizedPlanet> colonizedPlanets = new List<ColonizedPlanet>();

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
                for (int j = 0; j < colonizedPlanets.Count; j++)
                {
                    if (colonizedPlanets[j].name.ToLower().Equals(name.ToLower()))
                    {
                        return Mathf.Clamp(planets[i].water + colonizedPlanets[j].waterOffset, 0, 5);
                    }
                    else
                    {
                        return planets[i].water;
                    }
                }
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
                for (int j = 0; j < colonizedPlanets.Count; j++)
                {
                    if (colonizedPlanets[j].name.ToLower().Equals(name.ToLower()))
                    {
                        return Mathf.Clamp(planets[i].wood + colonizedPlanets[j].woodOffset, 0, 5);
                    }
                    else
                    {
                        return planets[i].wood;
                    }
                }
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
                for (int j = 0; j < colonizedPlanets.Count; j++)
                {
                    if (colonizedPlanets[j].name.ToLower().Equals(name.ToLower()))
                    {
                        return Mathf.Clamp(planets[i].stone + colonizedPlanets[j].stoneOffset, 0, 5);
                    }
                    else
                    {
                        return planets[i].stone;
                    }
                }
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
                for (int j = 0; j < colonizedPlanets.Count; j++)
                {
                    if (colonizedPlanets[j].name.ToLower().Equals(name.ToLower()))
                    {
                        return Mathf.Clamp(planets[i].fossilfuel + colonizedPlanets[j].fossilfuelOffset, 0, 5);
                    }
                    else
                    {
                        return planets[i].fossilfuel;
                    }
                }
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
                for (int j = 0; j < colonizedPlanets.Count; j++)
                {
                    if (colonizedPlanets[j].name.ToLower().Equals(name.ToLower()))
                    {
                        return Mathf.Clamp(planets[i].food + colonizedPlanets[j].foodOffset, 0, 5);
                    }
                    else
                    {
                        return planets[i].food;
                    }
                }
            }
        }

        return 0;
    }

    public static string GetPlanetDescription(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].description;
            }
        }

        return "[ERROR: This description is blank]";
    }

    public static bool GetPlanetHabitability(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].habitable;
            }
        }

        return false;
    }

    public static bool GetPlanetAlienStatus(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].aliens;
            }
        }

        return false;
    }

    public static AtmosphereInfo GetPlanetAtmosphereInfo(string name)
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].name.ToLower().Equals(name.ToLower()))
            {
                return planets[i].atmosphere;
            }
        }

        return new AtmosphereInfo(0, 0, 0, 0, 0);
    }

    public static bool IsPlanetColonized(string name)
    {
        for (int i = 0; i < colonizedPlanets.Count; i++)
        {
            if (colonizedPlanets[i].name.ToLower().Equals(name.ToLower()))
            {
                return true;
            }
        }

        return false;
    }

    public static string GetColonizedPlanetsText()
    {
        string s = "";

        for (int i = 0; i < colonizedPlanets.Count; i++)
        {
            s += colonizedPlanets[i].name + "#" + colonizedPlanets[i].population + "#" + colonizedPlanets[i].waterOffset + "#" + colonizedPlanets[i].woodOffset + "#" + colonizedPlanets[i].stoneOffset + "#" + colonizedPlanets[i].fossilfuelOffset + "#" + colonizedPlanets[i].foodOffset;

            if (i < (colonizedPlanets.Count - 1))
            {
                s += ",";
            }
        }

        return s;
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
        this.food = food;
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

public class ColonizedPlanet
{
    public string name;
    public int population;
    public int waterOffset;
    public int woodOffset;
    public int stoneOffset;
    public int fossilfuelOffset;
    public int foodOffset;

    public ColonizedPlanet(string name, int population, int waterOffset, int woodOffset, int stoneOffset, int fossilfuelOffset, int foodOffset)
    {
        this.name = name;
        this.population = population;
        this.waterOffset = waterOffset;
        this.woodOffset = woodOffset;
        this.stoneOffset = stoneOffset;
        this.fossilfuelOffset = fossilfuelOffset;
        this.foodOffset = foodOffset;
    }
}