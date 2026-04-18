namespace Signal.Core.Buildings.Domain
{
    public interface IBuildingAction
    {
        public void Tick(double deltaTime);
        public void Execute();
    }
}