using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PanelsManager : MonoBehaviour
{
    public List<GameObject> panels;

    public float offset;

    private int currentPanel = 0;
    
	void Start ()
    {

	}
	
	void Update ()
    {
	
	}

    public void SwitchPanel(int index)
    {
        panels[currentPanel].GetComponent<RectTransform>().anchoredPosition = new Vector3(offset, 0.0f, 0.0f);
            
        panels[index].GetComponent<RectTransform>().anchoredPosition = new Vector3(8, 0.0f, 0.0f);

        currentPanel = index;
    }
}
