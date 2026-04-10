using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance;

    [Header("Audio")]

    public AudioSource MusicaFundo;
    public AudioSource MusicaGameOver;

    [Header("Pontuação")]

    public int inimigosDerrotados;
    public int pontuacaoAtual;
    public int pontuacaoPorInimigo = 10;
    
    [Header("UI")]
    public Text textoPontuacao;
    public Text textoPontuacaoFinal;

    public Text textoMelhorPontuacao;
    
    [Header("Configurações")]
    public bool salvarMelhorPontuacao = true;
    private int melhorPontuacao;
    
    public GameObject panelGameOver;
     
    
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        Time.timeScale = 1f;
        MusicaFundo.Play();
        MusicaGameOver.Stop();

        pontuacaoAtual = 0;
        textoPontuacao.text = "Pontos: " + pontuacaoAtual;
    }
    
    public void AdicionarPontos(int pontos)
    {
        pontuacaoAtual += pontos;
        textoPontuacao.text = "Pontos: " + pontuacaoAtual;
    }
    

    public void GameOver()
    {     
        Time.timeScale = 0f; 
        MusicaFundo.Stop();
        MusicaGameOver.Play();
        panelGameOver.SetActive(true);
        textoPontuacaoFinal.text = "Pontuação Final: " + pontuacaoAtual;
        Debug.Log("Game Over!");
    }
}