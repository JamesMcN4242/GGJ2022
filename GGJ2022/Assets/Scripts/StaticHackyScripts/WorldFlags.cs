﻿using System.Collections.Generic;
using UnityEngine;

public static class WorldFlags
{
    public static bool PlayerDead = false;
    public static int ResetValue = 1;
    public static HashSet<string> PlayersOnLadders = new HashSet<string>();
}