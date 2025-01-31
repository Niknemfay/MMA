using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoundController : MonoBehaviour
{
    public static SoundController Instance { get; private set; }

    public event EventHandler OnSoundMute;
    public event EventHandler OnSoundUnmute;
    public event EventHandler OnSoundtrackMute;
    public event EventHandler OnSoundtrackUnmute;
    [Header("AudioClipsData")]
    [SerializeField] AudioClipsSOData audioClips;

    [Header("AudioSources")]
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource soundtrackSource;

    bool isSoundMute = false;
    bool isSoundtrackMute = false;


    public void Awake()
    {
        Instance = this;
        StartSoundtrack();
    }

    public void StartSoundtrack()
    {
        soundtrackSource.clip = audioClips.mainSound;
        soundtrackSource.Play();
    }
    public void PlaySoundButtonYes()
    {
        soundSource.clip = audioClips.soundButtonClickYes;
        soundSource.Play();
    }
    public void PlaySoundButtonNo()
    {
        soundSource.clip = audioClips.soundButtonClickNo;
        soundSource.Play();
    }
    public void PlaySoundButtonClose()
    {
        soundSource.clip = audioClips.soundButtonClose;
        soundSource.Play();
    }
    public void PlayMainButtons()
    {
        soundSource.clip = audioClips.soundMainButtons;
        soundSource.Play();
    }
    public void PlaySecondaryButton()
    {
        soundSource.clip = audioClips.soundSecondaryButtons;
        soundSource.Play();
    }
    public void PlaySwipeButton()
    {
        soundSource.clip = audioClips.swipeSound;
        soundSource.Play();
    }
    public void PlayChangeLocation()
    {
        soundSource.clip = audioClips.changeLocation;
        soundSource.Play();
    }
    public void ToggleSound()
    {
        isSoundMute = !isSoundMute;
        if (isSoundMute)
        {
            soundSource.mute = true;
            OnSoundMute?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            soundSource.mute = false;
            OnSoundUnmute?.Invoke(this, EventArgs.Empty);
        }
    }
    public void ToggleSoundtrack()
    {
        isSoundtrackMute = !isSoundtrackMute;
        if (isSoundtrackMute)
        {
            soundtrackSource.mute = true;
            OnSoundtrackMute?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            soundtrackSource.mute = false;
            OnSoundtrackUnmute?.Invoke(this, EventArgs.Empty);
        }
    }
}
