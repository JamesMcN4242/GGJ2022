using System.Collections.Generic;

public static class WorldFlags
{
    public static bool PlayerDead = false;
    public static int ResetValue = 1;
    public static HashSet<string> PlayersOnLadders = new HashSet<string>();
    public static int LevelIteration = 1;

    public static bool LevelConditionsMet(PlayerEntity[] entities)
    {
        bool conditionsMet = false;
        
        switch (LevelIteration)
        {
            case 1:
                break;
            
            case 2:
                break;
        }

        return conditionsMet;
    }
}