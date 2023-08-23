using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player Offensive Values")]
    [Tooltip("The amount of damage the player deals")]
    [SerializeField] private float damage = 1;
    [Tooltip("Distance at which the player can damage the enemy")]
    [SerializeField] float distanceToDamage;

    private ArrayList listOfEnemies;
    private void Start()
    {
        listOfEnemies = FindObjectOfType<EnemySpawner>().listOfEnemies;    
    }
    void Update()
    {
        if (listOfEnemies.Count > 0)
        {
            //foreach (GameObject enemy in listOfEnemies)
            for(int i = 0;i< listOfEnemies.Count;i++)
            {
                if (listOfEnemies[i] != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, ((GameObject)listOfEnemies[i]).transform.position);
                    if (distanceToEnemy <= distanceToDamage)
                    {
                        if (Input.GetMouseButton(0))
                        {
                            Health eHealth = ((GameObject)listOfEnemies[i]).GetComponent<Health>();
                            eHealth.DecreaseHealth(damage);
                            if (eHealth.health <= 0)
                            {
                                listOfEnemies.Remove(listOfEnemies[i]);
                            }
                        }
                    }
                }
                else
                {
                    listOfEnemies.Remove(listOfEnemies[i]);
                }
            }
        }
    }
}
