using UnityEngine;

public class CenarioInfinito : MonoBehaviour
{
    public float velocidadeDoCenario;
    void Update()
    {
        MovimentarCenario();
    }

    private void MovimentarCenario()
    {
        Vector2 deslocamentoDoCenario = new Vector2(0f, velocidadeDoCenario * Time.deltaTime);
        GetComponent<Renderer>().material.mainTextureOffset += deslocamentoDoCenario;
    }
}
