using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private PlayerHealth Health;
    [SerializeField] private TextMeshProUGUI UITotalHealth;

    public static GameManager Instance;

    void Start()
    {
        Instance = this;

        UpdateHealth();
    }

    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        UITotalHealth.text  = Health.TotalHealth.ToString();
    }
}
