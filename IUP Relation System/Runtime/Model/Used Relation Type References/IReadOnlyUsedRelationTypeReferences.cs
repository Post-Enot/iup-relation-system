using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystem
{
    public interface IReadOnlyUsedRelationTypeReferences :
        IReadOnlyCollection<IReadOnlyCollection<IReadOnlyRelationGroup>>
    {
        public bool ContainsRelationType(IReadOnlyRelationType relationType);
    }
}
