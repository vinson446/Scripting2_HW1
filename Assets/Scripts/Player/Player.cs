using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    //TODO- offload health into a Health.cs script
    [SerializeField] int maxHealth = 3;
    int currentHealth;

    BallMotor _ballMotor;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player's health: " + currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player's health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);

        // play particles
        // play sounds
    }
}
