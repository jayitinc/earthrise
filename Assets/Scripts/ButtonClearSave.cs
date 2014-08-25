using UnityEngine;
using System.Collections;

public class ButtonClearSave : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.DeleteAll();
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