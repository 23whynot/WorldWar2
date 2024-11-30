using System.Collections.Generic;
using System.Linq;
using Script.Constans;
using Script.UI;
using UnityEngine;

namespace Script.Core
{
    public class AudioService : MonoBehaviour  
    {
        [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
        [SerializeField] private VolumeSliderUI volumeSliderUI;

        private List<AudioSource> _audioSources = new List<AudioSource>();


        private void Start()
        {
            _audioSources.AddRange(GetComponents<AudioSource>());

            PlaySound(AudioConstans.MainTheme);

            volumeSliderUI.OnValueChanged += ChangeVolume;
        }

        public void PlaySound(string nameOfSound)
        {
            AudioSource audioSource = GetFreeAudioSource();

            foreach (var clip in audioClips.Where(clip => clip.name == nameOfSound))
            {
                if (clip.name == AudioConstans.MainTheme)
                {
                    audioSource.clip = clip;
                    audioSource.loop = true;
                }
                else if (clip.name == AudioConstans.Damage)
                {
                    audioSource.clip = clip;
                }
                audioSource.clip = clip;
                break;
            }
            audioSource.Play();
        }

        public void ChangeVolume(float volume)
        {
            foreach (var audioSource in _audioSources)
            {
                audioSource.volume = volume;
            }
        }

        private AudioSource GetFreeAudioSource()
        {
            foreach (var audioSource in _audioSources)
            {
                if (!audioSource.isPlaying)
                {
                    return audioSource; 
                }
            }
        
            _audioSources.Add(gameObject.AddComponent<AudioSource>());
        
            return _audioSources[^1];
        }

        private void OnDestroy()
        {
            volumeSliderUI.OnValueChanged -= ChangeVolume;
        }
    }
}