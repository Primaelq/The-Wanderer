using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PlayerHelper : MonoBehaviour
{
    // This Helper file contains all the shared methods and variables for the Player's Scripts. Also include "set in inspector" variables.

    public int startHealth = 100, damages = 10;

    public float rotateSpeed = 8.0f, walkSpeed = 5.0f, dodgeSpeed = 10.0f;

    public GameObject spellBar;

    public Collider frontWeapon, aroundWeapon;
    
    public Slider healthSlider, staminaSlider;

    public Color opaque, translucent;

    [Range(0.0f, 1.0f)]
    public float startStamina = 0.5f;

    [HideInInspector]
    public int currentHealth;

    [HideInInspector]
    public float currentStamina;

    [HideInInspector]
    public bool loadingStamina = false, staminaReady = false;

    [HideInInspector]
    public Vector3 targetPoint;

    [HideInInspector]
    public List<Transform> spells;

    void Start()
    {
        currentHealth = startHealth;

        spells = new List<Transform>();

        for (int i = 0; i < spellBar.transform.childCount; i++)
        {
            spells.Add(spellBar.transform.GetChild(i));
        }

        currentHealth = startHealth;
        healthSlider.maxValue = startHealth;
        healthSlider.value = startHealth;

        currentStamina = startStamina;
        staminaSlider.maxValue = startStamina;
        staminaSlider.value = startStamina;
    }

    void Update()
    {
        healthSlider.value = currentHealth;
        staminaSlider.value = currentStamina;
    }
}
