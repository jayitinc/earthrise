using UnityEngine;
using System.Collections;

public class ButtonChangeScene : MonoBehaviour
{
    public string sceneToChangeTo;

    private void OnMouseDown()
    {
        Application.LoadLevel(sceneToChangeTo);
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