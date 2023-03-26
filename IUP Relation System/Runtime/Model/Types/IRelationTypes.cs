using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystem
{
    public interface IRelationTypes : IReadOnlyCollection<IRelationType>
    {
        public IRelationType this[string relationTypeName] { get; }

        public bool Contains(string relationTypeName);
    }
}
