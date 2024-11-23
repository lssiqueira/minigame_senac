using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 1f;         // Velocidade de movimento para frente/trás
    public float turnSpeed = 150f;        // Velocidade de rotação (gira o tanque)
    public float maxTurnAngle = 30f;      // Ângulo máximo de rotação para limitar a direção

    public AudioSource truckSFX;

    private Rigidbody rb;
    private float moveInput;              // Entrada de movimentação vertical (W/S ou seta para cima/baixo)
    private float turnInput;              // Entrada de rotação horizontal (A/D ou seta para esquerda/direita)

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<PlayerControl>().gameManager;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.gameOn) return;

#if UNITY_EDITOR
        // Captura das entradas do usuário
        moveInput = Input.GetAxis("Vertical"); // W/S ou seta para cima/baixo
        turnInput = Input.GetAxis("Horizontal"); // A/D ou seta para esquerda/direita
        
        if (moveInput != 0 && !truckSFX.isPlaying)
            truckSFX.Play();
        else if(moveInput == 0)
            truckSFX.Stop();
#endif

        // Chama os métodos para mover e girar o tanque
        MoveTank();
        TurnTank();
    }

    public void TruckTurn(float direcao)
    {
        turnInput = direcao;
    }

    public void TruckMove(float direcao)
    {
        moveInput = direcao;

        if (moveInput == 0)
            truckSFX.Stop();
        else
            truckSFX.Play();
    }

    void MoveTank()
    {
        // Movimenta o tanque com translate
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void TurnTank()
    {
        // Rotaciona o tanque para a esquerda/direita
        float turnAmount = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
