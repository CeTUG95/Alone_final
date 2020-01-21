using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemyGroup : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Group");
        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(true);
            }
        }
    }
}
