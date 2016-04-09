using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttacks : MonoBehaviour
{
    private PlayerHelper helper;

    private enum Weapon
    {
        Front,
        Around
    };
    
    private Weapon weapon;

    private List<GenericEnemy> inRange;

    private GameObject test;

    void Start ()
    {
        helper = GetComponent<PlayerHelper>();

        inRange = new List<GenericEnemy>();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < inRange.Count; i++)
            {
                inRange[i].health -= helper.damages;
            }
        }

        switch (weapon)
        {
            case Weapon.Front:
                helper.frontWeapon.enabled = true;
                helper.aroundWeapon.enabled = false;
                break;

            case Weapon.Around:
                helper.aroundWeapon.enabled = true;
                helper.frontWeapon.enabled = false;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GenericEnemy>() != null)
        {
            inRange.Add(other.gameObject.GetComponent<GenericEnemy>());
            other.gameObject.GetComponent<GenericEnemy>().inRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<GenericEnemy>() != null)
        {
            inRange.Remove(other.gameObject.GetComponent<GenericEnemy>());
            other.gameObject.GetComponent<GenericEnemy>().inRange = false;
        }
    }
}
