using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class SpawnSystem
{
    public static GameObject[] SpawnAllFindableEntities()
    {
        var spawnLocations = Object.FindObjectsOfType<SpawningPlacement>();
        GameObject[] objects = Array.ConvertAll(spawnLocations, input => SpawnObject(input));
        return objects;
    }

    public static GameObject SpawnObject(SpawningPlacement placementInfo)
    {
        Vector3 position = placementInfo.transform.position;
        
        switch (placementInfo.Type)
        {
            case SpawningPlacement.SpawnType.PLAYER:
            {
                var prefab = Resources.Load<GameObject>($"Prefabs/Player_{(placementInfo.SpecificInformation + WorldFlags.ResetValue) % 2 + 1}");
                return Object.Instantiate(prefab, position, Quaternion.identity);
            }

            case SpawningPlacement.SpawnType.ENEMY:
            {
                var prefab = Resources.Load<GameObject>($"Prefabs/Enemies/Enemy{placementInfo.SpecificInformation}");
                return Object.Instantiate(prefab, position, Quaternion.identity);
            }
        }
        return null;
    }
}
