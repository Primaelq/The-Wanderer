using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellTemplate : MonoBehaviour
{
    //[HideInInspector]
    public string spellName, description;
    [HideInInspector]
    public int type, damages, health;
    [HideInInspector]
    public float rechargeTime, radius, castTime;
    [HideInInspector]
    public bool zone, divideDamages;
    [HideInInspector]
    public GameObject particleEffect, prefab;
    [HideInInspector]
    public Sprite icon;
    [HideInInspector]
    public Animation loading, launching;
    [HideInInspector]
    public float startLoadTime;
    [HideInInspector]
    public bool loaded = false;
    [HideInInspector]
    public bool ready = true;

    private float currentTime;

    private Color loadedColor;

    void Start ()
    {
        currentTime = rechargeTime;
        startLoadTime = -rechargeTime;

        loadedColor = Color.green;
    }
	
	void Update ()
    {
        Recharge();

        if(loaded)
        {
            Instantiate(particleEffect, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHelper>().targetPoint, Quaternion.identity);
            loaded = false;
        }
    }

    void Recharge()
    {
        currentTime = Time.time - startLoadTime;

        if (currentTime >= rechargeTime)
        {
            ready = true;
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = loadedColor;
        }
        else
        {
            ready = false;
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.white;
            transform.GetChild(0).GetComponent<Slider>().value = currentTime / rechargeTime;
        }
    }
}
