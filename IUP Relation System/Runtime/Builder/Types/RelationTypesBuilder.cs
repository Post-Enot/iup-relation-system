using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem
{
    [Serializable]
    public sealed class RelationTypesBuilder : IRelationTypes
    {
        public RelationTypesBuilder(RelationTypesUnsafeBuilder unsafeBuilder)
        {
            UnsafeBuilder = unsafeBuilder;
        }

        public int Count => UnsafeBuilder.Count;

        [field: SerializeReference] internal RelationTypesUnsafeBuilder UnsafeBuilder { get; private set; }

        public IRelationType this[string relationTypeName] => UnsafeBuilder[relationTypeName];

        public bool Contains(string relationTypeName) => UnsafeBuilder.Contains(relationTypeName);

        public void AddRelationType(string relationTypeName) =>
            UnsafeBuilder.AddRelationType(relationTypeName);

        public void RemoveRelationType(string relationTypeName) =>
            UnsafeBuilder.RemoveRelationType(relationTypeName);

        public void RenameRelationType(
            string oldRelationTypeName,
            string newRelationTypeName) => UnsafeBuilder.RenameRelationType(
                oldRelationTypeName,
                newRelationTypeName);

        public IEnumerator<IRelationType> GetEnumerator() => UnsafeBuilder.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => UnsafeBuilder.GetEnumerator();
    }
}
