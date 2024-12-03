namespace Core
{
    public interface IStateMachine
    {
        bool ChangeState<T>() where T : AGameState;
        bool SwitchState();
        /*void Update();*/
    }
}