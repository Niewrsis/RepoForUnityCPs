using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class TransparentState : AGameState
    {
        private Player _player;
        private InputListener _inputListener;
        private Color _baseColor;
        private bool _isChanged;
        public TransparentState(Player player, InputListener inputListener)
        {
            _player = player;
            _inputListener = inputListener;
        }
        public override void Enter()
        {
            _inputListener.OnStateChanged += ChangeTransparancy;
        }
        public override void Exit()
        {
            _isChanged = true;
            ChangeTransparancy();
            _inputListener.OnStateChanged -= ChangeTransparancy;
        }
        private void ChangeTransparancy()
        {
            if(_isChanged == false)
            {
                _baseColor = _player.Sr.color;
                _player.Sr.color = new Color(_baseColor.r, _baseColor.g, _baseColor.b, _baseColor.a - .75f);
                _isChanged = true;
            }
            else
            {
                _player.Sr.color = _baseColor;
                _isChanged = false;
            }
        }
    }
}
