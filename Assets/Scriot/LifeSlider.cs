using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSlider : MonoBehaviour
{
    private float maxHp = 10; // �ő�HP
    private float currentHp; // ���݂�HP
    [SerializeField]  public Slider slider; // ���C�t�o�[

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
