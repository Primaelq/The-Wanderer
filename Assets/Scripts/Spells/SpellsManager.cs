using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellsManager : MonoBehaviour
{
    public int index;

    private PlayerHelper helper;

    private GameObject spell;

    private Slider slider;
    private SpellTemplate ST;

	void Start ()
    {
        helper = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHelper>();

        if(helper.spells[index] != null)
        {
            spell = helper.spells[index];

            ST = spell.GetComponent<SpellTemplate>();
            transform.GetComponent<Image>().sprite = ST.icon;
            slider = transform.GetChild(0).GetComponent<Slider>();
            slider.maxValue = ST.rechargeTime;
            slider.value = ST.rechargeTime;
        }
        else
        {
            Debug.Log("Error: No spell set in SpellsManager");
        }
    }
}
