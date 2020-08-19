using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);

    protected abstract void PowerDown(Player player);

    [SerializeField] float powerUpDuration;
    protected float PowerUpDuration
    {
        get => powerUpDuration;
        set => powerUpDuration = value;
    }

    [SerializeField] ParticleSystem collectParticles;
    [SerializeField] AudioClip collectSound;
    [SerializeField] float collectSoundVolume;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            Feedback();
        }
    }

    protected void DisableVisualsAndCollider()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.enabled = false;

        Collider coll = GetComponent<Collider>();
        coll.enabled = false;
    }

    protected void DisableCompletely()
    {
        Destroy(gameObject);
    }

    void Feedback()
    {
        // particles
        if (collectParticles != null)
        {
            collectParticles = Instantiate(collectParticles, transform.position, Quaternion.identity);
        }

        // audio
        if (collectSound != null)
        {
            AudioHelper.PlayClip2D(collectSound, collectSoundVolume);
        }
    }
}
