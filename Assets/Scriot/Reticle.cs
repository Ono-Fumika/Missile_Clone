using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public float rotationSpeed = 50f; // ��]���x

    void Update()
    {
        // Z������ɉ�]
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * 10f); // 10�{�̑��x�ɂ���
    }
}
