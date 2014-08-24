using UnityEngine;
using System.Collections;

public class ButtonLoadGame : MonoBehaviour
{
    public bool gameToLoad = false;
    public GameObject resourceOffseterPrefab;

    private void Update()
    {
        if (PlayerPrefs.HasKey("exists"))
        {
            gameToLoad = true;
        }
        else
        {
            gameToLoad = false;
        }

        if (!gameToLoad)
            guiText.color = Color.grey;
    }

    private void OnMouseDown()
    {
        if (gameToLoad)
        {
            string levelToLoad = "GalacticMap";

            if (PlayerPrefs.HasKey("planet"))
                Game.planet = PlayerPrefs.GetString("planet", "Earth");

            if (PlayerPrefs.HasKey("screen"))
                levelToLoad = PlayerPrefs.GetString("screen", "GalacticMap");

            if (PlayerPrefs.HasKey("colonizedPlanets"))
            {
                string rawKey = PlayerPrefs.GetString("colonizedPlanets", "Earth#7000000#0#0#0#0#0");

                string[] planets = rawKey.Split(',');

                for (int i = 0; i < planets.Length; i++)
                {
                    string[] parts = planets[i].Split('#');

                    Game.colonizedPlanets.Add(new ColonizedPlanet(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                }
            }

            Instantiate(resourceOffseterPrefab, Vector2.zero, Quaternion.identity);

            Application.LoadLevel(levelToLoad);
        }
    }

    private void OnMouseEnter()
    {
        if (gameToLoad)
            guiText.color = Color.red;
    }

    private void OnMouseExit()
    {
        if (gameToLoad)
            guiText.color = Color.white;
    }
}