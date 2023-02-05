using System.Collections;
using System.Collections.Generic;
using Mono.Collections.Generic;

namespace IUP.Toolkits.RelationSystem
{
    public sealed class UsedRelationTypeReferences : IReadOnlyUsedRelationTypeReferences
    {
        public int Count => _usedRelationTypeByGroups.Count;

        private readonly Dictionary<IReadOnlyRelationType, HashSet<IReadOnlyRelationGroup>>
            _usedRelationTypeByGroups = new();

        public IReadOnlyCollection<IReadOnlyRelationGroup> this[IReadOnlyRelationType relationType]
            => _usedRelationTypeByGroups[relationType];

        public void AddReference(
            IReadOnlyRelationType relationType,
            IReadOnlyRelationGroup relationGroup)
        {
            bool isCollectionContains = _usedRelationTypeByGroups.ContainsKey(relationType);
            if (!isCollectionContains)
            {
                _usedRelationTypeByGroups[relationType] = new HashSet<IReadOnlyRelationGroup>();
            }
            _ = _usedRelationTypeByGroups[relationType].Add(relationGroup);
        }

        public void RemoveReference(IReadOnlyRelationGroup relationGroup)
        {
            var keys = new Collection<IReadOnlyRelationType>(_usedRelationTypeByGroups.Keys);
            foreach (IReadOnlyRelationType key in keys)
            {
                RemoveReference(relationGroup, key);
            }
        }

        public void RemoveReference(
            IReadOnlyRelationGroup relationGroup,
            IReadOnlyRelationType relationType)
        {
            HashSet<IReadOnlyRelationGroup> referenceSet = _usedRelationTypeByGroups[relationType];
            _ = referenceSet.Remove(relationGroup);
            if (referenceSet.Count == 0)
            {
                _ = _usedRelationTypeByGroups.Remove(relationType);
            }
        }

        public bool ContainsRelationType(IReadOnlyRelationType relationType)
        {
            return _usedRelationTypeByGroups.ContainsKey(relationType);
        }

        IEnumerator<IReadOnlyCollection<IReadOnlyRelationGroup>>
            IEnumerable<IReadOnlyCollection<IReadOnlyRelationGroup>>.GetEnumerator()
        {
            return _usedRelationTypeByGroups.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _usedRelationTypeByGroups.Values.GetEnumerator();
        }
    }
}
