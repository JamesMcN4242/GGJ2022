using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character Input", fileName = "characterInput.asset")]
public class Character : ScriptableObject
{
    public float speed = 2;
    public float jumpHeight = 2;
    public float health = 100;
}
