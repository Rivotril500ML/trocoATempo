using System.Collections.Generic;
using UnityEngine;

namespace TrocoATempo
{
    public class SacolaController : MonoBehaviour
    {
        public Transform[] posicoesEmpilhamento;
        private List<GameObject> produtosNaSacola = new List<GameObject>();
        private int indexAtual = 0;

        public void AdicionarProduto(GameObject produto)
        {
            if (indexAtual >= posicoesEmpilhamento.Length) return;

            produto.transform.SetParent(transform);
            produto.transform.position = posicoesEmpilhamento[indexAtual].position;
            produto.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            produtosNaSacola.Add(produto);
            indexAtual++;
        }

        public void EsvaziarSacola()
        {
            foreach (var produto in produtosNaSacola)
            {
                Destroy(produto);
            }
            produtosNaSacola.Clear();
            indexAtual = 0;
        }
    }
}
