using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    public string levelToLoad;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            Application.LoadLevel(levelToLoad);
        }
    }
}