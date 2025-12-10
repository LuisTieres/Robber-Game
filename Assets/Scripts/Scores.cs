using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollViewFiller : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject textPrefab;

    private List<int> savedScores;

    void Awake()
    {
        savedScores = LoadSavedScores();

        Debug.Log("=== DADOS CARREGADOS DO LoadSavedScores ===");
        if (savedScores == null || savedScores.Count == 0)
        {
            Debug.Log("Nenhum dado salvo encontrado");
        }
        else
        {
            Debug.Log("Quantidade de itens: " + savedScores.Count);
            foreach (var score in savedScores)
            {
                Debug.Log( score);
            }
        }
    }

    public void RefreshScroll()
    {
        Debug.Log("RefreshScroll() chamado!");

        // Pega todos os textos existentes no scroll
        TextMeshProUGUI[] textComponents = scrollViewContent.GetComponentsInChildren<TextMeshProUGUI>();

        for (int i = 0; i < textComponents.Length; i++)
        {
            if (i < savedScores.Count)
            {
                textComponents[i].text = "Best Carrots Score: " + savedScores[i];
                textComponents[i].gameObject.SetActive(true);
            }
            else
            {
                // Desativa textos extras caso existam mais textos do que scores
                textComponents[i].gameObject.SetActive(false);
            }
        }
    }


    List<int> LoadSavedScores()
    {
        Debug.Log("LoadSavedScores() executou!");

        List<int> scores = new List<int>();

        // Aqui você pode adicionar quantos scores quiser. Exemplo com apenas um:
        if (PlayerPrefs.HasKey("WinTime"))
        {
            int score = PlayerPrefs.GetInt("WinTime");
            scores.Add(score);
        }

        return scores;
    }
}
