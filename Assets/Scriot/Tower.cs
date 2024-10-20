using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private float hp_ = 3.0f; // 体力
    private float damage_ = 1.0f; // 受けるダメージ量
    public float cooldownTimer_ = 3.0f; // 発射可能になるまでの時間(3秒)
    public bool isShot_ = true; // 発射出来るかのフラグ
    public bool isDie_ = false; // 死んだかのフラグ
    Vector3 worldMoucePosition_; // マウスポジション(ワールド)

    // ミサイル
    [SerializeField] public Missile missile;

    // 爆発エフェクト
    [SerializeField] public GameObject explosion_;

    // カラー関連
    private Renderer towerRenderer;
    private Color originalColor;
    private Color cooldownColor = Color.red;

    public void Shot(Vector3 worldMoucePosition)
    {
        worldMoucePosition_ = worldMoucePosition;
        if (isShot_)
        {
            // タワーから生成
            Missile missileInstence_ = Instantiate(missile, transform.position, Quaternion.identity);
            missileInstence_.SetUp(worldMoucePosition_);
            // 生成したら撃てなくなる
            isShot_ = false;
        }
    }

    void Start()
    {
        towerRenderer = GetComponent<Renderer>();
        if (towerRenderer != null)
        {
            originalColor = towerRenderer.material.color;
        }
    }

    void Update()
    {
        // 撃てない状態になったら
        if (!isShot_)
        {
            // クールタイムのカウント
            cooldownTimer_ -= Time.deltaTime;

            // クールタイム中に色を変化させる
            float lerpFactor = 1.0f - (cooldownTimer_ / 3.0f); // カウントダウンの割合
            towerRenderer.material.color = Color.Lerp(cooldownColor, originalColor, lerpFactor);

            // クールタイムが0になったら撃てる状態にする
            if (cooldownTimer_ <= 0)
            {
                isShot_ = true;
                cooldownTimer_ = 3.0f;
                towerRenderer.material.color = originalColor; // 色を元に戻す
            }
        }

        // ｈｐが0になったら
        if (hp_ <= 0)
        {
            isDie_ = true;
            // 爆発を生成
            //Instantiate(explosion_, transform.position, Quaternion.identity);
            // 自壊する
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // メテオと衝突した場合
        if (collider.gameObject.tag == "Meteo")
        {
            // タワーにダメージ
            hp_ -= damage_;
        }
    }
}
