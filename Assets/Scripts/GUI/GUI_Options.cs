using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Options : GUI_ELEMENT
{
    public Slider masterVolume;
    public Text masterVolumeTXT;
    public Slider musicVolume;
    public Text musicVolumeTXT;
    public Slider ambientVolume;
    public Text ambientVolumeTXT;
    public Slider sfxVolume;
    public Text sfxVolumeTXT;
    public Slider dialogueVolume;
    public Text dialogueVolumeTXT;

    public override void SetUp(ArrayList data)
    {
        masterVolume.value = InGameHandler.audioHandler.GetAudioChannelVolume(AudioHandler.AudioChannel.Master);
        musicVolume.value = InGameHandler.audioHandler.GetAudioChannelVolume(AudioHandler.AudioChannel.MX);
        ambientVolume.value = InGameHandler.audioHandler.GetAudioChannelVolume(AudioHandler.AudioChannel.AX);
        sfxVolume.value = InGameHandler.audioHandler.GetAudioChannelVolume(AudioHandler.AudioChannel.SFX);
        dialogueVolume.value = InGameHandler.audioHandler.GetAudioChannelVolume(AudioHandler.AudioChannel.DX);

        masterVolumeTXT.text = (Mathf.Abs((masterVolume.value / 100.0f) - 1) * 100).ToString() + "%";
        musicVolumeTXT.text = (Mathf.Abs((musicVolume.value / 100.0f) - 1) * 100).ToString() + "%";
        ambientVolumeTXT.text = (Mathf.Abs((ambientVolume.value / 100) - 1) * 100).ToString() + "%";
        sfxVolumeTXT.text = (Mathf.Abs((sfxVolume.value / 100.0f) - 1) * 100).ToString() + "%";
        dialogueVolumeTXT.text = (Mathf.Abs((dialogueVolume.value / 100.0f) - 1) * 100).ToString() + "%";
    }

    public void VolumeChanged(string channel)
    {
        Text current_t = null;
        Slider current_s = null;

        switch (channel)
        {
            case "master":
                InGameHandler.audioHandler.SetOverallVolume(masterVolume.value * -0.8f);
                current_t = masterVolumeTXT;
                current_s = masterVolume;
                break;
            case "music":
                InGameHandler.audioHandler.SetMusicVolume(musicVolume.value * -0.8f);
                current_t = musicVolumeTXT;
                current_s = musicVolume;
                break;
            case "ambient":
                InGameHandler.audioHandler.SetAmbientVolume(ambientVolume.value * -0.8f);
                current_t = ambientVolumeTXT;
                current_s = ambientVolume;
                break;
            case "sfx":
                InGameHandler.audioHandler.SetSFXVolume(sfxVolume.value * -0.8f);
                current_t = sfxVolumeTXT;
                current_s = sfxVolume;
                break;
            case "dialogue":
                InGameHandler.audioHandler.SetDialogueVolume(dialogueVolume.value * -0.8f);
                current_t = dialogueVolumeTXT;
                current_s = dialogueVolume;
                break;
        }

        current_t.text = (Mathf.Abs((current_s.value / 100.0f) - 1) * 100).ToString() + "%";
    }
}
