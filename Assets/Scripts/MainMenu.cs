using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject score;

    [SerializeField] private GameObject btnscore;
    [SerializeField] private GameObject btnplay;
    [SerializeField] private ScrollViewFiller scrollFiller;
    [SerializeField] private GameObject btnvolta;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void Score()
    {
        score.SetActive(true);
        btnscore.SetActive(false);
        btnplay.SetActive(false);
        btnvolta.SetActive(true);

        scrollFiller.RefreshScroll();   // ⬅️ Atualiza o texto aqui

        Time.timeScale = 0;
    }
    public void voltar()
    {
        score.SetActive(false);
        btnscore.SetActive(true);
        btnplay.SetActive(true);
        btnvolta.SetActive(false);


        Time.timeScale =1;
    }
}
