using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour
{
    List<GameObject> enemies;

	void Start ()
    {
        enemies = new List<GameObject>();
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            enemies.Add(GameObject.FindGameObjectsWithTag("Enemy")[i]);
        }
    }

	void Update ()
    {
	    
	}

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public GameObject GetNearestEnemy(Vector3 position)
    {
        GameObject nearest = new GameObject();

        for(int i = 0; i < enemies.Count - 1; i++)
        {
            nearest = Vector3.Distance(position, enemies[i].transform.position) < Vector3.Distance(position, enemies[i + 1].transform.position) ? enemies[i] : enemies[i + 1];
        }

        return nearest;
    }
}
