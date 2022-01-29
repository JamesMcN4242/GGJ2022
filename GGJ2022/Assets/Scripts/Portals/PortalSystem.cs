using System.Linq;
using UnityEngine;

public class PortalSystem
{
    private PortalTrigger[] m_portalTriggers;
    public bool AreBothPlayersIn => m_portalTriggers.Count(trigger => trigger.PlayerInside) == 2;

    public PortalSystem()
    {
        m_portalTriggers = Object.FindObjectsOfType<PortalTrigger>();
    }
}