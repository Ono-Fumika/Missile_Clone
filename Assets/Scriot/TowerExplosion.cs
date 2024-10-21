using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExplosion : MeteoExplosion
{
    public float targetScaleX = 3.0f; // X軸の目的のスケール

    protected override void ScaleChange()
    {
        float scaleAmount = timer / duration;
        transform.localScale = new Vector3(Mathf.Lerp(0, targetScaleX, scaleAmount), transform.localScale.y, transform.localScale.z);
    }
}
