using UnityEngine;

public class CriadorDeInimigos : MonoBehaviour
{
    [Header("Prefab do Inimigo")]
    public GameObject inimigoPrefab; 
    
    [Header("Tempo entre Spawns")]
    public float tempoMinimo = 1f;
    public float tempoMaximo = 3f;
    
    [Header("Posição de Spawn")]
    public float alturaSpawn = 6f;     
    public float limiteEsquerdo = -8f; 
    public float limiteDireito = 8f;   
    
    private float timer;
    
    void Start()
    {
        timer = Random.Range(tempoMinimo, tempoMaximo);
        if (inimigoPrefab == null)
        {
            Debug.LogError("ERRO: Arraste o prefab do inimigo para o campo 'Inimigo Prefab' no Inspector!");
        }
    }
    
    void Update()
    {
        if (inimigoPrefab == null) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            CriarInimigo();
            timer = Random.Range(tempoMinimo, tempoMaximo);
        }
    }
    
    void CriarInimigo()
    {
        float posX = Random.Range(limiteEsquerdo, limiteDireito);
        Vector2 posicao = new Vector2(posX, alturaSpawn);
        GameObject novoInimigo = Instantiate(inimigoPrefab, posicao, Quaternion.identity);
        Debug.Log($"Inimigo criado na posição: X={posX}, Y={alturaSpawn}");
    }
}