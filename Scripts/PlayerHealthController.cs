using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private float invicibilityLenght;
    [SerializeField] public float invicibilityCounter;

    public static PlayerHealthController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (invicibilityCounter > 0) invicibilityCounter -= Time.deltaTime;
    }

    public void DamagePlayer() {
        if(invicibilityCounter <= 0)
        {
            invicibilityCounter = invicibilityLenght;
            currentHealth--;
            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
            if (currentHealth <= 0) gameObject.SetActive(false);

        }
    }

    public void LifeRestore()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
        }
        else print("VIDA MÁXIMA");   
    }
}
