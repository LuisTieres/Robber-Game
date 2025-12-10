using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

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
        //animator.SetBool("isWalking", false);
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
                transform.Translate(0, 0, 0);
                win.SetActive(true);


                Scene currentScene = SceneManager.GetActiveScene();
                if (currentScene.name == "Casa")
                {
                    int novo = StaticData.scorekeep + score;  

                    if (!PlayerPrefs.HasKey("WinTime") || novo > PlayerPrefs.GetInt("WinTime"))
                    {
                        PlayerPrefs.SetInt("WinTime", novo);
                        PlayerPrefs.Save();
                        Debug.Log("Novo recorde salvo: " + novo);
                    }
                }
            }

        }

        if (collision.gameObject.tag == "Fazendeiro")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.tag == "exc")
        {
            StaticData.scorekeep = score;

            SceneManager.LoadSceneAsync("Casa");
        }
    }


}
