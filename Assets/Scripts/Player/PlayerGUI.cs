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
            spells[selected].GetComponent<SpellTemplate>().loaded = true;
            spells[selected].GetComponent<SpellTemplate>().startLoadTime = Time.time;
            spells[selected].GetChild(0).GetComponent<Slider>().value = 0.0f;
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
