using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace P1
{
    public class Mov : MonoBehaviour
    {
        //publicas***----------------------------------------------------------------------------------
        public float vel;
        public float jumpForce;
        public TilemapCollider2D tilemapCollider2D;

        //privadas-------------------------------------------------------------------------------------
        private bool isJump, doubleJump;
        private Rigidbody2D _rig;
        private SpriteRenderer _renderer;
        private Animator _animator;
        private string estado;

        //inicio do código
        void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rig = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            run();
            Jump();
            Debug.Log("Teste");
        }

        void run()
        {
            Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0f);
            transform.position += mov * Time.deltaTime * vel;

            if (mov.x != 0)
            {
                _renderer.flipX = mov.x < 0;
            }
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = false;
                if (Input.GetKeyDown(KeyCode.Space)){
                    
                }
            }
            bool Jumping(bool _verJump){
                void OnCollisionEnter2D(Collision2D collision){
                    return _verJump =true;
                }
            }

            if (!isJump)
            {
                _rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    _rig.AddForce(new Vector2(0f, jumpForce * 1.25f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"Colidido com {gameObject}");
            if (collision.gameObject.layer == 7)
            {
                isJump = true;
                doubleJump = false;
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            other.collider.forceReceiveLayers = 7;
        }

    }
}
