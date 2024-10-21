using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 targetPos_;// �~�T�C�������ł����ꏊ
    private float speed_ = 10f; // �~�T�C���̈ړ����x
    // ����
    [SerializeField] public MeteoExplosion explosion_;

    // Update is called once per frame
    void Update()
    {
        // ���݂̈ʒu����ړI�n�ւ̕������v�Z
        Vector3 direction = (targetPos_ -transform.position).normalized;

        // ��]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // �ړ�
        transform.position += (direction * speed_ * Time.deltaTime);

        // �ړI�n�ɒB������
        if (Vector3.Distance(transform.position, targetPos_) < 0.1f)
        {
            // ���e�B�N�����^�O�Ō������č폜
            GameObject reticle = GameObject.FindWithTag("Reticle");
            Destroy(reticle);
            // �����𐶐�
            Instantiate(explosion_, targetPos_, Quaternion.identity);
            // �~�T�C��������
            Destroy(gameObject);
        }
    }

    public void SetUp(Vector3 worldMoucePosition)
    {
        targetPos_ = worldMoucePosition;
    }
}
