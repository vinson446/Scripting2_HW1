using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    int currentHealth;
    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    [SerializeField] int treasure;

    [SerializeField] bool isInvincible = false;

    [SerializeField] AudioClip deathSound;
    [SerializeField] float deathSoundVolume;

    BallMotor _ballMotor;

    UIManager UIManager;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();

        UIManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        currentHealth = maxHealth;

        UIManager.UpdateHealthText(currentHealth, maxHealth);
        UIManager.UpdateTreasureText(treasure);
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UIManager.UpdateHealthText(currentHealth, maxHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (!isInvincible)
        {
            currentHealth -= amount;
            UIManager.UpdateHealthText(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        if (!isInvincible)
        {
            gameObject.SetActive(false);

            UIManager.UpdateHealthText(0, maxHealth);

            Feedback();
        }
    }

    void Feedback()
    {
        // audio
        if (deathSound != null)
        {
            AudioHelper.PlayClip2D(deathSound, deathSoundVolume);
        }
    }

    public void IncreaseTreasure(int amount)
    {
        treasure += amount;
        UIManager.UpdateTreasureText(treasure);
    }

    public void SetInvincibilityStatus(bool status)
    {
        isInvincible = status;
    }
}
