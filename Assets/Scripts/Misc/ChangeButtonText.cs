using System;
using TMPro;
using UnityEngine;

public class ChangeButtonText : MonoBehaviour
{
    TextMeshProUGUI TextComponent;
    void Awake()
    {
        TextComponent = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(string newText)
    {      
        TextComponent.text = newText;
    }

    public void InvertOnOff()
    {
        string t = TextComponent.text;
        if (TextComponent.text.Contains("ON"))
            t = t.Replace("ON", "OFF");
        else
            t = t.Replace("OFF", "ON");
        TextComponent.text = t;
    }
}
