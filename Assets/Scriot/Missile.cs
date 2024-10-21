using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 targetPos_;// ミサイルが飛んでいく場所
    private float speed_ = 10f; // ミサイルの移動速度
    // 爆発
    [SerializeField] public MeteoExplosion explosion_;

    // Update is called once per frame
    void Update()
    {
        // 現在の位置から目的地への方向を計算
        Vector3 direction = (targetPos_ -transform.position).normalized;

        // 回転
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // 移動
        transform.position += (direction * speed_ * Time.deltaTime);

        // 目的地に達したら
        if (Vector3.Distance(transform.position, targetPos_) < 0.1f)
        {
            // レティクルをタグで検索して削除
            GameObject reticle = GameObject.FindWithTag("Reticle");
            Destroy(reticle);
            // 爆発を生成
            Instantiate(explosion_, targetPos_, Quaternion.identity);
            // ミサイルを消す
            Destroy(gameObject);
        }
    }

    public void SetUp(Vector3 worldMoucePosition)
    {
        targetPos_ = worldMoucePosition;
    }
}
