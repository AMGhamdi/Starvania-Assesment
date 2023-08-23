using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Door door;
    UI timer;
    public GameObject opendChest;
    void Start()
    {
        timer = FindObjectOfType<UI>();
        door = FindObjectOfType<Door>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer.timer <= 0 && collision.gameObject.CompareTag("Player"))
        {
            opendChest.SetActive(true);
            door.Escape();
            gameObject.SetActive(false);
        }
    }
}
