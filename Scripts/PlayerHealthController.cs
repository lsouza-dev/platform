using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] public float invicibilityLenght;
    [SerializeField] public float invicibilityCounter;

    [Header("Sprite Variables")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color fadeColor;

    public static PlayerHealthController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (invicibilityCounter > 0)
        {
            invicibilityCounter -= Time.deltaTime;

            if (invicibilityCounter <= 0) spriteRenderer.color = normalColor;
        } 
    }

    public void DamagePlayer() {

        if (invicibilityCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
                currentHealth = 0;
            }
            else
            {
                spriteRenderer.color = fadeColor;
                invicibilityCounter = invicibilityLenght;
            }

        }
       
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
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
