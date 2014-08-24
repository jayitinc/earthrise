using UnityEngine;
using System.Collections;
using System.Timers;

public class ResourceOffseter : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DepleteFood());
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator DepleteFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(3600);

            for (int i = 0; i < Game.colonizedPlanets.Count; i++)
            {
                Game.colonizedPlanets[i].foodOffset--;
                PlayerPrefs.SetString("colonizedPlanets", Game.GetColonizedPlanetsText());
                PlayerPrefs.Save();
            }
        }
    }
}