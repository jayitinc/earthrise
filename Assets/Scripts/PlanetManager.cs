using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour
{
    public GameObject planet;
    public GUISkin skin;

    private Rect boxRect = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
    private Vector2 scrollPosition = Vector2.zero;

    private void Update()
    {
        Vector2 planetScreenPoint = new Vector2(Screen.width / 4, Screen.height / 2);
        Vector2 planetWorldPoint = Camera.main.ScreenToWorldPoint(planetScreenPoint);
        planet.transform.position = planetWorldPoint;
    }

    private void OnGUI()
    {
        GUI.skin = skin;

        boxRect = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
        GUI.Box(boxRect, Game.GetPlanetName(Game.planet));

        int scrollHeight = 850;

        if ((Game.GetPlanetHabitability(Game.planet) && !Game.IsPlanetColonized(Game.planet)) || Game.IsPlanetColonized(Game.planet))
        {
            scrollHeight += 50;
        }

        scrollPosition = GUI.BeginScrollView(new Rect(boxRect.x + 25, boxRect.y + 100, boxRect.width - 34, boxRect.height - 125), scrollPosition, new Rect(0, 0, boxRect.width - 50, scrollHeight));

        bool colonized = false;

        for (int i = 0; i < Game.colonizedPlanets.Count; i++)
        {
            if (Game.colonizedPlanets[i].name.ToLower().Equals(Game.planet.ToLower()))
            {
                colonized = true;
            }
        }

        string colonizedText = "Not Colonized";

        if (Game.planet.ToLower().Equals("earth"))
        {
            colonizedText = "Home";
        }
        else if (!Game.GetPlanetHabitability(Game.planet))
        {
            colonizedText = "Not Habitable";
        }
        else if (Game.GetPlanetAlienStatus(Game.planet) && !colonized)
        {
            colonizedText = "Not Colonized (Aliens)";
        }
        else if (Game.GetPlanetAlienStatus(Game.planet) && colonized)
        {
            colonizedText = "Colonized (Aliens)";
        }
        else if (colonized)
        {
            colonizedText = "Colonized";
        }
        else
        {
            colonizedText = "Not Colonized";
        }

        AtmosphereInfo ai = Game.GetPlanetAtmosphereInfo(Game.planet);

        GUIStyle descriptionStyle = new GUIStyle();
        descriptionStyle.fontSize = 12;
        descriptionStyle.normal.textColor = Color.white;
        descriptionStyle.font = skin.label.font;
        descriptionStyle.alignment = TextAnchor.MiddleCenter;
        descriptionStyle.wordWrap = true;

        DrawLabel(0, colonizedText);
        DrawLabel(1, "Atmosphere");
        GUI.Label(PositionGUIElement(2), "O2-" + ai.oxygen + "%; N2-" + ai.nitrogen + "%; CO2-" + ai.carbondioxide + "%; H2-" + ai.hydrogen + "%; He-" + ai.helium + "%", descriptionStyle);
        DrawLabel(3, "Water");
        DrawBar(4, "Blue", Game.GetPlanetWaterRating(Game.planet));
        DrawLabel(5, "Wood");
        DrawBar(6, "Brown", Game.GetPlanetWoodRating(Game.planet));
        DrawLabel(7, "Stone");
        DrawBar(8, "Grey", Game.GetPlanetStoneRating(Game.planet));
        DrawLabel(9, "Fossil Fuel");
        DrawBar(10, "Purple", Game.GetPlanetFossilFuelRating(Game.planet));
        DrawLabel(11, "Food");
        Debug.Log("The food rating for " + Game.planet + " is " + Game.GetPlanetFoodRating(Game.planet));
        DrawBar(12, "Red", Game.GetPlanetFoodRating(Game.planet));
        
        GUI.Label(PositionGUIElement(14), Game.GetPlanetDescription(Game.planet), descriptionStyle);

        if (Game.GetPlanetHabitability(Game.planet) && !Game.IsPlanetColonized(Game.planet))
        {
            if(DrawButton(16, "Colonize"))
            {
                bool success = false;

                if (!Game.GetPlanetAlienStatus(Game.planet))
                    success = true;
                else
                {
                    int rand = Random.Range(0, 100);

                    success = rand > 75;
                }

                if (success)
                {
                    Game.colonizedPlanets.Add(new ColonizedPlanet(Game.planet, 1, 0, 0, 0, 0, 0, 0));
                    PlayerPrefs.SetString("colonizedPlanets", Game.GetColonizedPlanetsText());
                    PlayerPrefs.Save();

                    Game.CreateNotification("Success", "You have successful colonized " + Game.planet + "!", Resources.Load<AudioClip>("Sounds/Ding"));
                }
                else
                {
                    Game.CreateNotification("Failure", "The aliens of " + Game.planet + " will not let you colonize their world!", Resources.Load<AudioClip>("Sounds/Ding"));
                }
            }
        }

        if (Game.IsPlanetColonized(Game.planet))
        {
            DrawLabel(16, "Population: " + string.Format("{0:n0}", Game.GetPlanetPopulation(Game.planet)) + ",000", descriptionStyle);
        }

        int gmIndex = (scrollHeight / 50) - 1;

        if(DrawButton(gmIndex, "Galatic Map"))
        {
            PlayerPrefs.SetString("screen", "GalacticMap");
            PlayerPrefs.Save();
            Application.LoadLevel("GalacticMap");
        }

        GUI.EndScrollView();
    }

    private void DrawLabel(int index, string text)
    {
        GUI.Label(PositionGUIElement(index), text);
    }

    private void DrawLabel(int index, string text, GUIStyle style)
    {
        GUI.Label(PositionGUIElement(index), text, style);
    }

    private void DrawBar(int index, string color, int value)
    {
        GUI.DrawTexture(PositionGUIElement(index), Resources.Load<Texture2D>("Bars/" + color + value));
    }

    private bool DrawButton(int index, string text)
    {
        return GUI.Button(PositionGUIElement(index), text);
    }

    private Rect PositionGUIElement(int index)
    {
        return new Rect(0, (50 * index), boxRect.width - 50, 50);
    }
}