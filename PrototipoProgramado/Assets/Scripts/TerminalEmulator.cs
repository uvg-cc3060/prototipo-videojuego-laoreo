using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalEmulator : MonoBehaviour
{
    private Image panel;
    private Text text;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        panel = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            panel.gameObject.SetActive(true);
        }
        else panel.gameObject.SetActive(false);
    }

    public void PrintEvent(string e)
    {
        text.text = string.Concat(text.text, e, "()", "\n");
    }
}
