using UnityEngine;

namespace StatePattern.StateScreen
{
    public class ScreenController : MonoBehaviour
    {
        private ScreenStateMachine stateMachine;
        public ScreenStateMachine ScreenStateMachine => stateMachine;

        public GameObject manaStone;
        public GameObject monsterView;
        public GameObject shopView;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            stateMachine = new ScreenStateMachine(this);
            stateMachine.Initialize(stateMachine.clickerState);
        }

        private void Update()
        {
            stateMachine.Update();
        }

        // モンスター作成・採掘・ショップボタンが押下されたときの処理
        public void OnClickMenu(int num)
        {
            switch (num)
            {
                case 0:
                    stateMachine.TransitionTo(stateMachine.clickerState);
                    break;
                case 1:
                    stateMachine.TransitionTo(stateMachine.createState);
                    break;
                case 2:
                    stateMachine.TransitionTo(stateMachine.buyState);
                    break;
                default:
                    Debug.LogError("不正なボタンです");
                    break;
            }
        }
    }
}

