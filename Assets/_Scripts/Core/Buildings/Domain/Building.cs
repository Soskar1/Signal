namespace Signal.Core.Buildings.Domain
{
    internal class Building
    {
        private readonly string _id;
        private readonly IBuildingAction _buildingAction;

        public Building(string id, IBuildingAction buildingAction)
        {
            _id = id;
            _buildingAction = buildingAction;
        }

        public void Tick(double deltaTime)
        {
            _buildingAction.Tick(deltaTime);
        }
    }
}
