using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour
{

    private PlayerHelper helper;

    private int selected = 0;

    private float startTime;


    void Start ()
    {
        helper = GetComponent<PlayerHelper>();
    }
	
	void Update ()
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

        if(Input.GetKeyDown(KeyCode.Space) && helper.spells[selected].GetComponent<SpellTemplate>().ready)
        {
            helper.spells[selected].GetComponent<SpellTemplate>().loaded = true;
            helper.spells[selected].GetComponent<SpellTemplate>().startLoadTime = Time.time;
            helper.spells[selected].transform.GetChild(0).GetComponent<Slider>().value = 0.0f;
        }

        if(helper.loadingStamina)
        {
            helper.currentStamina -= Time.deltaTime;
            helper.currentStamina = Mathf.Clamp(helper.currentStamina, 0.0f, helper.startStamina);
        }
        else if(helper.currentStamina < helper.startStamina)
        {
			helper.currentStamina += Time.deltaTime / helper.staminaRechargeRate;
			helper.staminaReady = false;
        }
        else
        {
            helper.staminaReady = true;
        }
    }

    public void DisableExcept(int index, List<GameObject> list)
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
