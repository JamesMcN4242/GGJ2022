using System.Linq;
using UnityEngine;

public class PortalSystem
{
    private PortalTrigger[] m_portalTriggers;
    public bool AreBothPlayersIn => m_portalTriggers.All(trigger => trigger.PlayerInside);

    public PortalSystem()
    {
        m_portalTriggers = Object.FindObjectsOfType<PortalTrigger>();
    }
}