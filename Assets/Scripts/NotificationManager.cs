using UnityEngine;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    public GUISkin skin;
    public bool notificationActive = false;
    public string notificationTitle = "";
    public string notificationText = "";
    public AudioClip notificationSound = null;
    public bool notificationSoundPlayed = false;

    private Vector2 scrollPosition = Vector2.zero;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void CreateNotification(string title, string text)
    {
        notificationTitle = title;
        notificationText = text;
        notificationActive = true;
        notificationSound = null;
    }

    public void CreateNotification(string title, string text, AudioClip sound)
    {
        notificationTitle = title;
        notificationText = text;
        notificationActive = true;
        notificationSound = sound;
    }

    private void Update()
    {
        if (notificationActive && notificationSound != null && !audio.isPlaying && !notificationSoundPlayed)
        {
            audio.clip = notificationSound;
            audio.Play();
            notificationSoundPlayed = true;
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;

        if (notificationActive)
        {
            Color original = GUI.color;

            GUI.color = new Color(0, 0, 0, 0.75f);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Resources.Load<Texture>("Pixel"));
            GUI.color = original;

            Rect boxRect = new Rect((Screen.width / 2) - ((Screen.width * 0.8f) / 2), (Screen.height / 2) - ((Screen.height * 0.8f) / 2), Screen.width * 0.8f, Screen.height * 0.8f);
            Rect notificationRect = new Rect(boxRect.x + 25, boxRect.y + 100, boxRect.width - 36, boxRect.height - 125);
            Rect notifViewRect = new Rect(notificationRect.x, notificationRect.y, notificationRect.width - 14, notificationRect.height);

            GUIStyle descriptionStyle = new GUIStyle();
            descriptionStyle.fontSize = 12;
            descriptionStyle.normal.textColor = Color.white;
            descriptionStyle.font = skin.label.font;
            descriptionStyle.alignment = TextAnchor.MiddleCenter;
            descriptionStyle.wordWrap = true;

            float textHeight = descriptionStyle.CalcHeight(new GUIContent(notificationText), notifViewRect.width);

            if (textHeight > notifViewRect.height)
                notifViewRect.height = textHeight + 50;

            GUI.Box(boxRect, notificationTitle);
            scrollPosition = GUI.BeginScrollView(notificationRect, scrollPosition, notifViewRect);
            GUI.Label(new Rect(notifViewRect.x, notifViewRect.y, notifViewRect.width, notifViewRect.height - 50), notificationText, descriptionStyle);

            if (notificationSound == null || !audio.isPlaying)
            {
                if (GUI.Button(new Rect(notifViewRect.x, notifViewRect.y + (notifViewRect.height - 25), notifViewRect.width, 25), "OK"))
                {
                    notificationActive = false;
                    notificationText = "";
                    notificationTitle = "";
                    notificationSoundPlayed = false;
                    notificationSound = null;
                }
            }

            GUI.EndScrollView();
        }
    }
}