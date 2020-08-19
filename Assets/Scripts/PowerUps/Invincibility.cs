using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Color powerUpColor;
    Color originalColor;

    protected override void PowerUp(Player player)
    {
        ChangePlayerColor(player);
        EnableInvincibility(player, true);

        DisableVisualsAndCollider();

        StartCoroutine(PowerUpCoroutine(player));
    }

    IEnumerator PowerUpCoroutine(Player player)
    {
        yield return new WaitForSeconds(PowerUpDuration);

        PowerDown(player);
    }

    protected override void PowerDown(Player player)
    {
        RevertPlayerColor(player);
        EnableInvincibility(player, false);

        DisableCompletely();
    }

    void EnableInvincibility(Player player, bool status)
    {
        player.SetInvincibilityStatus(status);
    }

    void ChangePlayerColor(Player player)
    {
        MeshRenderer mr = player.GetComponent<MeshRenderer>();

        // save player's original color to revert back to later
        originalColor = mr.material.color;

        // change player's color
        mr.material.color = powerUpColor;
    }

    void RevertPlayerColor(Player player)
    {
        MeshRenderer mr = player.GetComponent<MeshRenderer>();

        // revert player's color
        mr.material.color = originalColor;
    }
}
