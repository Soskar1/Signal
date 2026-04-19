namespace Signal.Core.Buildings.Domain
{
    internal interface IBuildingAction
    {
        public void Tick(double deltaTime);
        public void Execute();
    }
}