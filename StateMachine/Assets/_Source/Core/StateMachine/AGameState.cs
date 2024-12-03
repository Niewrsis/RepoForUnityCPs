namespace Core
{
    public abstract class AGameState
    {
        protected IStateMachine Owner;
        public void InjectOwner(IStateMachine owner)
        {
            Owner = owner;
        }
        public virtual void Enter() { }
        /*public virtual void Update() { }*/
        public virtual void Exit() { }
    }
}