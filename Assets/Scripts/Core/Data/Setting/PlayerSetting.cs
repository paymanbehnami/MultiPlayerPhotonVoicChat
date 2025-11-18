using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Setting")]
public class PlayerSetting : ScriptableObject
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float turnSpeed = 200f;
}
