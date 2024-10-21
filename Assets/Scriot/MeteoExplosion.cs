using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoExplosion : MonoBehaviour
{
    public float duration = 2.0f; // 爆発の継続時間
    protected float timer = 0.0f;
   public Vector3 targetScale = new Vector3(2.5f, 2.5f, 2.5f); // 目的のスケール

    // スケールを変更するメソッド
    protected virtual void ScaleChange()
    {
        float scaleAmount = timer / duration;
        transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, scaleAmount);
    }

    void Update()
    {
        timer += Time.deltaTime;
        ScaleChange();

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

}
