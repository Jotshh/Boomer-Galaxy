using UnityEngine;

public class Explosao : MonoBehaviour
{
    [Header("Configurações")]
    public float tempoDeVida = 0.2f; 
    
    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }
}   