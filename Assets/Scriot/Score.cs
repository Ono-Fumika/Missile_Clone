using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText; // �X�R�A�e�L�X�g
    private int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �O���߂�8���܂ŕ\��
        scoreText.text = "SCORE:" + scoreCount.ToString("d8");
    }

    public void AddScore()
    {
        // �X�R�A�̉��Z
        scoreCount += 100;
        scoreText.text = "SCORE:" + scoreCount.ToString("d8");
    }
}
