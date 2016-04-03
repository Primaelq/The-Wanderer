using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    public int startHealth = 100;
    [HideInInspector]
    public int currentHealth;

    public Slider healthSlider;

	void Start ()
    {
        currentHealth = startHealth;
        healthSlider.maxValue = startHealth;
        healthSlider.value = startHealth;
    }
	
	void Update ()
    {
        healthSlider.value = currentHealth;
    }
}
