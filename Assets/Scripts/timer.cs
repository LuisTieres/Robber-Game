using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public GameObject timeover;
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime; 
        countdownText.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0;
            timeover.SetActive(true);

        }
    }

    public void restart()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
