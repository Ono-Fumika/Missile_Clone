using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public float rotationSpeed = 50f; // ‰ñ“]‘¬“x

    void Update()
    {
        // ZŽ²Žü‚è‚É‰ñ“]
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * 10f); // 10”{‚Ì‘¬“x‚É‚·‚é
    }
}
