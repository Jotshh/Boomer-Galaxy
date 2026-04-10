using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 10f;
    public GameObject impactoDoLaserJogador;
    
    [Header("Dano")]
    public int dano = 1;

    public GameObject prefabExplosao;
    
    void Start()
    {
        Destroy(gameObject, 5f);  
    }
    
    void Update()
    {       
        MovimentarLaser();       
    }

    private void MovimentarLaser()
    {     
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Inimigo"))
        {    
            other.gameObject.GetComponent<MovimentoInimigo>().MachucarInimigo(dano);   
            Instantiate(impactoDoLaserJogador, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
}