namespace IUP.Toolkits.RelationSystem
{
    /// <summary>
    /// Схема взаимоотношений.
    /// </summary>
    public sealed class RelationScheme : IRelationScheme
    {
        public IReadOnlyRelationGroups Groups => _relationGroups;
        public IReadOnlyRelationTypes Types => _relationTypes;

        private readonly RelationGroups _relationGroups = new();
        private readonly RelationTypes _relationTypes = new();

        public void RenameRelationType(
            string oldRelationTypeName,
            string newRelationTypeName)
        {
            _relationTypes.RenameRelationType(oldRelationTypeName, newRelationTypeName);
        }

        public void AddRelationType(string relationTypeName)
        {
            _relationTypes.Add(relationTypeName);
        }

        public void RemoveRelationType(string relationTypeName)
        {
            _relationTypes.Remove(relationTypeName);
            foreach (IReadOnlyRelationGroup relationGroup in _relationGroups)
            {
                _ = _relationGroups.RemoveGroupSpecialRelationWith(
                    relationGroup.GroupName,
                    relationTypeName);
                if (relationGroup.OneselfRelation.TypeName == relationTypeName)
                {
                    _relationGroups.SetGroupOneselfRelation(
                        relationGroup.GroupName,
                        null);
                }
                if (relationGroup.DefaultRelation.TypeName == relationTypeName)
                {
                    _relationGroups.SetGroupDefaultRelation(
                        relationGroup.GroupName,
                        null);
                }
            }
        }

        public void RenameRelationGroup(
            string oldRelationGroupName,
            string newRelationGroupName)
        {
            _relationGroups.RenameGroup(oldRelationGroupName, newRelationGroupName);
        }

        public void RemoveRelationGroup(string relationGroupName)
        {
            _relationGroups.RemoveGroup(relationGroupName);
        }

        public bool RemoveGroupSpecialRelationWith(
            string whoGroupName,
            string withGroupName)
        {
            return _relationGroups.RemoveGroupSpecialRelationWith(whoGroupName, withGroupName);
        }

        public void AddRelationGroup(
            string relationGroupName,
            string defaultRelationTypeName,
            string oneselfRealtionTypeName,
            int priority = 0)
        {
            IReadOnlyRelationType defaultRelationType = _relationTypes[defaultRelationTypeName];
            IReadOnlyRelationType oneselfRelationType = _relationTypes[oneselfRealtionTypeName];
            _relationGroups.AddGroup(
                relationGroupName,
                defaultRelationType,
                oneselfRelationType,
                priority);
        }

        public void SetGroupDefaultRelation(
            string relationGroupName,
            string defaultRelationTypeName)
        {
            IReadOnlyRelationType defaultRelationType = _relationTypes[defaultRelationTypeName];
            _relationGroups.SetGroupDefaultRelation(relationGroupName, defaultRelationType);
        }

        public void SetGroupOneselfRelation(
            string relationGroupName,
            string oneselfRelationTypeName)
        {
            IReadOnlyRelationType oneselfRelationType = _relationTypes[oneselfRelationTypeName];
            _relationGroups.SetGroupOneselfRelation(relationGroupName, oneselfRelationType);
        }

        public void SetGroupSpecialRelationWith(
            string whoGroupName,
            string withGroupName,
            string relationTypeName)
        {
            IReadOnlyRelationType relationType = _relationTypes[relationTypeName];
            _relationGroups.SetGroupSpecialRelationWith(whoGroupName, withGroupName, relationType);
        }
    }
}
