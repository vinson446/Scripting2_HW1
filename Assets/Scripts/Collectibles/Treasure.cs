using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField] int treasureAmount = 1;

    protected override void Collect(Player player)
    {
        // adds to player's treasure count
        player.IncreaseTreasure(treasureAmount);
    }

    protected override void Movement(Rigidbody rb)
    {

    }
}
