using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem
{
    [Serializable]
    public sealed class RelationGroupBuilder : IRelationGroup
    {
        public RelationGroupBuilder(RelationGroupUnsafeBuilder unsafeBuilder)
        {
            UnsafeBuilder = unsafeBuilder;
        }

        public string GroupName => UnsafeBuilder.GroupName;
        public int Priority => UnsafeBuilder.Priority;
        public IRelationType DefaultRelation => UnsafeBuilder.DefaultRelation;
        public IRelationType OneselfRelation => UnsafeBuilder.OneselfRelation;
        public ReadOnlyDictionary<IRelationGroup, IRelationType> SpecialRelations => UnsafeBuilder.SpecialRelations;

        [field: SerializeReference] internal RelationGroupUnsafeBuilder UnsafeBuilder { get; private set; }

        public IRelationType this[IRelationGroup group] => UnsafeBuilder[group];
    }
}
