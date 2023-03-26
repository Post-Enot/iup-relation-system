using System;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem
{
    [Serializable]
    public class RelationTypeBuilder : IRelationType
    {
        public RelationTypeBuilder(RelationTypeUnsafeBuilder unsafeBuilder)
        {
            UnsafeBuilder = unsafeBuilder;
        }

        public string TypeName => UnsafeBuilder.TypeName;

        [field: SerializeReference] internal RelationTypeUnsafeBuilder UnsafeBuilder { get; private set; }
    }
}
