using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float speedAmount = 5;

    protected override void Collect(Player player)
    {
        // pull motor from the player
        BallMotor motor = player.GetComponent<BallMotor>();
        if (motor != null)
        {
            motor.MaxSpeed += speedAmount;
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
