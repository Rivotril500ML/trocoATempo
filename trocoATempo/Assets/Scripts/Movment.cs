using System.Threading.Tasks;
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
        public GameObject ClosedHand, HandPoint;

        void Start()
        {
            ultimaPosMouse = Input.mousePosition;
        }

        async Task Update()
        {
            // Posição do mouse no mundo
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posMouse.z = 0f;
            transform.position = posMouse;

            // Detectar movimento horizontal
            float deltaX = Input.mousePosition.x - ultimaPosMouse.x;

            if (Input.GetMouseButtonDown(0))
            {
                HandPoint.gameObject.SetActive(false);
                ClosedHand.gameObject.SetActive(true);
            }
            if(Input.GetMouseButtonUp(0)){
                HandPoint.gameObject.SetActive(true);
                ClosedHand.gameObject.SetActive(false);
            }

            float alvoRotacao = Mathf.Clamp(deltaX, -1f, 1f) * rotacaoMaxima;
            rotacaoAtual = Mathf.Lerp(rotacaoAtual, alvoRotacao, Time.deltaTime * suavidadeRotacao);
            transform.rotation = Quaternion.Euler(0, 0, rotacaoAtual);

            ultimaPosMouse = Input.mousePosition;
        }
    }
}
