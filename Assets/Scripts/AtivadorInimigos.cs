using UnityEngine;

public class AtivadorInimigos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<MovimentoInimigo>().AtivarInimigo();
        }
    }
}
