namespace Signal.Core.Buildings.Domain
{
    internal class EmptyAction : IBuildingAction
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void Tick(double deltaTime) { }
    }
}
