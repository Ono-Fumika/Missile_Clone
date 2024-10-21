using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText; // スコアテキスト
    private int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ０埋めで8桁まで表示
        scoreText.text = "SCORE:" + scoreCount.ToString("d8");
    }

    public void AddScore()
    {
        // スコアの加算
        scoreCount += 100;
        scoreText.text = "SCORE:" + scoreCount.ToString("d8");
    }
}
