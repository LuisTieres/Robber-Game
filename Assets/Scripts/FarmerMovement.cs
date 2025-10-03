using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento do fazendeiro
    private Vector3 targetPosition;  // Posição de destino
    private bool isMoving = false;  // Verifica se o fazendeiro está se movendo
    public Animator animator;  // Animator para controlar animações (opcional)

    // Start é chamado antes da primeira atualização do frame
    void Start()
    {
        targetPosition = transform.position;  // Inicializa a posição de destino como a posição atual
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Detecta se o joystick foi movido ou se as teclas de seta são pressionadas
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Se o jogador movimentar, calcula a nova posição
        if (horizontal != 0 || vertical != 0)
        {
            targetPosition = transform.position + new Vector3(horizontal, vertical, 0f).normalized * moveSpeed * Time.deltaTime;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Se o fazendeiro estiver se movendo, aplica a translação
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Aqui você pode ativar animações de movimento, se tiver um Animator configurado
            if (animator != null)
            {
                animator.SetBool("isWalking", true); // Isso pressupõe que você tenha um parâmetro 'isWalking' no seu Animator
            }
        }
        else
        {
            // Desativa a animação de movimento quando o fazendeiro estiver parado
            if (animator != null)
            {
                animator.SetBool("isWalking", false);
            }
        }
    }
}
