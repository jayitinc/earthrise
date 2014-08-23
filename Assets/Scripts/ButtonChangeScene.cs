using UnityEngine;
using System.Collections;

public class ButtonChangeScene : MonoBehaviour
{
    public string sceneToChangeTo;

    private void OnMouseDown()
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}