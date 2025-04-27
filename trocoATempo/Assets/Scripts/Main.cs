using UnityEngine;

namespace TrocoATempo
{
    public class Main : MonoBehaviour
    {
        public SacolaController sacola;

        void Start()
        {
            Debug.Log("Jogo iniciado.");
        }

        void Update()
        {
            // Aqui você pode checar se todos produtos foram passados, etc.
        }

        public void ProximaFase()
        {
            Debug.Log("Indo para próxima fase...");
            sacola.EsvaziarSacola();
            // Aqui você chama o próximo cliente, etc.
        }
    }
}
