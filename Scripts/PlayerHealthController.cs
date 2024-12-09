using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        UIController.instance.UpdateHealthDisplay(currentHealth, currentHealth);
    }

    private void Update()
    {
        if (invicibilityCounter > 0)
        {
            invicibilityCounter -= Time.deltaTime;

            if (invicibilityCounter <= 0) spriteRenderer.color = normalColor;
        }

#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.H)) LifeRestore(1);
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
#endif
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

            PlayerController.instance.EndKockback();

        }
       
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
    }

    public void LifeRestore(int healthAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthAmount;
            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
        }
        else print("VIDA MÁXIMA");   
    }
}
