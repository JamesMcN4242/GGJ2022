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
                conditionsMet = true;
                break;
            
            case 2:
                var player1Postion = entities[0].transform.position;
                var player2Postion = entities[1].transform.position;
                entities[1].transform.position = player1Postion;
                entities[0].transform.position = player2Postion;
                break;
        }

        return conditionsMet;
    }
}