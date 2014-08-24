﻿using UnityEngine;
using System.Collections;

public class ButtonChangeMenu : MonoBehaviour
{
    public string menuToChangeTo;

    private void OnMouseDown()
    {
        GameObject.Find("Menus").GetComponent<MenuManager>().currentMenu = menuToChangeTo;
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