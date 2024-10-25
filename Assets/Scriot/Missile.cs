using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 targetPos_; // ミサイルが飛んでいく場所
    private float speed_ = 10f; // ミサイルの移動速度
    [SerializeField] public MeteoExplosion explosion_; // 爆発
    // レティクル
    private GameObject reticle_; // レティクルのGameObject参照

    void Start()
    {
    }
    void Update()
    {
        // 現在の位置から目的地への方向を計算
        Vector3 direction = (targetPos_ - transform.position).normalized;

        // 回転
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // 一定速度で移動
        transform.position += direction * speed_ * Time.deltaTime;

        // 目的地に達したら
        if (Vector3.Distance(transform.position, targetPos_) < 0.1f)
        {
            if (reticle_ != null)
            {
                Destroy(reticle_);
            }
            // 爆発を生成
            Instantiate(explosion_, targetPos_, Quaternion.identity);
            // ミサイルを消す
            Destroy(gameObject);
        }
    }

    public void SetUp(Vector3 worldMousePosition, GameObject reticle)
    {
        reticle_ = reticle;
        targetPos_ = worldMousePosition;
    }

}
