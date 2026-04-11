using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    public void ReiniciarJogo(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SairDoJogo(){
       SceneManager.LoadScene("Menu"); 
    }

}
