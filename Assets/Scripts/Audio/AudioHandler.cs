using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler {

    private AudioMixer audioMixer;

    public AudioHandler(AudioMixer audioMixer)
    {
        this.audioMixer = audioMixer;
    }

    public void SetOverallVolume(float newVolume)
    {
        audioMixer.SetFloat("Master_Level", newVolume);
    }

    public void SetMusicVolume(float newVolume)
    {
        audioMixer.SetFloat("MX_Level", newVolume);
    }

    public void SetSFXVolume(float newVolume)
    {
        audioMixer.SetFloat("SFX_Level", newVolume);
    }

    public void SetAmbientVolume(float newVolume)
    {
        audioMixer.SetFloat("AX_Level", newVolume);
    }

    public void SetDialogueVolume(float newVolume)
    {
        audioMixer.SetFloat("DX_Level", newVolume);
    }

    public float GetAudioChannelVolume(AudioChannel ac)
    {
        float vol = -1.0f;
        switch (ac)
        {
            case AudioChannel.Master:
                audioMixer.GetFloat("Master_Level", out vol);
                break;
            case AudioChannel.MX:
                audioMixer.GetFloat("MX_Level", out vol);
                break;
            case AudioChannel.SFX:
                audioMixer.GetFloat("SFX_Level", out vol);
                break;
            case AudioChannel.AX:
                audioMixer.GetFloat("AX_Level", out vol);
                break;
            case AudioChannel.DX:
                audioMixer.GetFloat("DX_Level", out vol);
                break;
        }

        return vol;
    }

    public enum AudioChannel
    {
        Master, AX, MX, SFX, DX
    }
    public enum MX
    {

    }
    public enum SFX
    {

    }
    public enum DX
    {

    }
    public enum AX
    {

    }
}
