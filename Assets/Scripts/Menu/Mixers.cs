using UnityEngine;
using UnityEngine.Audio;

public class Mixers : MonoBehaviour
{
    public AudioMixerGroup MusicMixer;

    public AudioMixerGroup SoundsMixer;

    public void ChangeMusicVolume(float volume)
    {
        MusicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }
    
    public void ChangeSoundsVolume(float volume)
    {
        SoundsMixer.audioMixer.SetFloat("SoundsVolume", Mathf.Lerp(-80, 0, volume));
    }
}
