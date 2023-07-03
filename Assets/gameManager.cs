using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject menuPanel;
    public GameObject audioPanel;
    public GameObject sfxPanel;

    [Header("otros")]
    public TextMeshProUGUI puntajeText;
    public GameObject winText;
    public AudioSource winSound;

    [Header("particulas")]
    public ParticleSystem rainParticle;
    public GameObject fog;
    public ParticleSystem fogParticle;
    public AudioSource fogSound;


    public int puntaje = 0;
    public bool alreadyActivatedSound = false;
    private bool activatedRain = false;
    private bool activatedFog = false;

    private void Start() {
        
        menuPanel.SetActive(false);
        audioPanel.SetActive(false);    
        sfxPanel.SetActive(false);

        Cursor.visible = false;
        winText.SetActive(false);
    }


    public void AudioPanelActive() { 
    
        menuPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

    public void SFXPanelActive()
    {

        menuPanel.SetActive(false);
        sfxPanel.SetActive(true);
    }

    public void ResumirButton() { 
    
        menuPanel.SetActive(false);
    }

    public void VolverButton()
    {

        audioPanel.SetActive(false);
        sfxPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void RainButtonActive() { 
    
        if(!activatedRain) { 
        
            rainParticle.Play();
            activatedRain = true;
        }
        else if (activatedRain){ 
        
            rainParticle.Stop();
            activatedRain = false;
        }
    }

    public void FogButtonActive() {

        if(!activatedFog) { 
        
            fog.SetActive(true);
            fogParticle.Play();
            activatedFog = true;
            fogSound.Play();

        }
        else if (activatedFog) {

            fog.SetActive(false);
            fogParticle.Stop();
            activatedFog = false;
            
        }
    }


    private void Update() {
        
        if(puntaje >= 50 && !alreadyActivatedSound) { 
        
            winText.SetActive(true);
            alreadyActivatedSound = true;
            winSound.Play();
            Debug.Log(puntaje);
           
           

            
        }


        if(Input.GetKeyDown(KeyCode.Escape)) { 
        
            menuPanel.SetActive(true);
        }

        puntajeText.text = "Puntaje: " + puntaje;

        if(audioPanel.activeSelf || menuPanel.activeSelf || sfxPanel.activeSelf) {

            Cursor.visible = true;
        }
        else { 
        
            Cursor.visible = false;
        }
    }
}
