using UnityEngine;

public class GeradorObjetos : MonoBehaviour
{
    public GameObject[] objetosParaSpawnar;
    public Transform[] pontosDeSpawn;
    
    public float tempoMaximoEntreSpawnarObjetos;
    public float tempoAtualDeSpawnarObjetos;

    void Start()
    {
        tempoAtualDeSpawnarObjetos = tempoMaximoEntreSpawnarObjetos;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualDeSpawnarObjetos -= Time.deltaTime;

        if (tempoAtualDeSpawnarObjetos <= 0)
        {
            SpawnarObjeto();
            
        }
    }

    private void SpawnarObjeto()
    {
        int indiceObjetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int indicePontoSpawn = Random.Range(0, pontosDeSpawn.Length);

        Instantiate(objetosParaSpawnar[indiceObjetoAleatorio], pontosDeSpawn[indicePontoSpawn].position, Quaternion.identity);
        tempoAtualDeSpawnarObjetos = tempoMaximoEntreSpawnarObjetos;
    }
}
