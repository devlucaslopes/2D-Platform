using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private PlayerHealth Health;
    [SerializeField] private TextMeshProUGUI UITotalHealth;

    [Header("Game Over")]
    [SerializeField] private GameObject UIGameOver;

    public static GameManager Instance;

    void Start()
    {
        Time.timeScale = 1;

        Instance = this;

        UpdateHealth();
    }

    public void UpdateHealth()
    {
        UITotalHealth.text  = Health.TotalHealth.ToString();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0;
        UIGameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
