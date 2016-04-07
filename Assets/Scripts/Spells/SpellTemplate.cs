using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellTemplate : MonoBehaviour
{
    //[HideInInspector]
    public string spellName, description;
    //[HideInInspector]
    public int type, damages, health;
    //[HideInInspector]
    public float rechargeTime, radius, castTime;
    //[HideInInspector]
    public bool zone, divideDamages, useMousePosition;
    //[HideInInspector]
    public GameObject particleEffect, prefab;
    //[HideInInspector]
    public Sprite icon;
    //[HideInInspector]
    public Animation loading, launching;
    
    [HideInInspector]
    public bool loaded = false;
    [HideInInspector]
    public bool ready = true;

    private GameObject render;

    void Start ()
    {

    }
	
	void Update ()
    {
        if(loaded)
        {
            if(particleEffect != null)
                render = Instantiate(particleEffect, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHelper>().targetPoint, Quaternion.identity) as GameObject;
            loaded = false;
        }
    }

    void MousePos()
    {
        render.transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHelper>().targetPoint;
    }
}
