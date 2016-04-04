using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttacks : MonoBehaviour
{
    public enum Weapon
    {
        Front,
        Around
    };
    
    public Weapon weapon;

    public Collider frontWeapon;
    public Collider aroundWeapon;

    private List<GenericEnemy> inRange;

    private GameObject test;

    public int damages = 10;

    private Transform arms;

    void Start ()
    {
        inRange = new List<GenericEnemy>();
        arms = transform.GetChild(0);
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < inRange.Count; i++)
            {
                inRange[i].health -= damages;
            }
            
        }

        switch (weapon)
        {
            case Weapon.Front:
                frontWeapon.enabled = true;
                aroundWeapon.enabled = false;
                break;

            case Weapon.Around:
                aroundWeapon.enabled = true;
                frontWeapon.enabled = false;
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
