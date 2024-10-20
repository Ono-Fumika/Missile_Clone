using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 targetPos;// �~�T�C�������ł����ꏊ
    public float speed_ = 5f; // �~�T�C���̈ړ����x

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̈ʒu����ړI�n�ւ̕������v�Z
        Vector3 direction = (targetPos -transform.position).normalized;

        // ��]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // �ړ�
        transform.position += (direction * speed_ * Time.deltaTime);

        // �ړI�n�ɒB������
        if (transform.position == targetPos)
        {
            // �~�T�C��������
            Destroy(gameObject);
        }
    }

    public void SetUp(Vector3 worldMoucePosition)
    {
        targetPos = worldMoucePosition;
    }
}
