using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsAwake : MonoBehaviour
{

    [SerializeField] Slider sliderVolume;
    [SerializeField] Slider sliderSensitivity;

    [SerializeField] Button español;
    [SerializeField] Button english;

    [SerializeField] Text volumeText;
    [SerializeField] Text sensitivityText;
    [SerializeField] Text languageText;
    [SerializeField] Text gameOverButtonText;
    void Awake(){
        sliderVolume.value = PlayerPrefs.GetFloat("volume",1);
        sliderVolume.onValueChanged.AddListener(delegate {AudioListener.volume = sliderVolume.value;
                                                    PlayerPrefs.SetFloat("volume", sliderVolume.value);
                                                    Debug.Log(sliderVolume.value); });

        sliderSensitivity.value = PlayerPrefs.GetFloat("sensitivity",1);
        sliderSensitivity.onValueChanged.AddListener(delegate {
                                                    PlayerPrefs.SetFloat("sensitivity", sliderSensitivity.value);
                                                    Debug.Log(sliderSensitivity.value); });

        español.onClick.AddListener(delegate {
            PlayerPrefs.SetInt("language",1);
            volumeText.text = "Volumen";
            sensitivityText.text = "Sensibilidad del ratón";
            languageText.text = "Idioma";
            gameOverButtonText.text = "Salir de la partida";
        });
        english.onClick.AddListener(delegate {
            PlayerPrefs.SetInt("language",0);
            volumeText.text = "Volume";
            sensitivityText.text = "Mouse sensitivity";
            languageText.text = "Language";
            gameOverButtonText.text = "Leave game";
        });
        
    }

    // Update is called once per frame

    void Update()
    {
        if (PlayerPrefs.GetInt("language") == 1)
        {
            volumeText.text = "Volumen";
            sensitivityText.text = "Sensibilidad del ratón";
            languageText.text = "Idioma";
            gameOverButtonText.text = "Salir de la partida";
        }
        else
        {
            volumeText.text = "Volume";
            sensitivityText.text = "Mouse sensitivity";
            languageText.text = "Language";
            gameOverButtonText.text = "Leave game";
        }
    }
}
