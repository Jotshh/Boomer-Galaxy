using UnityEngine;

public class DestruirComTempo : MonoBehaviour
{
    public float tempoDeVida;
    void Start()
    {
        Destroy(this.gameObject, tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
