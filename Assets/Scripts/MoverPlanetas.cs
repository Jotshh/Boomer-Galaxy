using UnityEngine;

public class MoverPlanetas : MonoBehaviour
{
    public float velocidadeDoObjeto;
    void Start()
    {
        
    }

    void Update()
    {
        MovimentarObjeto();
    }

    private void MovimentarObjeto()
    {
        transform.Translate(Vector3.down * velocidadeDoObjeto * Time.deltaTime);
    }
}
