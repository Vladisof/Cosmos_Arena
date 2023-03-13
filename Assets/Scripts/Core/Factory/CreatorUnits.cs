using System.Collections.Generic;
using Units;

namespace Core.Factory
{
    public class CreatorUnits : ICreatorUnits
    {
        private readonly DataSpawnUnits _dataSpawnUnits;
        private Dictionary<TypeUnit, ICreatorTypeUnit> _listCreators;

        public CreatorUnits(DataSpawnUnits dataSpawnUnits)
        {
            _dataSpawnUnits = dataSpawnUnits;
            InitListCreators();
        }

        private void InitListCreators()
        {
            _listCreators = new Dictionary<TypeUnit, ICreatorTypeUnit>
                {
                    { TypeUnit.Player, new CreatorPlayerUnit(_dataSpawnUnits.Player) },
                    { TypeUnit.Blue, new CreatorBlueUnit(_dataSpawnUnits.Blue) },
                    { TypeUnit.Red, new CreatorRedUnit(_dataSpawnUnits.Red) },
                };
        }
        
        public Unit CreateUnit(TypeUnit typeUnit)
        {
            var creator = _listCreators[typeUnit];
            return creator.CreateUnit();
        }
    }
}