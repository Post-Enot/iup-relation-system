using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystem
{
    public interface IRelationGroups : IReadOnlyCollection<IRelationGroup>
    {
        public IRelationGroup this[string relationGroupName] { get; }

        public bool Contains(string relationGroupName);
    }
}
