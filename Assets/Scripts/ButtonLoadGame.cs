using UnityEngine;
using System.Collections;

public class ButtonLoadGame : MonoBehaviour
{
    public bool gameToLoad = false;
    public GameObject resourceOffseterPrefab;
    public GameObject notificationManagerPrefab;
    public GameObject infoDisplayPrefab;

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
            resourceOffseterPrefab = Instantiate(resourceOffseterPrefab, Vector2.zero, Quaternion.identity) as GameObject;
            resourceOffseterPrefab.name = "Resource Offseter Manager";
            notificationManagerPrefab = Instantiate(notificationManagerPrefab, Vector2.zero, Quaternion.identity) as GameObject;
            notificationManagerPrefab.name = "Notification Manager";
            infoDisplayPrefab = Instantiate(infoDisplayPrefab, new Vector2(0.01f, 0.99f), Quaternion.identity) as GameObject;
            infoDisplayPrefab.name = "Info Display";

            Game.Load();
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