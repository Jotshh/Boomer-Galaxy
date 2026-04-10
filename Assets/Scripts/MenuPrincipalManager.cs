using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{   
   
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene"); 
        Debug.Log("Iniciando o jogo...");
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
        Debug.Log("Abrindo opções...");
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
        Debug.Log("Fechando opções...");
    }

    public void SairJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();      
    }
}
