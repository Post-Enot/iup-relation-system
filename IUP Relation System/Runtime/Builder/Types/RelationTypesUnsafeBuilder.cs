using System;
using System.Collections;
using System.Collections.Generic;
using IUP.Toolkits.SerializableCollections;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem
{
    [Serializable]
    public sealed class RelationTypesUnsafeBuilder : IRelationTypes
    {
        public int Count => TypeBuilderByName.Count;

        private Dictionary<string, RelationTypeBuilder> TypeBuilderByName => _typeBuilderByName.Value;

        [SerializeField] private SK_SRV_Dictionary<string, RelationTypeBuilder> _typeBuilderByName = new();

        public IRelationType this[string relationTypeName] => TypeBuilderByName[relationTypeName];

        public bool Contains(string relationTypeName) => TypeBuilderByName.ContainsKey(relationTypeName);

        public void AddRelationType(string relationTypeName)
        {
            if (TypeBuilderByName.ContainsKey(relationTypeName))
            {
                throw RelationTypeWithNameAlreadyExist(
                    relationTypeName,
                    nameof(relationTypeName));
            }
            RelationTypeUnsafeBuilder unsafeTypeBuilder = new(relationTypeName);
            RelationTypeBuilder typeBuilder = new(unsafeTypeBuilder);
            TypeBuilderByName.Add(relationTypeName, typeBuilder);
        }

        public void RemoveRelationType(string relationTypeName)
        {
            bool isRemoveSuccessful = TypeBuilderByName.Remove(relationTypeName);
            if (!isRemoveSuccessful)
            {
                throw RelationTypeWithNameDoesNotExist(
                    relationTypeName,
                    nameof(relationTypeName));
            }
        }

        public void RenameRelationType(
            string oldRelationTypeName,
            string newRelationTypeName)
        {
            if (!TypeBuilderByName.ContainsKey(oldRelationTypeName))
            {
                throw RelationTypeWithNameDoesNotExist(
                    oldRelationTypeName,
                    nameof(oldRelationTypeName));
            }
            else if (TypeBuilderByName.ContainsKey(newRelationTypeName))
            {
                throw RelationTypeWithNameAlreadyExist(
                    newRelationTypeName,
                    nameof(newRelationTypeName));
            }
            else if (oldRelationTypeName != newRelationTypeName)
            {
                RelationTypeBuilder renamedRelationTypeUnsafeBuilder = TypeBuilderByName[oldRelationTypeName];
                renamedRelationTypeUnsafeBuilder.UnsafeBuilder.TypeName = newRelationTypeName;
                _ = TypeBuilderByName.Remove(oldRelationTypeName);
                TypeBuilderByName.Add(newRelationTypeName, renamedRelationTypeUnsafeBuilder);
            }
        }

        public IEnumerator<IRelationType> GetEnumerator() => TypeBuilderByName.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => TypeBuilderByName.Values.GetEnumerator();

        private ArgumentException RelationTypeWithNameAlreadyExist(
            string relationTypeName,
            string argumentName) => new(
                "Коллекция типов отношений уже содержит тип с переданным названием типа " +
                $"({relationTypeName}).",
                argumentName);

        private ArgumentException RelationTypeWithNameDoesNotExist(
            string relationTypeName,
            string argumentName) => new(
                "Коллекция типов отношений не содержит тип с переданным названием типа" +
                $"({relationTypeName}).",
                argumentName);
    }
}
