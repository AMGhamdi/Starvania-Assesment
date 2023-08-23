using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [Tooltip("Mana is increased by one every 3 seconds\n(Meaning if you set it to 3 you will gain 1 mana each second)")]
    public float mana;
    float maxMana;
    private void Awake()
    {
        maxMana = mana;
    }
    private void Update()
    {
        if (mana <= maxMana)
        {
            mana += Time.deltaTime/3;
        }
    }
    public void DecreaseMana()
    {
        mana--;
    }
}
