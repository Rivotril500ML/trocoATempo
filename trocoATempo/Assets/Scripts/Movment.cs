
using Unity.Mathematics;
using UnityEngine;


namespace TrocoATempo
{
    public class Movment : MonoBehaviour
    {
        public float rotacaoMaxima = 15f;
        public float suavidadeRotacao = 5f;
        public bool isFlip = false;


        private Vector3 ultimaPosMouse;
        private float rotacaoAtual = 0f;
        public GameObject ClosedHand, HandPoint, ObjectPai;


        void Start()
        {
            ultimaPosMouse = Input.mousePosition;
            ClosedHand.SetActive(false);
        }

        void Update()
        {
            CapturaMouse(isFlip, transform.localScale);

            TrocaSprite();
        }

        Vector3 CapturaMouse(bool isFlip, Vector3 vector)
        {
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posMouse.z = 0f;
            transform.position = posMouse;

            Vector3 scale = transform.localScale;
            scale.x = isFlip ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;

            Rotacao();
            return posMouse;
        }

        Vector3 Rotacao()
        {
            float deltaX = Input.mousePosition.x - ultimaPosMouse.x;

            float alvoRotacao = Mathf.Clamp(deltaX, -1f, 1f) * rotacaoMaxima;
            rotacaoAtual = Mathf.Lerp(rotacaoAtual, alvoRotacao, Time.deltaTime * suavidadeRotacao);
            transform.rotation = Quaternion.Euler(0, 0, rotacaoAtual);

            ultimaPosMouse = Input.mousePosition;
            return ultimaPosMouse;
        }

        void TrocaSprite()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandPoint.gameObject.SetActive(false);
                ClosedHand.gameObject.SetActive(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                HandPoint.gameObject.SetActive(true);
                ClosedHand.gameObject.SetActive(false);
            }
        }

    }
}

