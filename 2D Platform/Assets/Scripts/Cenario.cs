using UnityEngine;

public class Cenario : MonoBehaviour
{
    public float velocidadeCenario;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movCenario();
    }
    private void movCenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velocidadeCenario, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;

    }
}
