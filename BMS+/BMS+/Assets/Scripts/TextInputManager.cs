﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using RTLTMPro;
using System.Text.RegularExpressions;

public class TextInputManager : MonoBehaviour
{
    
    private string m_convertedString;
    private char[] m_englishNumbers = new char[] { '0','1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public string ValidateText(string enteredText)
    {
        ConvertText(enteredText);

        Regex reg = new Regex("^(\\+98|0)?9\\d{9}$");
        if (reg.IsMatch(m_convertedString))
        {
            return m_convertedString;
        }

        FindObjectOfType<SendButtonHandler>().TryAgain();
        return null;
    }

    private void ConvertText(string enteredText)
    {
        
        char[] tempCharString = enteredText.ToCharArray();
        char[] secondTempCharStr = new char [enteredText.Length - 1];
        int j = 0;

        for (int i = 0; i < tempCharString.Length - 1 ;i++)
        {
            tempCharString[i] = m_englishNumbers[(tempCharString[i] - 0x06F0)];
            secondTempCharStr[secondTempCharStr.Length - 1 - i] = tempCharString[i];
        }
        m_convertedString = new string(secondTempCharStr);
    }

    
 
}