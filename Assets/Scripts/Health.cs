using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public void DecreaseHealth(float dmgAmount)
    {
        health -= dmgAmount;
        if (health <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                Time.timeScale = 0;
            }
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
