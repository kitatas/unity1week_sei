using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sei.Common.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonActivator : MonoBehaviour
    {
        private Button _button;
        public Button button => _button ??= GetComponent<Button>();

        private Action _buttonAction;

        public void OnPush(Action action)
        {
            _buttonAction += () => action?.Invoke();

            button
                .OnClickAsObservable()
                .Subscribe(_ => _buttonAction?.Invoke())
                .AddTo(this);
        }

        public void Activate(bool value)
        {
            button.enabled = value;
        }
    }
}