using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSlider : MonoBehaviour
{
    private float maxHp = 10; // 最大HP
    private float currentHp; // 現在のHP
    [SerializeField]  public Slider slider; // ライフバー

    void Start()
    {
        slider.value = maxHp;
        currentHp = maxHp;
    }

    public void CurrentHp()
    {
        currentHp--;
        slider.value = currentHp;
    }
}
