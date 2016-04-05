using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour
{
    public int startHealth = 100;
    [Range(0.0f, 1.0f)]
    public float startStamina = 0.5f; // This should de set in seconds
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public float currentStamina;
    [HideInInspector]
    public float staminaTime = 0.0f;

    public Slider healthSlider;
    public Slider staminaSlider;

    public GameObject spellBar;
    public List<Transform> spells;
    public int selected = 0;

    public float loadTime = 5.0f;

    public Color highlight;
    public Color dark;

    private float startTime;

    void Start ()
    {
        currentHealth = startHealth;
        healthSlider.maxValue = startHealth;
        healthSlider.value = startHealth;

        currentStamina = startStamina;
        staminaSlider.maxValue = startStamina;
        staminaSlider.value = startStamina;

        spells = new List<Transform>();

        for(int i = 0; i < spellBar.transform.childCount; i++)
        {
            spells.Add(spellBar.transform.GetChild(i));
        }

        disableExcept(selected, spells);
    }
	
	void Update ()
    {
        healthSlider.value = currentHealth;
        staminaSlider.value = currentStamina;

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && selected < spells.Count - 1)
        {
            selected++;
            disableExcept(selected, spells);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && selected > 0)
        {
            selected--;
            disableExcept(selected, spells);
        }

        if(Input.GetKeyDown(KeyCode.Space) && spells[selected].GetComponent<SpellTemplate>().ready)
        {
            spells[selected].GetComponent<SpellTemplate>().loaded = true;
            spells[selected].GetComponent<SpellTemplate>().startLoadTime = Time.time;
            spells[selected].GetChild(0).GetComponent<Slider>().value = 0.0f;
        }

        if(!transform.GetComponent<PlayerController>().loadingStamina && currentStamina < startStamina)
        {
            currentStamina += Time.time;
        }

        if(transform.GetComponent<PlayerController>().loadingStamina)
        {
            currentStamina -= Mathf.Clamp(Time.time - staminaTime, 0.0f, startStamina); 
        }
        else if(currentStamina < startStamina)
        {
            currentStamina += Time.time;
        }
    }

    public void disableExcept(int index, List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i != index)
            {
                list[i].GetComponent<Image>().color = dark;
            }
            else
            {
                list[i].GetComponent<Image>().color = highlight;
            }
        }
    }
}
