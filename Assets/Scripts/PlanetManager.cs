using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour
{
    public GameObject planet;

    private void Update()
    {
        Vector2 planetScreenPoint = new Vector2(Screen.width / 4, Screen.height / 2);
        Vector2 planetWorldPoint = Camera.main.ScreenToWorldPoint(planetScreenPoint);
        planet.transform.position = planetWorldPoint;
    }

    private void OnGUI()
    {

    }
}