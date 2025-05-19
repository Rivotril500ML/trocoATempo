using UnityEngine;
using UnityEngine.InputSystem;
namespace Personagem
{
    public class Movment : MonoBehaviour
    {
        //------PUBLICAS------------------
        public float velocidade, jumpForce;

        //------PRIVADAS------------------
        public Rigidbody2D rig;
        private SpriteRenderer rendererSprite;
        private Animations animator;
        protected internal bool isJump = false, doubleJump = false, isGround;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            rendererSprite = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animations>();
        }

        // Update is called once per frame
        void Update()
        {
            Run();
            Jump();
            animator.Jump();
            animator.doubleJump();
            
        }
        void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag("Ground"))
            {
                isJump = false;
                isGround = true;
            }
            if (collision.gameObject.CompareTag("Respawn"))
            {
                transform.position = new Vector3(-7.5f, -2.5f, 0);
                isJump = false;
                doubleJump = false;

            }
            Debug.Log($"{gameObject.name}");
        }
        void OnCollisionExit2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Ground"))
            {
                isJump = true;
                isGround = false;
            }
        }
        void Run()
        {
            Vector3 movimento = new Vector3(Input.GetAxisRaw("Horizontal"), 0f);
            transform.position += movimento * Time.deltaTime * velocidade;
            if (movimento.x < 0)
                rendererSprite.flipX = true;
            else
                rendererSprite.flipX = false;
        }
        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJump)
            {
                rig.AddForce(new Vector2(0f, jumpForce * 0.75f), ForceMode2D.Impulse);
                isJump = true;
                doubleJump = true;
                animator.Jump();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
            {
                rig.AddForce(new Vector2(0f, jumpForce * 1.75f), ForceMode2D.Impulse);
                doubleJump = false;
                animator.doubleJump();

            }

        }

    }

}
