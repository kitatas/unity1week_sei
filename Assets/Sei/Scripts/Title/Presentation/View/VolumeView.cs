using System;
using Sei.Common;
using Sei.Common.Presentation.Controller.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Sei.Title.Presentation.View
{
    public sealed class VolumeView : MonoBehaviour
    {
        [SerializeField] private Slider bgmSlider = default;
        [SerializeField] private Slider seSlider = default;

        public void InitBgm(IVolumeControl bgm)
        {
            bgmSlider.value = bgm.GetVolume();
            bgmSlider
                .OnValueChangedAsObservable()
                .Subscribe(bgm.SetVolume)
                .AddTo(this);
        }

        public void InitSe(IVolumeControl se, Action<SeType> action)
        {
            seSlider.value = se.GetVolume();
            seSlider
                .OnValueChangedAsObservable()
                .Subscribe(se.SetVolume)
                .AddTo(this);

            seSlider
                .OnPointerUpAsObservable()
                .Subscribe(_ => action?.Invoke(SeType.Decision))
                .AddTo(this);
        }
    }
}