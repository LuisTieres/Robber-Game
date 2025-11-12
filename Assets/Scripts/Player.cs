using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;

    float hInput, vInput;
    int score = 0;
    [SerializeField] private GameObject win;
    public GameObject lost;
    public int winSore;
    public Animator animator; // Referência pro Animator

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetBool("isWalking", false);
    }


    // Update is called once per frame
    void Update()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);

        bool isMoving = Mathf.Abs(joystick.Horizontal) > 0.1f || Mathf.Abs(joystick.Vertical) > 0.01f;
        animator.SetBool("isWalking", isMoving);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Carrot")
        {
            score ++;



            Destroy(collision.gameObject);

            if (score >= winSore)
            {
                win.SetActive(true);
            }

        }

        if (collision.gameObject.tag == "Fazendeiro" || collision.gameObject.tag == "Water")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
