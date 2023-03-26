using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystemLegacy
{
    public interface IReadOnlyUsedRelationTypeReferences :
        IReadOnlyCollection<IReadOnlyCollection<IReadOnlyRelationGroup>>
    {
        public bool ContainsRelationType(IReadOnlyRelationType relationType);
    }
}
