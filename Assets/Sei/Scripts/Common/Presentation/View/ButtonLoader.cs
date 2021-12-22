using System;
using UnityEngine;

namespace Sei.Common.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    public sealed class ButtonLoader : MonoBehaviour
    {
        [SerializeField] private SceneType sceneType = default;

        private ButtonActivator _buttonActivator;
        private ButtonActivator buttonActivator => _buttonActivator ??= GetComponent<ButtonActivator>();

        public void OnPush(Action<SceneType> action)
        {
            buttonActivator.OnPush(() => action?.Invoke(sceneType));
        }
    }
}