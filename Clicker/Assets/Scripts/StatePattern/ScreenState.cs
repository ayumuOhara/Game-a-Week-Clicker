using UnityEngine;

namespace StatePattern.StateScreen
{
    public interface ScreenState
    {
        public void Enter()
        {
            // State移行時
        }

        public void Update()
        {
            // Stateの間行う処理
        }

        public void Exit()
        {
            // State終了時
        }
    }
}

