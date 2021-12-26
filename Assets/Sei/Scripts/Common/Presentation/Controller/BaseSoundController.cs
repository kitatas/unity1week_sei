using Sei.Common.Presentation.Controller.Interface;
using UnityEngine;

namespace Sei.Common.Presentation.Controller
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class BaseSoundController : MonoBehaviour, IVolumeControl
    {
        private AudioSource _audioSource;

        protected AudioSource audioSource => _audioSource ??= GetComponent<AudioSource>();

        public float GetVolume() => audioSource.volume;

        public void SetVolume(float value) => audioSource.volume = value;
    }
}