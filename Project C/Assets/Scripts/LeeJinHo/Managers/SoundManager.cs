using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource BGM;
    [SerializeField] public AudioSource SoundEffect;
    [SerializeField] public AudioSource BossSound;
    [SerializeField] public AudioSource GetItemSound;

    public void Init()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        SoundEffect = gameObject.AddComponent<AudioSource>();
        BossSound = gameObject.AddComponent <AudioSource>();
        GetItemSound = gameObject.AddComponent <AudioSource>();
        BGMMugicStart();
    }
    private void BGMMugicStart()
    {
        string sd = "basementLoop";
        BGM.clip = Managers.Resource.LoadAudioClips("basementLoop");
        PlayBGM();
    }

    public void ChangeBGM(string BGMName)
    {
        BGM.clip = Managers.Resource.LoadAudioClips($"{BGMName}");
        PlayBGM();
    }

    public void EffectSoundChange(string sound)
    {
        SoundEffect.Stop();
        SoundEffect.clip = Managers.Resource.LoadAudioClips(sound);
        SoundEffect.Play();
    }
    public void BossSoundChange(string sound)
    {
        BossSound.Stop();
        BossSound.clip = Managers.Resource.LoadAudioClips(sound);
        BossSound.Play();
        BGM.loop = true;
    }
    public void ChangeGetItemSound(string sound)
    {
        GetItemSound.clip = Managers.Resource.LoadAudioClips(sound);
        GetItemSound.Play();
    }
    public void StopBGM()
    {
        BGM.Stop();
    }

    public void PlayBGM()
    {
        BGM.Play();
        BGM.loop = true;
    }

    public void SetBGMVolume(float volume)
    {
        float bgmVolume = Mathf.Clamp01(volume); // 볼륨이 0에서 1 사이에 있도록 보장
        BGM.volume = bgmVolume;
    }
    public void SetSFXVolume(float volume)
    {
        float sfxVolume = Mathf.Clamp01(volume);
        SoundEffect.volume = sfxVolume;
        BossSound.volume = sfxVolume;
        GetItemSound.volume = sfxVolume;
    }
}