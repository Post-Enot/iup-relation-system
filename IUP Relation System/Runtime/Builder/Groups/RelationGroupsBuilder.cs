using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem
{
    [Serializable]
    public sealed class RelationGroupsBuilder : IRelationGroups
    {
        public RelationGroupsBuilder(RelationGroupsUnsafeBuilder unsafeBuilder)
        {
            UnsafeBuilder = unsafeBuilder;
        }

        public int Count => UnsafeBuilder.Count;

        [field: SerializeReference] internal RelationGroupsUnsafeBuilder UnsafeBuilder { get; private set; }

        public IRelationGroup this[string relationGroupName] => UnsafeBuilder[relationGroupName];

        public bool Contains(string relationGroupName) => UnsafeBuilder.Contains(relationGroupName);

        public IEnumerator<IRelationGroup> GetEnumerator() => UnsafeBuilder.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => UnsafeBuilder.GetEnumerator();
    }
}
