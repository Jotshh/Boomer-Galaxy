using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    [Header("Itens de Vida")]
    public bool itemEscudo;
    public bool itemVida;
    public bool itemTiroDuplo;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (itemVida == true)
            {
                VidaJogador vidaJogador = other.GetComponent<VidaJogador>();
                if (vidaJogador != null)
                {
                    vidaJogador.vidaAtualJogador += 1;
                    vidaJogador.vidaAtualJogador = Mathf.Clamp(vidaJogador.vidaAtualJogador, 0, vidaJogador.vidaMaximaJogador);
                    vidaJogador.AtualizarInterfaceVida();
                }
            }

            if (itemEscudo == true)
            {
                other.gameObject.GetComponent<VidaJogador>().AtivarEscudo();
            }

            if (itemTiroDuplo == true)
            {
                other.gameObject.GetComponent<PlayerController>().temLaserDuplo = false;

                other.gameObject.GetComponent<PlayerController>().tempoAtualdosLaserDuplo = other.gameObject.GetComponent<PlayerController>().tempoMaximoLaserDuplo;
                
                other.gameObject.GetComponent<PlayerController>().temLaserDuplo = true;
            }

            Destroy(gameObject);
        }
    }
    
}
