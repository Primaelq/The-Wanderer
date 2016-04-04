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

    public List<GameObject> spells;
    public int selected = 0;

    void Start ()
    {
        currentHealth = startHealth;
        healthSlider.maxValue = startHealth;
        healthSlider.value = startHealth;

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
