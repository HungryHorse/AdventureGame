using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    public static AudioController Instance => instance;

    public AudioSource BackgroundMusicSource;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private AudioMixerGroup masterAudioGroup;
    [SerializeField]
    private AudioMixerGroup musicAudioGroup;
    [SerializeField]
    private AudioMixerGroup sfxAudioGroup;
    [SerializeField]
    private AudioMixerGroup voiceAudioGroup;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(AudioGroup group, int volume)
    {
        audioMixer.SetFloat(Enum.GetName(typeof(AudioGroup), group), Mathf.Log10(volume) * 20);
    }

    public void Play(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public void PlayBackgroundMusic()
    {
        BackgroundMusicSource.Play();
    }

    public void PauseBackgroundMusic()
    {
        BackgroundMusicSource.Pause();
    }
}
