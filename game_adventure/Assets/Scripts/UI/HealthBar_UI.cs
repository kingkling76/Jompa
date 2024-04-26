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
        Debug.Log(player.instance.health);
        float fillAmount = (float)player.instance.health / player.instance.MaxHealth;
        barImage.fillAmount = fillAmount;
    }


}
