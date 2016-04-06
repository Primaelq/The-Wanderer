using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellTemplate : MonoBehaviour
{
    public float chargingTime = 2.0f;
    public GameObject particleEffect;

    [HideInInspector]
    public Sprite icon;
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
        currentTime = chargingTime;
        startLoadTime = -chargingTime;

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

        if (currentTime >= chargingTime)
        {
            ready = true;
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = loadedColor;
        }
        else
        {
            ready = false;
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.white;
            transform.GetChild(0).GetComponent<Slider>().value = currentTime / chargingTime;
        }
    }
}
