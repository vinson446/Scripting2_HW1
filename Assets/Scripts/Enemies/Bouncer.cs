using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    [SerializeField] int pushForce;

    protected override void PlayerImpact(Player player)
    {
        player.DecreaseHealth(DamageAmount);

        Pushback(player);
    }

    void Pushback(Player player)
    {
        // get offset to calculate push direction
        Vector3 offset = transform.position - player.transform.position;

        // push back player in opposite direction
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.AddForce(-offset * pushForce);
    }
}
