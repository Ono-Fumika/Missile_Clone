using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    private float min_; // ���̍��[
    private float max_; // ���̉E�[

    public void SetUp(float min,float max)
    {
        min_ = min;
        max_ = max;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
