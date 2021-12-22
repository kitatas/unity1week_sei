using System;
using UnityEngine;

namespace Sei.Common.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    public sealed class ButtonSpeaker : MonoBehaviour
    {
        [SerializeField] private ButtonType buttonType = default;

        private ButtonActivator _buttonActivator;
        private ButtonActivator buttonActivator => _buttonActivator ??= GetComponent<ButtonActivator>();

        public void OnPush(Action<ButtonType> action)
        {
            buttonActivator.OnPush(() => action?.Invoke(buttonType));
        }
    }
}