﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScene : MonoBehaviour
{
    public void goBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
