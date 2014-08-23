using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    private void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("Planets/" + Game.GetPlanetTextureName(Game.planet));
    }
}