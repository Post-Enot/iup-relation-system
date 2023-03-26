using System;
using System.Collections;
using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Коллекция типов отношений.
    /// </summary>
    public sealed class RelationTypes : IRelationTypes
    {
        public int Count => _relationTypeByName.Count;

        private readonly Dictionary<string, RelationType> _relationTypeByName = new();

        public IReadOnlyRelationType this[string typeName] => _relationTypeByName[typeName];

        public bool Contains(string relationTypeName)
        {
            return _relationTypeByName.ContainsKey(relationTypeName);
        }

        public void RenameRelationType(
            string oldRelationTypeName,
            string newRelationTypeName)
        {
            if (!_relationTypeByName.ContainsKey(oldRelationTypeName))
            {
                throw RelationTypeWithNameDoesNotExist(
                    oldRelationTypeName,
                    nameof(oldRelationTypeName));
            }
            else if (_relationTypeByName.ContainsKey(newRelationTypeName))
            {
                throw RelationTypeWithNameAlreadyExist(
                    newRelationTypeName,
                    nameof(newRelationTypeName));
            }
            else if (oldRelationTypeName != newRelationTypeName)
            {
                RelationType renamedRelationType = _relationTypeByName[oldRelationTypeName];
                renamedRelationType.Rename(newRelationTypeName);
                _ = _relationTypeByName.Remove(oldRelationTypeName);
                _relationTypeByName.Add(newRelationTypeName, renamedRelationType);
            }
        }

        public void Add(string relationTypeName)
        {
            if (_relationTypeByName.ContainsKey(relationTypeName))
            {
                throw RelationTypeWithNameAlreadyExist(
                    relationTypeName,
                    nameof(relationTypeName));
            }
            var relationType = new RelationType(relationTypeName);
            _relationTypeByName.Add(relationTypeName, relationType);
        }

        public void Remove(string relationTypeName)
        {
            bool isRemoveSuccessful = _relationTypeByName.Remove(relationTypeName);
            if (!isRemoveSuccessful)
            {
                throw RelationTypeWithNameDoesNotExist(
                    relationTypeName,
                    nameof(relationTypeName));
            }
        }

        public IEnumerator<IReadOnlyRelationType> GetEnumerator()
        {
            return _relationTypeByName.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _relationTypeByName.Values.GetEnumerator();
        }

        private ArgumentException RelationTypeWithNameAlreadyExist(
            string relationTypeName,
            string argumentName)
        {
            throw new ArgumentException(
                "Коллекция типов отношений уже содержит тип с переданным названием типа " +
                $"({relationTypeName}).",
                argumentName);
        }

        private ArgumentException RelationTypeWithNameDoesNotExist(
            string relationTypeName,
            string argumentName)
        {
            return new ArgumentException(
                "Коллекция типов отношений не содержит тип с переданным названием типа" +
                $"({relationTypeName}).",
                argumentName);
        }
    }
}
