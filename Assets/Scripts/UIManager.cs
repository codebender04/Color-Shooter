using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Awake()
    {
        Instance = this;
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}

