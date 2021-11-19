using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Tabla de stats
public class StatsLanguage : MonoBehaviour
{
    public Text text;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("language") == 1)
        {
            text.text = "Jugadores           Puntuación";
        }
        else
        {
            text.text = "Players           Score";
        }
    }
}
