using UnityEngine;
using System.Collections;

public class ButtonNewGame : MonoBehaviour
{
    public GameObject resourceOffseterPrefab;
    public GameObject notificationManagerPrefab;
    public GameObject infoDisplayPrefab;

    private void OnMouseDown()
    {
        PlayerPrefs.DeleteAll();
        Game.planet = "Earth";
        Game.colonizedPlanets.Add(new ColonizedPlanet("Earth", 7000000, 0, 0, 0, 0, 0, 8000000));
        Game.NewSave();
        resourceOffseterPrefab = Instantiate(resourceOffseterPrefab, Vector2.zero, Quaternion.identity) as GameObject;
        resourceOffseterPrefab.name = "Resource Offseter Manager";
        notificationManagerPrefab = Instantiate(notificationManagerPrefab, Vector2.zero, Quaternion.identity) as GameObject;
        notificationManagerPrefab.name = "Notification Manager";
        infoDisplayPrefab = Instantiate(infoDisplayPrefab, new Vector2(0.01f, 0.99f), Quaternion.identity) as GameObject;
        infoDisplayPrefab.name = "Info Display";
        Application.LoadLevel("Planet");

        GameObject.Find("Notification Manager").GetComponent<NotificationManager>().CreateNotification("Intro", "Welcome to Earth Rise! Earth is no longer able to support the needs of human kind. You have been tasked with colonizing planets around the galaxy and maintaining them to keep the human race alive. Good luck!", Resources.Load<AudioClip>("Sounds/Intro"));
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