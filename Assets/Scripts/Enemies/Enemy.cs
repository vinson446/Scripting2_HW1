using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    protected int DamageAmount
    {
        get => damageAmount;
        set => damageAmount = value;
    }

    [SerializeField] ParticleSystem impactParticles;
    [SerializeField] AudioClip impactSound;
    [SerializeField] float impactSoundVolume;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PlayerImpact(player);
            ImpactFeedback();
        }
    }

    protected virtual void PlayerImpact(Player player)
    {
        player.DecreaseHealth(damageAmount);
    }

    void ImpactFeedback()
    {
        // particles
        if (impactParticles != null)
        {
            impactParticles = Instantiate(impactParticles, transform.position, Quaternion.identity);
        }

        // audio
        if (impactSound != null)
        {
            AudioHelper.PlayClip2D(impactSound, impactSoundVolume);
        }
    }
}
