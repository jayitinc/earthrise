using UnityEngine;
using System.Collections;

public class GalaxyPlanet : MonoBehaviour
{
    public string planetName;
    public bool hover = false;
    private bool oldHover = false;

    private void Update()
    {

        GUIText guiText = GameObject.Find("GUI Text").GetComponent<GUIText>();

        if (hover)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
            GetComponent<SpriteRenderer>().color = Color.red;
            
            if (!guiText.text.ToLower().Equals(planetName.ToLower()))
            {
                guiText.text = planetName;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Game.planet = planetName;
                Application.LoadLevel("Planet");
            }
        }
        else
        {
            transform.localScale = new Vector3(0.05f, 0.05f, 1);
            GetComponent<SpriteRenderer>().color = Color.white;

            if (oldHover)
            {
                guiText.text = "Milky Way Galaxy";
            }
        }

        oldHover = hover;
    }

    void OnMouseEnter()
    {
        hover = true;
    }

    void OnMouseExit()
    {
        hover = false;
    }
}