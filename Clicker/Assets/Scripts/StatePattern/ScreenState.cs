using UnityEngine;

namespace StatePattern.StateScreen
{
    public interface ScreenState
    {
        public void Enter()
        {
            // State�ڍs��
        }

        public void Update()
        {
            // State�̊ԍs������
        }

        public void Exit()
        {
            // State�I����
        }
    }
}

