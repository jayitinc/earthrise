using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public string currentMenu = "Main Menu";

    private void Update()
    {
        int childrenCount = transform.childCount;

        for (int i = 0; i < childrenCount; i++)
        {
            if (transform.GetChild(i).name.Equals(currentMenu))
            {
                transform.GetChild(i).gameObject.active = true;
            }
            else
            {
                transform.GetChild(i).gameObject.active = false;
            }
        }
    }
}