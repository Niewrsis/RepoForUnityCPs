using System;
using System.Collections.Generic;
using Visual;

namespace Core
{
    public class StateMachine<T> : IStateMachine where T : AGameState
    {
        private readonly Dictionary<Type, T> _states;
        private T _currentState;
        private StateText _stateText;

        public StateMachine(ShootState shootState, CircleState circleState, TransparentState transparentState, StateText stateText)
        {
            _states = new()
            {
                { typeof(ShootState), shootState as T },
                { typeof(CircleState), circleState as T},
                { typeof(TransparentState), transparentState as T }
            };

            InitStates();

            _stateText = stateText;
            _stateText.DrawState("Shoot State");
        }
        private void InitStates()
        {
            foreach (var state in _states)
            {
                state.Value.InjectOwner(this);
            }
        }
        public bool ChangeState<T>() where T : AGameState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                _currentState?.Exit();
                _currentState = _states[typeof(T)];
                _currentState.Enter();
                return true;
            }
            return false;
        }
        public bool SwitchState()
        {
            if(_currentState == _states[typeof(ShootState)])
            {
                ChangeState<CircleState>();
                _stateText.DrawState("Circle State");
                return true;
            }
            else if(_currentState == _states[typeof(CircleState)])
            {
                ChangeState<TransparentState>();
                _stateText.DrawState("Transparent State");
                return true;
            }
            else if(_currentState == _states[typeof(TransparentState)])
            {
                ChangeState<ShootState>();
                _stateText.DrawState("Shoot State");
                return true;
            }
            return false;
        }

        /*public void Update()
        {
            _currentState.Update();
        }*/
    }
}