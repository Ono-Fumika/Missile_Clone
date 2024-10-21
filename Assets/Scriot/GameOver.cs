using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // �t�F�[�h
    private float Speed = 5.0f; //�t�F�[�h����X�s�[�h
    private float red, green, blue, alfa;
    [SerializeField] public Image fadeImage; // �p�l��

    void Start()
    {
        
    }

    void Update()
    {
        if (alfa < 255)
        {
            FadeIn();
        }
    }

    void FadeIn()
    {
        alfa -= Speed;
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
