using System.Collections;
using System.Collections.Generic;
using PersonalFramework;
using TMPro;
using UnityEngine;

public class DialogueUI : UIStateBase
{
    [SerializeField] private TextMeshProUGUI m_textMesh = null;

    public void UpdateText(string text)
    {
        m_textMesh.text = text;
    }
}
