using UnityEngine;

namespace StatePattern.StateScreen
{
    public class ClickerState : ScreenState
    {
        ScreenController screenController;

        public ClickerState(ScreenController screenController)
        {
            this.screenController = screenController;
        }

        public void Enter()
        {
            screenController.manaStone.SetActive(true);
            screenController.monsterView.SetActive(false);
            screenController.shopView.SetActive(false);
        }

        public void Exit()
        {
            screenController.manaStone.SetActive(false);
        }
    }
}
