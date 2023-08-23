using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Tooltip("The prfab of the projectile the enemy uses")]
    [SerializeField] private GameObject projectilePrefab;
    [Tooltip("The delay between every shot")]
    [SerializeField] private float shootingTimer;

    public float timer;
    bool isShooting = false;

    private void Start()
    {
        timer = shootingTimer;
    }
    private void Update()
    {
        shooting();   
    }
    public void startShooting()
    {
        isShooting = true;
    }
    private void shooting()
    {
        timer -= Time.deltaTime;
        if (isShooting == true && timer<=0) 
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            timer = shootingTimer;
        }
    }
    public void stopShooting()
    {
        isShooting = false;
    }
}
