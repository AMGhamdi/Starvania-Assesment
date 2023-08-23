using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI mana;
    public TextMeshProUGUI timerText;

    private Mana playerMana;
    private Health playerHealth;
    public float timer = 60;
    void Start()
    {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        mana.text = playerMana.mana.ToString("F0");
        health.text = playerHealth.health.ToString("F0");
        if (timer >= 0)
        {
            timerText.text = timer.ToString("F0");
        }
        
        timer -= Time.deltaTime;
    }
}
