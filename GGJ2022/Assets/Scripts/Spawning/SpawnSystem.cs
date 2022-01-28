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
        switch (placementInfo.Type)
        {
            case SpawningPlacement.SpawnType.PLAYER:
                Vector3 position = placementInfo.transform.position;
                var prefab = Resources.Load<GameObject>($"Prefabs/Player_{placementInfo.SpecificInformation}");
                return Object.Instantiate(prefab, position, Quaternion.identity);
        }
        return null;
    }
}
