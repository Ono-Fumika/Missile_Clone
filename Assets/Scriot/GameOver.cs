using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // フェード
    private float Speed = 0.2f; //フェードするスピード
    private float alfa = 0f;
    [SerializeField] public Image fadeImage; // パネル 
    // 爆発
    private Vector3 explosionPos_; // 生成位置
    private float timer_ = 0.3f; // 生成スピード
    [SerializeField] public MeteoExplosion explosion_;
    float height; // 画面縦幅
    float width; // 画面横幅
    // テキスト
    [SerializeField] public TextMeshProUGUI GameOverText;
    [SerializeField] public TextMeshProUGUI scoreText;

    void Start()
    {
        // 初期アルファ値を設定
        fadeImage.color = new Color(1, 1, 1, alfa);
        // カメラのビュー範囲を取得
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize /2;
        width = height * cam.aspect /2;
    }
    public void gameOver(int scoreCount)
    {
        // 真っ白になるまで
        if (alfa < 1)
        {
            // フェードイン
            FadeIn();
            // ランダムに爆発を起こす
            Explosion();
        }
        else // 真っ白になったら
        {
            // テキストを表示
            Text(scoreCount);
            // クリックされたら
            if (Input.GetMouseButtonUp(0))
            {
                // シーンを再ロード
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void FadeIn()
    {　
        // 段々濃くする
        alfa += Speed * Time.deltaTime;
        fadeImage.color = new Color(1, 1, 1, alfa);
    }
    void Explosion()
    {
        // タイマー
        timer_ -= Time.deltaTime;

        if(timer_ <= 0)
        {
            // 場所を画面内にランダムで選ぶ
            explosionPos_ = new Vector3(Random.Range(-width, width), Random.Range(-height, height), 0);
            // 爆発を生成
            Instantiate(explosion_, explosionPos_, Quaternion.identity);
            // タイマーリセット
            timer_ = 0.3f;
        }
       
    }
    void Text(int scoreCount)
    {
        GameOverText.text = "GAME OVER\n\n\n\n[Push Reset]";
        scoreText.text = "SCORE:" + scoreCount.ToString("d8");
    }
}
