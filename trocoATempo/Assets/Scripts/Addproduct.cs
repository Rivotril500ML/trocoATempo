using TrocoATempo;
using UnityEngine;

public class Produto : MonoBehaviour
{
    private SacolaController bag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SacolaController>() != null)
        {
            other.GetComponent<SacolaController>().AdicionarProduto(this.gameObject);
        }
    }
}
