using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    bool eHooked = false;
    GameObject hooked_enemy;
    [SerializeField] float hookSpeed = 2;
    [SerializeField] float distanceToUnhook = 0.2f;
    Mana mana;
    void Start()
    {
        mana = GetComponent<Mana>();
    }

    void Update()
    {
        GrabEnemy();
        if (eHooked == true)
        {
            HookEnemy();
        }
            
    }
    private void HookEnemy()
    {
        hooked_enemy.transform.position = Vector3.Lerp(hooked_enemy.transform.position, transform.position, hookSpeed * Time.deltaTime);
        float distanceToPlayer = Vector3.Distance(hooked_enemy.transform.position, transform.position);
        if (distanceToPlayer <= distanceToUnhook)
        {
            eHooked = false;
        }
    }
    private void GrabEnemy()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); ;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    if (mana.mana >= 1)
                    {
                        eHooked = true;
                        hooked_enemy = hit.collider.gameObject;
                        mana.DecreaseMana();
                    }
                    
                }
            }
        }
    }
}
