using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private float invicibilityLenght;
    [SerializeField] private float invicibilityCounter;

    public static PlayerHealthController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DamagePlayer() {
        currentHealth--;
        UIController.instance.UpdateHealthDisplay(currentHealth,maxHealth);
        if (currentHealth <= 0) gameObject.SetActive(false);
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
