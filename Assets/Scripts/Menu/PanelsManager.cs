using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PanelsManager : MonoBehaviour
{
    public List<GameObject> panels;

    public GameObject planet;

    public float offset;

    private int currentPanel = 0;

    private Vector3 enabledPosition;
    private Vector3 planetStartPos;
    
	void Start ()
    {
        enabledPosition = panels[0].GetComponent<RectTransform>().anchoredPosition;

        planetStartPos = planet.transform.position;
    }
	
	void Update ()
    {

	}

    public void SwitchPanel(int index)
    {
        if(index != currentPanel)
        {
            StartCoroutine(Slide(currentPanel, new Vector3(offset, 0.0f, 0.0f), 1.5f));

            if (currentPanel == 0)
            {
                StartCoroutine(MovePlanet(new Vector3(20.0f, planetStartPos.y, 0.0f), 0.5f));
            }
            else if (index == 0)
            {
                StartCoroutine(MovePlanet(planetStartPos, 1.5f));
            }

            StartCoroutine(Slide(index, enabledPosition, 1.5f));

            currentPanel = index;
        }
    }

    IEnumerator Slide(int index, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            panels[index].GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(panels[index].GetComponent<RectTransform>().anchoredPosition, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        panels[index].GetComponent<RectTransform>().anchoredPosition = target;
    }

    IEnumerator MovePlanet(Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            planet.transform.position = Vector3.Lerp(planet.transform.position, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        planet.transform.position = target;
    }
}
