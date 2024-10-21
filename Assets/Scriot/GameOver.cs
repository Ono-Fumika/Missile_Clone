using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // �t�F�[�h
    private float Speed = 0.2f; //�t�F�[�h����X�s�[�h
    private float alfa = 0f;
    [SerializeField] public Image fadeImage; // �p�l�� 
    // ����
    private Vector3 explosionPos_; // �����ʒu
    private float timer_ = 0.3f; // �����X�s�[�h
    [SerializeField] public MeteoExplosion explosion_;
    float height; // ��ʏc��
    float width; // ��ʉ���
    // �e�L�X�g
    [SerializeField] public TextMeshProUGUI GameOverText;
    [SerializeField] public TextMeshProUGUI scoreText;

    void Start()
    {
        // �����A���t�@�l��ݒ�
        fadeImage.color = new Color(1, 1, 1, alfa);
        // �J�����̃r���[�͈͂��擾
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize /2;
        width = height * cam.aspect /2;
    }
    public void gameOver(int scoreCount)
    {
        // �^�����ɂȂ�܂�
        if (alfa < 1)
        {
            // �t�F�[�h�C��
            FadeIn();
            // �����_���ɔ������N����
            Explosion();
        }
        else // �^�����ɂȂ�����
        {
            // �e�L�X�g��\��
            Text(scoreCount);
            // �N���b�N���ꂽ��
            if (Input.GetMouseButtonUp(0))
            {
                // �V�[�����ă��[�h
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void FadeIn()
    {�@
        // �i�X�Z������
        alfa += Speed * Time.deltaTime;
        fadeImage.color = new Color(1, 1, 1, alfa);
    }
    void Explosion()
    {
        // �^�C�}�[
        timer_ -= Time.deltaTime;

        if(timer_ <= 0)
        {
            // �ꏊ����ʓ��Ƀ����_���őI��
            explosionPos_ = new Vector3(Random.Range(-width, width), Random.Range(-height, height), 0);
            // �����𐶐�
            Instantiate(explosion_, explosionPos_, Quaternion.identity);
            // �^�C�}�[���Z�b�g
            timer_ = 0.3f;
        }
       
    }
    void Text(int scoreCount)
    {
        GameOverText.text = "GAME OVER\n\n\n\n[Push Reset]";
        scoreText.text = "SCORE:" + scoreCount.ToString("d8");
    }
}
