using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour
{
    private PlayerHelper helper;

    private int selected = 0;

    private float startTime, startLoadTime, currentTime;

    private Color loadedColor;

    void Start ()
    {
        helper = GetComponent<PlayerHelper>();
        loadedColor = Color.green;
    }
	
	void Update ()
    {
        Inputs();
        Stamina();

        for(int i = 0; i < helper.spells.Count; i++)
        {
            if(!helper.spells[i].GetComponent<SpellTemplate>().ready)
            {
                rechargeSpells(i);
            }
        }
    }

    private void Inputs()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && selected < helper.spells.Count - 1)
        {
            selected++;
            DisableExcept(selected, helper.spells);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && selected > 0)
        {
            selected--;
            DisableExcept(selected, helper.spells);
        }

        if (Input.GetKeyDown(KeyCode.Space) && helper.spells[selected].GetComponent<SpellTemplate>().ready)
        {
            helper.spells[selected].GetComponent<SpellTemplate>().loaded = true;
            helper.spells[selected].GetComponent<SpellTemplate>().ready = false;
            startLoadTime = Time.time;
            helper.spells[selected].GetChild(0).GetComponent<Slider>().value = 0.0f;
        }
    }

    private void rechargeSpells(int i)
    {
        currentTime = Time.time - startLoadTime;

        if (currentTime >= helper.spells[i].GetComponent<SpellTemplate>().rechargeTime)
        {
            helper.spells[i].GetComponent<SpellTemplate>().ready = true;
            helper.spells[i].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = loadedColor;
        }
        else
        {
            helper.spells[i].GetComponent<SpellTemplate>().ready = false;
            helper.spells[i].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.white;
            helper.spells[i].transform.GetChild(0).GetComponent<Slider>().value = currentTime / helper.spells[i].GetComponent<SpellTemplate>().rechargeTime;
        }
    }

    private void Stamina()
    {
        if (helper.loadingStamina)
        {
            helper.currentStamina -= Time.deltaTime;
            helper.currentStamina = Mathf.Clamp(helper.currentStamina, 0.0f, helper.startStamina);
        }
        else if (helper.currentStamina < helper.startStamina)
        {
            helper.currentStamina += Time.deltaTime;
            helper.staminaReady = false;
        }
        else
        {
            helper.staminaReady = true;
        }
    }

    public void DisableExcept(int index, List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i != index)
            {
                list[i].GetComponent<Image>().color = helper.translucent;
            }
            else
            {
                list[i].GetComponent<Image>().color = helper.opaque;
            }
        }
    }
}
