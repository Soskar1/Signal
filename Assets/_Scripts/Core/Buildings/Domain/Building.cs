namespace Signal.Core.Buildings.Domain
{
    internal class Building
    {
        private readonly string _id;
        private readonly BuildingAction _buildingAction;

        public Building(string id, BuildingAction buildingAction)
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
