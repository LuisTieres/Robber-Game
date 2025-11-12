using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public float speed = 2f;

    private Vector3[] points;
    private int currentPointIndex = 0;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // Define os pontos em volta do startPos formando um caminho
        points = new Vector3[6];
        points[0] = startPos + new Vector3(0, 1f, 0);   // cima
        points[1] = startPos + new Vector3(1f, 1f, 0);  // cima-direita
        points[2] = startPos + new Vector3(1.3f, 0, 0);   // direita
        points[3] = startPos + new Vector3(1f, 1f, 0);  // cima-direita

        points[4] = startPos + new Vector3(0, 1f, 0);   // cima
        points[5] = startPos + new Vector3(0, 0, 0);    // volta ao começo, mas andando, não teleportando
    }

    void Update()
    {
        Vector3 target = points[currentPointIndex];

        // Move em direção ao ponto atual
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Chegou no ponto? Vai para o próximo
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }
}
