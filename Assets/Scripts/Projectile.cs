using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Tooltip("The speed at which the projectile moves")]
    [SerializeField] private float projectileSpeed;
    private Transform player;
    [Tooltip("The damage dealt by the projectile")]
    [SerializeField] private float damage = 1f;

    [Tooltip("The time that the projectile stays on the map before it is destroyed")]
    [SerializeField] private float timeBeforeDestroy = 1f;
    private float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = timeBeforeDestroy;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, projectileSpeed * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().DecreaseHealth(damage);
            Destroy(gameObject);
            
        }
    }
}
