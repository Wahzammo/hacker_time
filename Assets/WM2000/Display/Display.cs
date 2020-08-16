﻿using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] Terminal connectedToTerminal;

    // TODO calculate these two if possible
    [SerializeField] int charactersWide = 55;   // determine how many characters appear inside the display
    [SerializeField] int charactersHigh = 15;

    Text screenText;

    private void Start()
    {
        screenText = GetComponentInChildren<Text>();
        WarnIfTerminalNotConneced();
    }

    private void WarnIfTerminalNotConneced()
    {
        if (!connectedToTerminal)
        {
            Debug.LogWarning("Display not connected to a terminal");
        }
    }

    // Akin to monitor refresh
    private void Update()
    {
        if (connectedToTerminal)
        {
            screenText.text = connectedToTerminal.GetDisplayBuffer(charactersWide, charactersHigh);
        }
    }
} 