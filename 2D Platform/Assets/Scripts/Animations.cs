using Personagem;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Rigidbody2D rig;
    public Animator animator;
    protected Movment movment;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movment = GetComponent<Movment>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(@$"Objeto: {collision.gameObject.name},     
               Tag:{collision.gameObject.tag}");
            animator.SetBool("animJump", false);
            animator.SetBool("animFall", false);
            animator.SetBool("animDoubleJump", false);
            animator.SetBool("animIdle", true);
        }             
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("animIdle", false);
        }
    }

    // Update is called once per frame
    public void doubleJump()
    {
        if (!movment.doubleJump && movment.isJump)//bloco double jump verdadeiro
        {
            animator.SetBool("animJump", false);
            animator.SetBool("animFall", false);
            animator.SetBool("animDoubleJump", true);
        }
        else if (rig.linearVelocity.y < 0 && !movment.doubleJump)//bloco fall double jump
        {
            animator.SetBool("animFall", true);
            animator.SetBool("animJump", false);
            animator.SetBool("animDoubleJump", false);
        }

    }
    public void ResetAnimations()
    {
        if (movment.isGround)
        {
            animator.SetBool("animJump", false);
            animator.SetBool("animFall", false);
            animator.SetBool("animDoubleJump", false);
        }


    }
    public void Jump()
    {
        if (rig.linearVelocity.y > 0 && movment.isJump)
        {
            animator.SetBool("animJump", true);

        }
        else if (rig.linearVelocity.y < 0 && movment.isJump)
        {
            animator.SetBool("animFall", true);
            animator.SetBool("animJump", false);
        }
    }
}
