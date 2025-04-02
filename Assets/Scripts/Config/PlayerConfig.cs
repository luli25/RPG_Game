using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float moveSpeed = 8;
    public float jumpForce = 12;
    public float dashDuration;
    public float dashTime;
    public float dashSpeed;
    public float dashCooldown;
}
