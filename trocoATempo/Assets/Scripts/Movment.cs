using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

namespace TrocoATempo
{
    public class Movment : MonoBehaviour
    {
        public float rotacaoMaxima = 15f;
        public float suavidadeRotacao = 5f;


        private Vector3 ultimaPosMouse;
        private float rotacaoAtual = 0f;
        private SpriteRenderer HandPoint;
        public SpriteRenderer ClosedHand;

        protected void changeSprite()
        {
            HandPoint.allowOcclusionWhenDynamic = false;
            ClosedHand.enabled = true;
        }

        void Start()
        {
            ultimaPosMouse = Input.mousePosition;
            HandPoint = GetComponent<SpriteRenderer>();
            ClosedHand = GetComponent<SpriteRenderer>();
            ClosedHand.enabled = false;
        }

        void Update()
        {
            // Posição do mouse no mundo
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posMouse.z = 0f;
            transform.position = posMouse;

            // Detectar movimento horizontal
            float deltaX = Input.mousePosition.x - ultimaPosMouse.x;

            if (Input.GetMouseButton(0))
            {
                changeSprite();
            }

            float alvoRotacao = Mathf.Clamp(deltaX, -1f, 1f) * rotacaoMaxima;
            rotacaoAtual = Mathf.Lerp(rotacaoAtual, alvoRotacao, Time.deltaTime * suavidadeRotacao);
            transform.rotation = Quaternion.Euler(0, 0, rotacaoAtual);

            ultimaPosMouse = Input.mousePosition;
        }
    }
}
