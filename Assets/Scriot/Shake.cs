using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private float shakeTime_; // 揺れる時間
    private float shakeMagnitude_; // 揺れる幅
    private float currentShakeTime_; // 現在のシェイク時間
    private Vector3 startPos_;
    private Vector3 shake;

    // Start is called before the first frame update
    void Start()
    {
        startPos_ = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShakeTime_ > 0)
        {
            // シェイクの強度を時間に応じて減少させる
            float currentMagnitude = shakeMagnitude_ * (currentShakeTime_ / shakeTime_);

            // シェイクする
            shake.x = Random.Range(-0.5f, 0.5f) * currentMagnitude;
            shake.y = Random.Range(-0.5f, 0.5f) * currentMagnitude;

            // シェイクの値を代入
            transform.position = startPos_ + shake;

            // 経過時間を減少させる
            currentShakeTime_ -= Time.deltaTime;
        }
        else
        {
            // シェイクが終了したら元の位置に戻す
            transform.position = startPos_;
        }

    }

    public void StartShake(float shakeTime,float magnitude)
    {
        shakeTime_ = shakeTime;
        shakeMagnitude_ = magnitude;
        currentShakeTime_ = shakeTime_;
    }
}
