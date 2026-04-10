using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public GameObject laserDoInimigo;
    public Transform localDoDisparoInimigo;

    [Header("Drop de Itens")]
    public GameObject itemDropar;
    public int chanceDroparItem;

    public float tempoEntreTiros;
    public float tempoAtualdosLasers;

    public bool inimigoAtirador;
    public bool inimigoAtivado;

    [Header("Movimento")]
    public float velocidade = 2f;

    [Header("Vida")]
    public int vidaMaximaInimigo;

    public int vidaAtualInimigo;
    
    [Header("Efeitos")]
    public GameObject prefabExplosao;
    
    [Header("Pontuação do Inimigo")]
    public int pontosPorMorte = 100;
    
    private GameObject alvo;
    
    void Start()
    {
        inimigoAtivado = false;
        vidaAtualInimigo = vidaMaximaInimigo;

        alvo = GameObject.FindGameObjectWithTag("Player");
        if (alvo == null)
        {
            alvo = GameObject.Find("Player");
        }
    }
    
    void Update()
    {
        movimentarInimigo();

        if (inimigoAtirador == true && inimigoAtivado == true)
        {
            AtirarLaserInimigo();
        }
    }

    public void AtivarInimigo()
    {
        inimigoAtivado = true;
    }

    private void movimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);
    }

    public void AtirarLaserInimigo()
    {   
        tempoAtualdosLasers -= Time.deltaTime;
        if (tempoAtualdosLasers <= 0)
        {
            Instantiate(laserDoInimigo, localDoDisparoInimigo.position, Quaternion.Euler(0, 0, 180));
            tempoAtualdosLasers = tempoEntreTiros;
        }
    }

    public void MachucarInimigo(int dano)
    {
        vidaAtualInimigo -= dano;

        if (vidaAtualInimigo <= 0)
        {
            
            Instantiate(prefabExplosao, transform.position, Quaternion.identity);
            GameManager.instance.AdicionarPontos(pontosPorMorte);

            int numeroAleatorio = Random.Range(0, 100);

            if (numeroAleatorio <= chanceDroparItem)
            {
                Instantiate(itemDropar, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }

}