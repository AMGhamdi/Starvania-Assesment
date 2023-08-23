using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorOpen;
    public bool canEscape = false;
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canEscape == true && collision.gameObject.CompareTag("Player"))
        {
            doorOpen.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void Escape()
    {
        canEscape = true;
    }
}
