using InputSystem;
using PlayerSystem;
using UnityEngine;
using Visual;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private StateText stateText;

        private IStateMachine _stateMachine;
        private void Awake()
        {
            ShootState shootState = new ShootState();
            CircleState circleState = new CircleState(player, inputListener);
            TransparentState transparentState = new TransparentState(player, inputListener);

            _stateMachine = new StateMachine<AGameState>(shootState, circleState, transparentState, stateText);

            StartGame();

            InputSystem();
        }
        private void StartGame() => _stateMachine.ChangeState<ShootState>();
        private void InputSystem() => inputListener.Constuct(player, _stateMachine);
        /*private void Update()
        {
            _stateMachine.Update();
        }*/
    }
}