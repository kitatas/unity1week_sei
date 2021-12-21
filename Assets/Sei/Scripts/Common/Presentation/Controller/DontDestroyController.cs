using Sei.Common.Presentation.View;
using UnityEngine;

namespace Sei.Common.Presentation.Controller
{
    public sealed class DontDestroyController : MonoBehaviour
    {
        public static DontDestroyController Instance { get; private set; }

        public BgmController bgmController { get; private set; }
        public SeController seController { get; private set; }
        public TransitionMaskView maskView { get; private set; }

        private void Start()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void Init()
        {
            Instance = this;
            bgmController = GetComponentInChildren<BgmController>();
            seController = GetComponentInChildren<SeController>();
            maskView = GetComponentInChildren<TransitionMaskView>();

            DontDestroyOnLoad(gameObject);
        }
    }
}