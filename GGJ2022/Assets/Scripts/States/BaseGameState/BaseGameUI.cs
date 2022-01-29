using PersonalFramework;
using UnityEngine;
using UnityEngine.UI;

public class BaseGameUI : UIStateBase
{
    [SerializeField] private Image m_clockImage = null;

    public void UpdateTimerFill(float fillValue)
    {
        m_clockImage.fillAmount = fillValue;
    }
}