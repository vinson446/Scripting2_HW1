using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoBehaviour
{
    protected abstract void Collect(Player player);

    [SerializeField] float movementSpeed = 1;
    protected float MovementSpeed { get { return movementSpeed; } }

    [SerializeField] ParticleSystem collectParticles;
    [SerializeField] AudioClip collectSound;
    [SerializeField] float collectSoundVolume;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(rb);
    }

    protected virtual void Movement(Rigidbody rb)
    {
        // calculate rotation
        Quaternion turnOffset = Quaternion.Euler(0, movementSpeed, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            // spawn particles and sfx because we need to disable object
            Feedback();

            gameObject.SetActive(false);
        }
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
