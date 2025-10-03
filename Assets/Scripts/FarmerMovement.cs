using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento do fazendeiro
    private Vector3 targetPosition;  // Posi��o de destino
    private bool isMoving = false;  // Verifica se o fazendeiro est� se movendo
    public Animator animator;  // Animator para controlar anima��es (opcional)

    // Start � chamado antes da primeira atualiza��o do frame
    void Start()
    {
        targetPosition = transform.position;  // Inicializa a posi��o de destino como a posi��o atual
    }

    // Update � chamado uma vez por frame
    void Update()
    {
        // Detecta se o joystick foi movido ou se as teclas de seta s�o pressionadas
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Se o jogador movimentar, calcula a nova posi��o
        if (horizontal != 0 || vertical != 0)
        {
            targetPosition = transform.position + new Vector3(horizontal, vertical, 0f).normalized * moveSpeed * Time.deltaTime;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Se o fazendeiro estiver se movendo, aplica a transla��o
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Aqui voc� pode ativar anima��es de movimento, se tiver um Animator configurado
            if (animator != null)
            {
                animator.SetBool("isWalking", true); // Isso pressup�e que voc� tenha um par�metro 'isWalking' no seu Animator
            }
        }
        else
        {
            // Desativa a anima��o de movimento quando o fazendeiro estiver parado
            if (animator != null)
            {
                animator.SetBool("isWalking", false);
            }
        }
    }
}
