using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

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
        if (currentHealth <= 0) gameObject.SetActive(false);
    }
}
