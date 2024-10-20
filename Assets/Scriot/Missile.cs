using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 targetPos;// ミサイルが飛んでいく場所
    public float speed_ = 5f; // ミサイルの移動速度

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 現在の位置から目的地への方向を計算
        Vector3 direction = (targetPos -transform.position).normalized;

        // 回転
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // 移動
        transform.position += (direction * speed_ * Time.deltaTime);

        // 目的地に達したら
        if (transform.position == targetPos)
        {
            // ミサイルを消す
            Destroy(gameObject);
        }
    }

    public void SetUp(Vector3 worldMoucePosition)
    {
        targetPos = worldMoucePosition;
    }
}
