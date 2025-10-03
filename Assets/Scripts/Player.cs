using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;

    float hInput, vInput;
    int score = 0;
    public GameObject winText;
    public GameObject lost;
    public int winSore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Carrot")
        {
            score ++;



            Destroy(collision.gameObject);

            if (score >= winSore)
            {
                winText.SetActive(true);
            }

        }

        if (collision.gameObject.tag == "Fazendeiro")
        {
            lost.SetActive(true);

        }
    }


}
