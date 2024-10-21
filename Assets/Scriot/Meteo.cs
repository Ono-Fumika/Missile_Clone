using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    private float speed_;
    private float min_; // 床の左端
    private float max_; // 床の右端
    private Vector3 targetPos_;

    // ゲームマネージャー
    [SerializeField] public GameManeger gameManeger_;
    // タワー
    [SerializeField] public Tower tower_;
    // 爆発
    [SerializeField] public MeteoExplosion explosion_;
    // パーティクル
    [SerializeField] ParticleSystem particleSystem_;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // 地面に衝突した場合
        if (collider.gameObject.tag == "Ground")
        {
            // 地面にダメージ
            gameManeger_.Damage();
            // 隕石を削除
            Destoroy();
        }
        // 爆発に衝突した場合
        if (collider.gameObject.tag == "Explosion")
        {
            // スコアを加算
            gameManeger_.AddScore();
            // 爆発を生成
            Instantiate(explosion_, transform.position, Quaternion.identity);
            // 隕石を削除
            Destoroy();
        }
        // タワーに衝突した場合
        if (collider.gameObject.tag == "Tower")
        {
            // 隕石を削除
            Destoroy();
        }
    }

    public void SetUp(float min, float max, float speed,GameManeger gameManeger)
    {
        min_ = min;
        max_ = max;
        gameManeger_ = gameManeger;
        speed_ = speed;
    }
    void Start()
    {
        // 目的地をランダムで決める
        targetPos_ = new Vector3(Random.Range(min_, max_), -5.0f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        // 現在の位置から目的地への方向を計算
        Vector3 direction = (targetPos_ - transform.position).normalized;
        // 移動
        transform.position += (direction * speed_ * Time.deltaTime);
    }
    void Destoroy()
    {
        // ２秒後に消す
        Destroy(gameObject, 2f);
        // パーティクルの生成を止める
        particleSystem_.Stop();
        // メテオの描画をやめる
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        // メテオの当たり判定を消す
        gameObject.GetComponent<Collider2D>().enabled = false; ;
    }

}
