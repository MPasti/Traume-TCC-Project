using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectsMixer;

    public AudioSource hit, arrow, damage, jump, death, musicMB, BackgroundMusic, coins, GameOver, MainMenu;

    public static AudioManager instance;


    [Range(-80, 10)]
    public float masterVol, effectsVol;
    public Slider MusicSlider, EffectSlider;

    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(BackgroundMusic);
        MusicSlider.value = masterVol;
        EffectSlider.value = effectsVol;

        MusicSlider.minValue = -80;
        MusicSlider.maxValue = 10;

        EffectSlider.minValue = -80;
        EffectSlider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        EffectsVolume();

    }
    public void MasterVolume() {
        musicMixer.SetFloat("MasterVolume", MusicSlider.value);
    }
    public void EffectsVolume()
    {
        effectsMixer.SetFloat("EffectsVolume", EffectSlider.value);
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
