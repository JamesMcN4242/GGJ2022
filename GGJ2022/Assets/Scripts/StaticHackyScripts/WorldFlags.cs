using System.Collections.Generic;

public static class WorldFlags
{
    public static bool PlayerDead = false;
    public static int ResetValue = 1;
    public static HashSet<string> PlayersOnLadders = new HashSet<string>();
    public static int LevelIteration = 1;
    public static float timesSwitch = 0f;

    public static bool LevelConditionsMet(PlayerEntity[] entities, int p1Counts, int p2Counts)
    {
        bool conditionsMet = false;
        
        switch (LevelIteration)
        {
            case 1:
                if (entities[0].Inventory.Count >= p1Counts && entities[1].Inventory.Count >= p2Counts)
                {
                    conditionsMet = true;
                }
                break;
            
            case 2:
                if (timesSwitch > 2)
                {
                    var player1Postion = entities[0].transform.position;
                    var player2Postion = entities[1].transform.position;
                    entities[1].transform.position = player1Postion;
                    entities[0].transform.position = player2Postion;
                    timesSwitch = 0f;
                } else if (entities[0].Inventory.Count >= p1Counts && entities[1].Inventory.Count >= p2Counts)
                {
                    conditionsMet = true;
                }
                break;
        }

        return conditionsMet;
    }
}