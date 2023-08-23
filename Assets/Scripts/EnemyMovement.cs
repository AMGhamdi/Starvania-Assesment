using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Health healthComponent;
    private Transform player;
    private Animator animator;

    [Header("Enemy Values")]
    [Tooltip("Distance at which the enemy detects the player")]
    [SerializeField] private float distToDetect;
    [Tooltip("Speed at which the enemy moves around")]
    [SerializeField] private float speed;
    [Tooltip("Time at which the enemy Randomizes the direction they move around in")]
    [SerializeField] private float randomizationTime = 2f;
    private float timer = 2f;

    private float randomDirectionY;
    private float randomDirectionX;

    private bool playerFound = false;
    private EnemyShooting projectiles;
    void Start()
    {
        healthComponent = GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        randomDirectionY = Random.Range(-1, 1);
        randomDirectionX = Random.Range(-1, 1);
        FindObjectOfType<EnemySpawner>().listOfEnemies.Add(gameObject);
        projectiles = GetComponent<EnemyShooting>();
    }

    void Update()
    {
        PlayerChase();
        Roaming();
        KeepEnemyInScreen();
        playDeathAnimation();
    }
    private void playDeathAnimation()
    {
        if (healthComponent.health <= 0)
        {
            animator.SetBool("HasDied", true);
        }
    }
    private void PlayerChase()
    {
        if (player != null)
        {
            float distanceFromPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceFromPlayer <= distToDetect)
            {
                playerFound = true;
                projectiles.startShooting();
            }
            else
            {
                projectiles.stopShooting();
                playerFound = false;
            }
        }
    }
    private void Roaming()
    {

        if (timer <= 0)
        {
            randomDirectionY = Random.Range(-1, 1);
            randomDirectionX = Random.Range(-1, 1);
            timer = randomizationTime;
        }
        if (playerFound == false)
        {
            transform.position += new Vector3(randomDirectionX*speed*Time.deltaTime , randomDirectionY*speed*Time.deltaTime , 0);
        }
        timer -= Time.deltaTime;
    }
    private void KeepEnemyInScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0)
        {
            transform.position = new Vector3(1.75f, transform.position.y);
        }
        if (screenPos.x > Screen.width)
        {
            transform.position = new Vector3(-1.75f, transform.position.y);
        }
        if (screenPos.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 1f);
        }
        if (screenPos.y > Screen.height)
        {
            transform.position = new Vector3(transform.position.x, -1f);
        }
    }
}
