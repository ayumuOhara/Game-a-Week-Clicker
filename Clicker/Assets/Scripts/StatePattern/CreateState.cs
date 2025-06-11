using UnityEngine;

namespace StatePattern.StateScreen
{
    public class CreateState : ScreenState
    {
        ScreenController screenController;


        public CreateState(ScreenController screenController)
        {
            this.screenController = screenController;
        }

        public void Enter()
        {
            screenController.monsterView.SetActive(true);
        }

        public void Exit()
        {
            screenController.monsterView.SetActive(false);
        }
    }
}

