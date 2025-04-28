using UnityEngine;
using TrocoATempo;
using Unity.VisualScripting;

namespace TrocoATempo
{
    public class Main : MonoBehaviour
    {
        public SacolaController sacola;
        public Sounds sound;
        
        

        void Start()
        {
            Debug.Log("Jogo iniciado.");
            sound.Iniciar();
            
        }

        void Update()
        {
            
        }

        public void ProximaFase()
        {
            Debug.Log("Indo para próxima fase...");
            sacola.EsvaziarSacola();
            // Aqui você chama o próximo cliente, etc.
        }
    }

}