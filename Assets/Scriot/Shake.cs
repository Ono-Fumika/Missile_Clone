using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private float shakeTime_; // �h��鎞��
    private float shakeMagnitude_; // �h��镝
    private float currentShakeTime_; // ���݂̃V�F�C�N����
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
            // �V�F�C�N�̋��x�����Ԃɉ����Č���������
            float currentMagnitude = shakeMagnitude_ * (currentShakeTime_ / shakeTime_);

            // �V�F�C�N����
            shake.x = Random.Range(-0.5f, 0.5f) * currentMagnitude;
            shake.y = Random.Range(-0.5f, 0.5f) * currentMagnitude;

            // �V�F�C�N�̒l����
            transform.position = startPos_ + shake;

            // �o�ߎ��Ԃ�����������
            currentShakeTime_ -= Time.deltaTime;
        }
        else
        {
            // �V�F�C�N���I�������猳�̈ʒu�ɖ߂�
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
