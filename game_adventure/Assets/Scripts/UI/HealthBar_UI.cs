using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar_UI : MonoBehaviour
{
    public Image barImage;
    //public float healthAmount = 100;
    public player player;

    private void Update()
    {
        float fillAmount = (float)player.health / player.MaxHealth;
        barImage.fillAmount = fillAmount;
    }


}
