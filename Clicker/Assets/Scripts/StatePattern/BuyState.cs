using UnityEngine;

namespace StatePattern.StateScreen
{
    public class BuyState : ScreenState
    {
        ScreenController screenController;

        Animator animator;

        public BuyState(ScreenController screenController)
        {
            this.screenController = screenController;
        }

        public void Enter()
        {
            screenController.shopView.SetActive(true);
        }

        public void Exit()
        {
            screenController.shopView.SetActive(false);
        }
    }
}

