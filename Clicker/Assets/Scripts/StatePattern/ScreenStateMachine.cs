using UnityEngine;

namespace StatePattern.StateScreen
{
    public class ScreenStateMachine
    {
        public ScreenState CurrentState { get; private set; }

        public ClickerState clickerState;
        public CreateState createState;
        public BuyState buyState;

        public ScreenStateMachine(ScreenController screenController)
        {
            this.clickerState = new ClickerState(screenController);
            this.createState = new CreateState(screenController);
            this.buyState = new BuyState(screenController);
        }

        public void Initialize(ScreenState state)
        {
            CurrentState = state;
            state.Enter();
        }

        public void Update()
        {
            CurrentState?.Update();
        }

        public void TransitionTo(ScreenState state)
        {
            CurrentState.Exit();
            if (CurrentState == state)
            {
                CurrentState = clickerState;
            }
            else
            {
                CurrentState = state;
            }
            CurrentState.Enter();
        }
    }
}

