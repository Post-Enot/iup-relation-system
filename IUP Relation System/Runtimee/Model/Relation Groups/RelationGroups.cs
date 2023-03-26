using System;
using System.Collections;
using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Коллекция групп взаимоотношений.
    /// </summary>
    public sealed class RelationGroups : IRelationGroups
    {
        public int Count => _relationGroupByName.Count;
        public IReadOnlyUsedRelationTypeReferences UsedRelationTypeByGroups =>
            _usedRelationTypeByGroups;

        private readonly Dictionary<string, RelationGroup> _relationGroupByName = new();
        private readonly UsedRelationTypeReferences _usedRelationTypeByGroups = new();

        public IReadOnlyRelationGroup this[string groupName] => _relationGroupByName[groupName];

        public bool Contains(string groupName)
        {
            return _relationGroupByName.ContainsKey(groupName);
        }

        public void RenameGroup(
            string oldRelationGroupName,
            string newRelationGroupName)
        {
            if (!_relationGroupByName.ContainsKey(oldRelationGroupName))
            {
                throw RelationTypeWithNameDoesNotExist(
                    oldRelationGroupName,
                    nameof(oldRelationGroupName));
            }
            else if (_relationGroupByName.ContainsKey(newRelationGroupName))
            {
                throw RelationTypeWithNameAlreadyExist(
                    newRelationGroupName,
                    nameof(newRelationGroupName));
            }
            else if (oldRelationGroupName != newRelationGroupName)
            {
                RelationGroup renamedRelationGroup = _relationGroupByName[oldRelationGroupName];
                renamedRelationGroup.Rename(newRelationGroupName);
                _ = _relationGroupByName.Remove(newRelationGroupName);
                _relationGroupByName.Add(newRelationGroupName, renamedRelationGroup);
            }
        }

        public void AddGroup(
            string relationGroupName,
            IReadOnlyRelationType defaultRelationType,
            IReadOnlyRelationType oneselfRealtionType,
            int priority = 0)
        {
            if (_relationGroupByName.ContainsKey(relationGroupName))
            {
                throw RelationTypeWithNameAlreadyExist(
                    relationGroupName,
                    nameof(relationGroupName));
            }
            var relationType = new RelationGroup(
                relationGroupName,
                defaultRelationType,
                oneselfRealtionType,
                priority);
            _relationGroupByName.Add(relationGroupName, relationType);
        }

        public void RemoveGroup(string relationGroupName)
        {
            bool isContains = _relationGroupByName.ContainsKey(relationGroupName);
            if (isContains)
            {
                RelationGroup relationGroup = _relationGroupByName[relationGroupName];
                _ = _relationGroupByName.Remove(relationGroupName);
                _usedRelationTypeByGroups.RemoveReference(relationGroup);
            }
            else
            {
                throw RelationTypeWithNameDoesNotExist(
                    relationGroupName,
                    nameof(relationGroupName));
            }
        }

        public void SetGroupDefaultRelation(
            string relationGroupName,
            IReadOnlyRelationType defaultRelation)
        {
            RelationGroup relationGroup = _relationGroupByName[relationGroupName];
            relationGroup.SetDefaultRelation(defaultRelation);
            _usedRelationTypeByGroups.AddReference(defaultRelation, relationGroup);
        }

        public void SetGroupOneselfRelation(
            string relationGroupName,
            IReadOnlyRelationType oneselfRelation)
        {
            RelationGroup relationGroup = _relationGroupByName[relationGroupName];
            relationGroup.SetOneselfRelation(oneselfRelation);
            _usedRelationTypeByGroups.AddReference(oneselfRelation, relationGroup);
        }

        public void SetGroupSpecialRelationWith(
            string whoGroupName,
            string withGroupName,
            IReadOnlyRelationType relationType)
        {
            RelationGroup whoRelationGroup = _relationGroupByName[whoGroupName];
            RelationGroup withRelationGroup = _relationGroupByName[withGroupName];
            whoRelationGroup.SetSpecialRelationWith(withRelationGroup, relationType);
            _usedRelationTypeByGroups.AddReference(relationType, whoRelationGroup);
        }

        public bool RemoveGroupSpecialRelationWith(
            string whoGroupName,
            string withGroupName)
        {
            RelationGroup whoRelationGroup = _relationGroupByName[whoGroupName];
            RelationGroup withRelationGroup = _relationGroupByName[withGroupName];
            IReadOnlyRelationType relationType = whoRelationGroup[withRelationGroup];
            _usedRelationTypeByGroups.RemoveReference(whoRelationGroup, relationType);
            return whoRelationGroup.RemoveSpecialRelationship(withRelationGroup);
        }

        public IEnumerator<IReadOnlyRelationGroup> GetEnumerator()
        {
            return _relationGroupByName.Values.GetEnumerator();
        }

        /// <returns>Возвращает перечислитель групп взаимоотношений.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _relationGroupByName.Values.GetEnumerator();
        }

        private ArgumentException RelationTypeWithNameAlreadyExist(
            string relationGroupName,
            string argumentName)
        {
            throw new ArgumentException(
                "Коллекция групп взаимоотношений уже содержит группу с переданным названием " +
                $"({relationGroupName}).",
                argumentName);
        }

        private ArgumentException RelationTypeWithNameDoesNotExist(
            string relationGroupName,
            string argumentName)
        {
            return new ArgumentException(
                "Коллекция групп взаимоотношений не содержит группу с переданным названием " +
                $"({relationGroupName}).",
                argumentName);
        }
    }
}
