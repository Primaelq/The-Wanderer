using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PanelsManager : MonoBehaviour
{
    public List<GameObject> panels;

    public float offset;

    private int currentPanel = 0;

    private Vector3 enabledPosition;
    
	void Start ()
    {
        enabledPosition = panels[0].GetComponent<RectTransform>().anchoredPosition;
    }
	
	void Update ()
    {
	    
	}

    public void SwitchPanel(int index)
    {
        panels[currentPanel].GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(panels[currentPanel].GetComponent<RectTransform>().anchoredPosition, new Vector3(offset, 0.0f, 0.0f), 0.8f);

        panels[index].GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(panels[index].GetComponent<RectTransform>().anchoredPosition, enabledPosition, 0.8f);

        currentPanel = index;
    }
}
