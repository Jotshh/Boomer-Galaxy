using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    public float velocidadeDoLaser;
    public int danoDoLaser;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimentarLaserInimigo();
    }

    private void movimentarLaserInimigo()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<VidaJogador>().ReceberDano(danoDoLaser);
            Destroy(this.gameObject);
        }
    }
}
