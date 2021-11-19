﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gestiona sensibilidad del raton o movil
public class SensitivityController : MonoBehaviour
{
    void Awake(){
        PlayerController playercontroller = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        GetComponent<Slider>().onValueChanged.AddListener(delegate{
           playercontroller.sensitivityX = 15*PlayerPrefs.GetFloat("sensitivity",1);
           
           playercontroller.sensitivityY = 15*PlayerPrefs.GetFloat("sensitivity",1);
           Debug.Log(playercontroller.sensitivityX + playercontroller.sensitivityY);
        });
    }
}
