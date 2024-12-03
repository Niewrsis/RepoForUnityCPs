using Core;
using PlayerSystem;
using UnityEngine;
using UnityEngine.Events;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        public UnityAction OnStateChanged;

        [SerializeField] private KeyCode attackCode;
        [SerializeField] private KeyCode changeState;

        private Player _player;
        private PlayerMovement _playerMovement = new();
        private IStateMachine _stateMachine;

        public void Constuct(Player player, IStateMachine stateMachine)
        {
            _player = player;
            _stateMachine = stateMachine;
        }
        private void Update()
        {
            ReadMoveInputs();
            ReadChangeStateInput();
            ReadAttackInput();
        }
        private void ReadMoveInputs()
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            float yMove = Input.GetAxisRaw("Vertical");
            _playerMovement.Move(xMove, yMove, _player);
        }
        private void ReadChangeStateInput()
        {
            if(Input.GetKeyDown(changeState))
            {
                _stateMachine.SwitchState();
            }
        }
        private void ReadAttackInput()
        {
            if(Input.GetKeyDown(attackCode))
            {
                OnStateChanged?.Invoke();
            }
        }
    }
}