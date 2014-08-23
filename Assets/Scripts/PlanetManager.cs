using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour
{
    public GameObject planet;
    public GUISkin skin;

    private Rect boxRect = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);

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
        DrawLabel(0, "Water");
        DrawBar(1, "Blue", Game.GetPlanetWaterRating(Game.planet));
        DrawLabel(2, "Wood");
        DrawBar(3, "Brown", Game.GetPlanetWoodRating(Game.planet));
    }

    private void DrawLabel(int index, string text)
    {
        GUI.Label(PositionGUIElement(index), text);
    }

    private void DrawBar(int index, string color, int value)
    {
        GUI.DrawTexture(PositionGUIElement(index), Resources.Load<Texture2D>("Bars/" + color + value));
    }

    private Rect PositionGUIElement(int index)
    {
        return new Rect(boxRect.x + 25, (boxRect.y + 100) + (50 * index), boxRect.width - 50, 50);
    }
}