using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Common.Presentation.View;
using UnityEngine.SceneManagement;

namespace Sei.Common.Presentation.Controller
{
    public sealed class SceneLoader : IDisposable
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly TransitionMaskView _transitionMaskView;

        public SceneLoader(TransitionMaskView transitionMaskView)
        {
            _tokenSource = new CancellationTokenSource();
            _transitionMaskView = transitionMaskView;
            _transitionMaskView.Init();
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void LoadScene(SceneType sceneType)
        {
            LoadSceneAsync(sceneType, _tokenSource.Token).Forget();
        }

        private async UniTaskVoid LoadSceneAsync(SceneType sceneType, CancellationToken token)
        {
            await _transitionMaskView.FadeInAsync(token);

            await SceneManager.LoadSceneAsync(sceneType.ToString());

            await _transitionMaskView.FadeOutAsync(token);
        }

        public void UnloadSceneAsync(SceneType sceneType)
        {
            SceneManager.UnloadSceneAsync(sceneType.ToString());
        }
    }
}