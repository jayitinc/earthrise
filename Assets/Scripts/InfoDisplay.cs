using UnityEngine;
using System.Collections;
using System.Globalization;

[RequireComponent(typeof(GUIText))]
public class InfoDisplay : MonoBehaviour
{
    public int balance;
    public string month;
    public int year;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        balance = Game.balance;
        month = Game.GetMonthAsString();
        year = Game.year;

        guiText.text = month + ", " + year + "\n" + balance.ToString("C", CultureInfo.CurrentCulture);
    }
}