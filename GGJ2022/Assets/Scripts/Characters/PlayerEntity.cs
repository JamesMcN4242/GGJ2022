using System;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerEntity
{
    public Camera PlayerCamera;
    public GameObject GameObj;
    public Character CharacterData;
    public PlayerInput PlayerInputs;
    public HashSet<String> Inventory;

    public static PlayerEntity CreatePlayerEntity(GameObject playerObj, int playerNumber)
    {
        Camera playerCamera = new GameObject($"Player{playerNumber}_Camera").AddComponent<Camera>();
        playerCamera.rect = new Rect(0.5f * (playerNumber - 1), 0f, 0.5f, 1f);
        playerCamera.backgroundColor = playerNumber == 1 ? Color.cyan : Color.grey;
        playerCamera.clearFlags = CameraClearFlags.SolidColor; //TODO: Skyboxes if possible time wise
        
        return new PlayerEntity()
        {
            GameObj = playerObj,
            CharacterData = Resources.Load<Character>("Data/characterInput"),
            PlayerInputs = Resources.Load<PlayerInput>($"Data/player{playerNumber}Input"),
            PlayerCamera = playerCamera
        };
    }
}
