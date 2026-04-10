using UnityEngine;
using UnityEngine.UI;

public class VidaJogador : MonoBehaviour
{
    public GameObject[] vidasJogador;
    public int vidaMaximaJogador = 3;
    public int vidaAtualJogador;

    [Header("Escudo")]
    public GameObject EscudoDoJogador;
    public bool EscudoAtivo;

    public int vidaMaximaEscudo;
    public int vidaAtualEscudo;

    public Slider barraDeEnergiaEscudo;

    void Start()
    {
        vidaAtualJogador = vidaMaximaJogador;
        vidaAtualEscudo = vidaMaximaEscudo;

        barraDeEnergiaEscudo.maxValue = vidaMaximaEscudo;
        barraDeEnergiaEscudo.value = vidaAtualEscudo;
        barraDeEnergiaEscudo.gameObject.SetActive(false);

        EscudoDoJogador.SetActive(false);
        EscudoAtivo = false;
    }

    public void ReceberDano(int dano)
    {
        if (EscudoAtivo == false)
        {
            vidaAtualJogador -= dano;
            vidaAtualJogador = Mathf.Clamp(vidaAtualJogador, 0, vidaMaximaJogador);

            AtualizarInterfaceVida();

            if (vidaAtualJogador <= 0)
        {
            Debug.Log("Game Over!");
            // GameManager.instance.GameOver();
        }

        }
        else
        {
            vidaAtualEscudo -= dano;    
            barraDeEnergiaEscudo.value = vidaAtualEscudo;
            if (vidaAtualEscudo <= 0)
            {               
                EscudoDoJogador.SetActive(false);
                EscudoAtivo = false;
                barraDeEnergiaEscudo.gameObject.SetActive(false);
            }
        }
        
    }

    public void AtivarEscudo()
    {      
        barraDeEnergiaEscudo.gameObject.SetActive(true);

        vidaAtualEscudo = vidaMaximaEscudo;

        barraDeEnergiaEscudo.value = vidaAtualEscudo;

        EscudoDoJogador.SetActive(true);
        EscudoAtivo = true;
    }

    public void CurarVida(int cura)
    {
        if (vidaAtualJogador + cura <= vidaMaximaJogador)
        {
            vidaAtualJogador += cura;
            AtualizarInterfaceVida();
        }     
        else
        {
            vidaAtualJogador = vidaMaximaJogador;
            AtualizarInterfaceVida();
        }

        vidaAtualJogador = Mathf.Clamp(vidaAtualJogador, 0, vidaMaximaJogador);
    }

    public void AtualizarInterfaceVida()
    {
        for (int i = 0; i < vidasJogador.Length; i++)
        {
            if (i < vidaAtualJogador)
            {
                vidasJogador[i].SetActive(true); 
            }
            else
            {
                vidasJogador[i].SetActive(false); 
            }
        }
    }

}
