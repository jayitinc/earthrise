using UnityEngine;
using System.Collections;

public class ButtonNewGame : MonoBehaviour
{
    public GameObject resourceOffseterPrefab;

    private void OnMouseDown()
    {
        PlayerPrefs.DeleteAll();
        Game.planet = "Earth";
        Game.colonizedPlanets.Add(new ColonizedPlanet("Earth", 7000000, 0, 0, 0, 0, 0));
        PlayerPrefs.SetString("exists", "yes");
        PlayerPrefs.SetString("planet", "Earth");
        PlayerPrefs.SetString("screen", "Planet");
        PlayerPrefs.SetString("colonizedPlanets", "Earth#7000000#0#0#0#0#0");
        PlayerPrefs.Save();
        Instantiate(resourceOffseterPrefab, Vector2.zero, Quaternion.identity);
        Application.LoadLevel("Planet");
    }

    private void OnMouseEnter()
    {
        guiText.color = Color.red;
    }

    private void OnMouseExit()
    {
        guiText.color = Color.white;
    }
}