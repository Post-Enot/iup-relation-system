using System;
using System.Collections.ObjectModel;
using IUP.Toolkits.SerializableCollections;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem
{
    [Serializable]
    public sealed class RelationGroupUnsafeBuilder : IRelationGroup
    {
        public RelationGroupUnsafeBuilder(
            string relationGroupName,
            IRelationType defaultRelation,
            IRelationType oneselfRelation,
            int priority = 0)
        {
            GroupName = relationGroupName;
            DefaultRelation = defaultRelation;
            OneselfRelation = oneselfRelation;
            Priority = priority;
        }

        public string GroupName
        {
            get => _groupName;
            set => _groupName = value ?? throw new ArgumentNullException(nameof(value));
        }
        public int Priority { get; set; }
        public ReadOnlyDictionary<IRelationGroup, IRelationType> SpecialRelations
        {
            get
            {
                _specialRelationsReadOnlyDictionary ??=
                        new ReadOnlyDictionary<IRelationGroup, IRelationType>(_specialRelations.Value);
                return _specialRelationsReadOnlyDictionary;
            }
        }
        [field: SerializeReference] public IRelationType DefaultRelation { get; set; }
        [field: SerializeReference] public IRelationType OneselfRelation { get; set; }

        [SerializeField] private SRK_SRV_Dictionary<IRelationGroup, IRelationType> _specialRelations = new();
        [SerializeField] private string _groupName;

        private ReadOnlyDictionary<IRelationGroup, IRelationType> _specialRelationsReadOnlyDictionary;

        public IRelationType this[IRelationGroup group]
        {
            get
            {
                if (group == this)
                {
                    return OneselfRelation;
                }
                else if (SpecialRelations.ContainsKey(group))
                {
                    return SpecialRelations[group];
                }
                return DefaultRelation;
            }
        }

        public void SetSpecialRelationWith(
            IRelationGroup relationGroup,
            IRelationType relationType)
        {
            if (relationGroup == this)
            {
                throw new InvalidOperationException(
                    "Invalid operation: для назначения отношения участников данной группы к " +
                    $"другим участникам данной группы используйте свойство {nameof(OneselfRelation)}.");
            }
            else if (SpecialRelations.ContainsKey(relationGroup))
            {
                _specialRelations.Value[relationGroup] = relationType;
            }
            else
            {
                _specialRelations.Value.Add(relationGroup, relationType);
            }
        }

        public bool RemoveSpecialRelations(IRelationGroup group) => _specialRelations.Value.Remove(group);
    }
}
