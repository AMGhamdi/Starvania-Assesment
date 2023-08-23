using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Values")]
    [Tooltip("Speed at which the player Moves")]
    [SerializeField] private float speed = 0.1f;
    

    Animator animator;
    SpriteRenderer sprite;
    float horizontal;
    float vertical;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        KeepPlayerInScreen();
        MovePlayer();
        PlayAnimations();
        Attacking();
    }
    private void MovePlayer()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(horizontal, vertical, 0);
    }
    private void KeepPlayerInScreen()
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
    private void PlayAnimations()
    {
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        if (horizontal > 0)
        {
            animator.SetBool("Horizontal", true);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("Horizontal", true);
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
            animator.SetBool("Horizontal", false);
        }
    }
    private void Attacking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attacking", true);
            StartCoroutine(EndAttack());
        }
    }
    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Attacking", false);
    }

}
