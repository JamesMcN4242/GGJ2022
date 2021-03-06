using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public Camera PlayerCamera;
    public Character CharacterData;
    public PlayerInput PlayerInputs;
    public HashSet<String> Inventory;
    public String Ability;
    public int actionCounter; 
    public static PlayerEntity CreatePlayerEntity(GameObject playerObj, int playerNumber)
    {
        Camera playerCamera = new GameObject($"Player{playerNumber}_Camera").AddComponent<Camera>();
        playerCamera.rect = new Rect(0.5f * (playerNumber - 1), 0f, 0.5f, 1f);
        playerCamera.backgroundColor = (playerNumber + WorldFlags.ResetValue) % 2 == 0 ? Color.cyan : Color.grey;
        playerCamera.clearFlags = CameraClearFlags.SolidColor; //TODO: Skyboxes if possible time wise

        PlayerEntity entity = playerObj.AddComponent<PlayerEntity>();
        entity.CharacterData = Resources.Load<Character>("Data/characterInput");
        entity.PlayerInputs = Resources.Load<PlayerInput>($"Data/player{playerNumber}Input");
        entity.PlayerCamera = playerCamera;
        entity.Inventory = new HashSet<string>();
        entity.Ability = playerNumber == 1 ? "DoubleJump" : "Shoot";
        entity.actionCounter = 0;
        return entity;
    }
}
