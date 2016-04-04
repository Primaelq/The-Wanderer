using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour
{
    public int startHealth = 100;
    [HideInInspector]
    public int currentHealth;

    public Slider healthSlider;
    public Slider spellLoading;

    public List<GameObject> spells;
    public int selected = 0;

    public float loadTime = 5.0f;

    private float startTime;

    void Start ()
    {
        currentHealth = startHealth;
        healthSlider.maxValue = startHealth;
        healthSlider.value = startHealth;

        spellLoading.value = 0;

        disableExcept(selected, spells);
    }
	
	void Update ()
    {
        healthSlider.value = currentHealth;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            startTime = Time.time;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            spellLoading.value = (Time.time - startTime) / loadTime * 100;
        }

        if (Input.GetKeyUp(KeyCode.Space) || spellLoading.value >= 100)
        {
            spellLoading.value = 0;
        }
    }


    public void disableExcept(int index, List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i != index)
            {
                list[i].SetActive(false);
            }
            else
            {
                list[i].SetActive(true);
            }
        }
    }
}
