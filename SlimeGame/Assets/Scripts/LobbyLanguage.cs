using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyLanguage : MonoBehaviour
{
    public Text[] texts;

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<texts.Length; i++)
        {
            if (PlayerPrefs.GetInt("language") == 1)
            {
                texts[i].text = "Esperando a otro jugador...";
            }
            else
            {
                texts[i].text = "Waiting for other player...";
            }
        }
    }
}
