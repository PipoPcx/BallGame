using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class S_AudioManager : MonoBehaviour
{

    public AudioMixerGroup master, music, sfx, rain, wind, jump, yellowTorus, greenTorus, pinkTorus, win, fog;

    public void SetMasterVolume(float vol) {

        master.audioMixer.SetFloat("MasterVolume", vol / 2);
    }

    public void winVolume(float vol) {

        win.audioMixer.SetFloat("WinVolume", vol / 2);
    }

    public void SetMusicVolume(float vol) {

        music.audioMixer.SetFloat("MusicVolume", vol / 2);
    }

    public void SetSFXVolume(float vol) {

        sfx.audioMixer.SetFloat("SFXVolume", vol / 2);
    }

    public void SetRainVolume(float vol) {

        rain.audioMixer.SetFloat("RainVolume", vol / 2);
    }

    public void SetWindVolume(float vol) {

        wind.audioMixer.SetFloat("WindVolume", vol / 2);
    }

    public void YellowTorusVolume(float vol) {

        yellowTorus.audioMixer.SetFloat("YellowTorusVolume", vol / 2);
    }

    public void GreenTorusVolume(float vol) {

        greenTorus.audioMixer.SetFloat("GreenTorusVolume", vol / 2);
    }

    public void PinkTorusVolume(float vol) {

        pinkTorus.audioMixer.SetFloat("PinkTorusVolume", vol / 2);
    }

    public void SetJumpVolume(float vol) {

        jump.audioMixer.SetFloat("JumpVolume", vol / 2);
    }

    public void FogVolume(float vol)
    {

        fog.audioMixer.SetFloat("FogVolume", vol / 2);
    }
}
