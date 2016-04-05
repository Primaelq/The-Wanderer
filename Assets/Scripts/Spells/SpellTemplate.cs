using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellTemplate : MonoBehaviour
{
    public float chargingTime = 2.0f;
    public int damages = 10;
    public GameObject prefab;

    public Color loadedColor;

    [HideInInspector]
    public float startLoadTime;
    public bool loaded = false;
    public bool ready = true;

    private float currentTime;
    
	void Start ()
    {
        currentTime = chargingTime;
        startLoadTime = -chargingTime;
    }
	
	void Update ()
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

        if(loaded)
        {
            Instantiate(prefab, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().targetPoint, Quaternion.identity);
            loaded = false;
        }
    }
}
