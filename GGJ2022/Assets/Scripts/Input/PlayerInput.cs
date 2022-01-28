using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player Input", fileName = "playerInput.asset")]
public class PlayerInput : ScriptableObject
{
    public KeyCode m_leftKey = KeyCode.A;
    public KeyCode m_rightKey = KeyCode.D;
    public KeyCode m_upKey = KeyCode.W;
    public KeyCode m_downKey = KeyCode.S;
}