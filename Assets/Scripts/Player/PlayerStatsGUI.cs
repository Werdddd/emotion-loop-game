using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsGUI : MonoBehaviour
{
    [SerializeField] public Slider slider;

    public void ShowHealth(float health)
    {
        slider.value = health;
    }

}
