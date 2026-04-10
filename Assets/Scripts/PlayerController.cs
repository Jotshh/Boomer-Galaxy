using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D oRigidbody2d;

    [Header("Laser")]
    public GameObject laserDoPlayer;
    public Transform LocalDoDisparoUnico;

    [Header("Laser Duplo")]

    public Transform LocalDoDisparoEsquerdo;
    public Transform LocalDoDisparoDireito;
    public float tempoMaximoLaserDuplo;
    public float tempoAtualdosLaserDuplo;

    public float tempoEntreDisparos = 0.4f;
    private float tempoProximoLaser = 0f;

    public bool temLaserDuplo;

    [Header("Movimento")]
    public float velocidade = 5f;

    private Vector2 movimentoInput;

    void Start()
    {
        temLaserDuplo = false;

        tempoAtualdosLaserDuplo = tempoMaximoLaserDuplo;
    }

    void Update()
    {
        Movimentar();
        AtirarLaserJogador();

        if (temLaserDuplo == true)
        {
            tempoAtualdosLaserDuplo -= Time.deltaTime;
            if (tempoAtualdosLaserDuplo <= 0)
            {
                DesativarLaserDuplo();
            }
        }   
    }

    private void FixedUpdate()
    {
        oRigidbody2d.linearVelocity = movimentoInput.normalized * velocidade;
    }

    private void Movimentar()
    {

        Vector2 teclado = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) teclado.y = 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) teclado.y = -1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) teclado.x = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) teclado.x = 1;
        }

        movimentoInput = teclado;
    }

    private void AtirarLaserJogador()
    {
        if (Keyboard.current.spaceKey.isPressed && Time.time >= tempoProximoLaser)
        {
            tempoProximoLaser = Time.time + tempoEntreDisparos;

            if (temLaserDuplo == false)
            {
                Instantiate(laserDoPlayer, LocalDoDisparoUnico.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laserDoPlayer, LocalDoDisparoEsquerdo.position, Quaternion.identity);
                Instantiate(laserDoPlayer, LocalDoDisparoDireito.position, Quaternion.identity);
            }

            EfeitosSonoros.instance.somLaserJogador.Play();
        }
    }

    private void DesativarLaserDuplo()

    {
        temLaserDuplo = false;
        tempoAtualdosLaserDuplo = tempoMaximoLaserDuplo;
    }

}