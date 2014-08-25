using UnityEngine;
using System.Collections;
using System.Timers;
using System.Globalization;

public class ResourceOffseter : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Save());
        StartCoroutine(TickTime());
        StartCoroutine(DepleteFood());
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator TickTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            
            if (Game.month < 12)
            {
                Game.month++;
            }
            else
            {
                Game.month = 1;
                Game.year++;

                int profit = 0;

                for (int i = 0; i < Game.colonizedPlanets.Count; i++)
                {
                    string planetName = Game.colonizedPlanets[i].name;

                    profit += Game.colonizedPlanets[i].population / 1000;
                    Game.colonizedPlanets[i].foodOffset += (Game.colonizedPlanets[i].farms - Game.colonizedPlanets[i].population);

                    if (Mathf.Clamp(Game.GetPlanetFoodRating(planetName), 0, 5) <= 0)
                    {
                        Game.colonizedPlanets[i].population /= 2;

                        if (Game.colonizedPlanets[i].population <= 0)
                        {
                            Game.CreateNotification("Colony Lost", "All of the colonists on " + planetName + " have died due to famine!", Resources.Load<AudioClip>("Sounds/Ding"));
                            Game.colonizedPlanets.RemoveAt(i);
                        }
                        else
                        {
                            Game.CreateNotification("Famine", "Their is famine on " + planetName + ". Build more farms to improve the food rating (You must have atleast 1.1 farms per thousand people for a positive food rating change).");
                        }
                    }
                    else
                    {
                        Game.colonizedPlanets[i].population += 1 + (Game.colonizedPlanets[i].population / 5000);
                    }
                }

                Game.balance += profit;
                //Game.CreateNotification("Yearly Profit", "You received " + profit.ToString("C", CultureInfo.CurrentCulture) + " from yearly taxes!", Resources.Load<AudioClip>("Sounds/Ding"));

                Game.Save(Game.planet, Application.loadedLevelName, Game.GetColonizedPlanetsText(), Game.month, Game.year, Game.balance);
            }
        }
    }

    private IEnumerator Save()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            Debug.Log("Saved!");
            Game.Save(Game.planet, Application.loadedLevelName, Game.GetColonizedPlanetsText(), Game.month, Game.year, Game.balance);
        }
    }

    private IEnumerator DepleteFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(1200000);

            for (int i = 0; i < Game.colonizedPlanets.Count; i++)
            {
                Game.colonizedPlanets[i].foodOffset--;
                PlayerPrefs.SetString("colonizedPlanets", Game.GetColonizedPlanetsText());
                PlayerPrefs.Save();
            }
        }
    }
}