using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class CircleState : AGameState
    {
        private Player _player;
        private InputListener _inputListener;
        private bool _isChanged;

        public CircleState(Player player, InputListener inputListener)
        {
            _player = player;
            _inputListener = inputListener;
        }

        public override void Enter()
        {
            _inputListener.OnStateChanged += ChangeCircle;
        }
        public override void Exit()
        {
            _isChanged = true;
            ChangeCircle();
            _inputListener.OnStateChanged -= ChangeCircle;
        }
        private void ChangeCircle()
        {
            if(!_isChanged)
            {
                _player.GetCirclePlayerArea().SetActive(true);
                _isChanged = true;
            }
            else
            {
                _player.GetCirclePlayerArea().SetActive(false);
                _isChanged = false;
            }
        }
    }
}