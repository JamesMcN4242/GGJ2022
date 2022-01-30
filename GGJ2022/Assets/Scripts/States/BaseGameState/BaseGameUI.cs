using System;
using PersonalFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseGameUI : UIStateBase
{
    [SerializeField] private Image m_clockImage = null;
    [SerializeField] private Image m_p1Collectables = null;
    [SerializeField] private Image m_p2Collectables = null;
    [SerializeField] private TextMeshProUGUI m_p1CollectCount = null;
    [SerializeField] private TextMeshProUGUI m_p2CollectCount = null;

    public void UpdateTimerFill(float fillValue)
    {
        m_clockImage.fillAmount = fillValue;
    }

    public void UpdateCollectableImages()
    {
        if (WorldFlags.ResetValue % 2 == 0)
        {
            (m_p1Collectables.sprite, m_p2Collectables.sprite) = (m_p2Collectables.sprite, m_p1Collectables.sprite);
        }
    }
    
    public void UpdateCollectableText(int player1Collected, int p1Target, int p2Collected, int p2Target)
    {
        m_p1CollectCount.text = $"{player1Collected}/{p1Target}";
        m_p2CollectCount.text = $"{p2Collected}/{p2Target}";
    }
}