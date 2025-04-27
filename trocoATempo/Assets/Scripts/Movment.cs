using UnityEngine;

namespace TrocoATempo
{ 
    public class Movment : MonoBehaviour
    {
        public float rotacaoMaxima = 15f;
        public float suavidadeRotacao = 5f;

        private Vector3 ultimaPosMouse;
        private float rotacaoAtual = 0f;

        private SpriteRenderer spriteRenderer;

        void Start()
        {
            ultimaPosMouse = Input.mousePosition;
            spriteRenderer = GetComponent<SpriteRenderer>(); // pega o SpriteRenderer
        }

        void Update()
        {
            // Posição do mouse no mundo
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posMouse.z = 0f;

            transform.position = posMouse;

            // Detectar movimento horizontal
            float deltaX = Input.mousePosition.x - ultimaPosMouse.x;

            // Flip com base no movimento
            if (deltaX > 0.5f)
            {
                spriteRenderer.flipX = true;
            }
            else if (deltaX < -0.5f)
            {
                spriteRenderer.flipX = false;
            }

            
            float alvoRotacao = Mathf.Clamp(deltaX, -1f, 1f) * rotacaoMaxima;
            rotacaoAtual = Mathf.Lerp(rotacaoAtual, alvoRotacao, Time.deltaTime * suavidadeRotacao);
            transform.rotation = Quaternion.Euler(0, 0, rotacaoAtual);

            ultimaPosMouse = Input.mousePosition;
        }
    }
}
