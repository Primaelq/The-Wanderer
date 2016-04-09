using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellsManager : MonoBehaviour
{
    public GameObject spell;

    private Slider slider;
    private SpellTemplate ST;

	void Start ()
    {
        if(spell != null)
        {
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
