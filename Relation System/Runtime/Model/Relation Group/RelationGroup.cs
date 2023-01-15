using System;
using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystem
{
    /// <summary>
    /// Группа взаимоотношений.
    /// </summary>
    public sealed class RelationGroup : IRelationGroup
    {
        /// <summary>
        /// Инициализирует группу взаимоотношений.
        /// </summary>
        /// <param name="groupName">Название группы взаимоотношений.</param>
        /// <param name="defaultRelation">Стандартное отношение.</param>
        /// <param name="oneselfRelation">Отношение участников группы к другим участникам 
        /// данной группы.</param>
        /// <param name="priority">Приоритет группы.</param>
        public RelationGroup(
            string groupName,
            IReadOnlyRelationType defaultRelation,
            IReadOnlyRelationType oneselfRelation,
            int priority = 0)
        {
            Rename(groupName);
            SetDefaultRelation(defaultRelation);
            SetOneselfRelation(oneselfRelation);
            Priority = priority;
        }

        public string GroupName { get; private set; }
        public int Priority { get; set; }
        public IReadOnlyRelationType DefaultRelation { get; private set; }
        public IReadOnlyRelationType OneselfRelation { get; private set; }
        public IReadOnlyDictionary<IReadOnlyRelationGroup, IReadOnlyRelationType>
            SpecialRelations { get; private set; }

        private readonly Dictionary<IReadOnlyRelationGroup, IReadOnlyRelationType>
            _specialRelations = new();
        
        public IReadOnlyRelationType this[IReadOnlyRelationGroup group]
        {
            get
            {
                if (group == this)
                {
                    return OneselfRelation;
                }
                else if (_specialRelations.ContainsKey(group))
                {
                    return _specialRelations[group];
                }
                return DefaultRelation;
            }
        }

        public void Rename(string groupName)
        {
            GroupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
        }

        public void SetDefaultRelation(IReadOnlyRelationType defaultRelation)
        {
            DefaultRelation = defaultRelation ??
                throw new ArgumentNullException(nameof(defaultRelation));
        }

        public void SetOneselfRelation(IReadOnlyRelationType oneselfRelation)
        {
            OneselfRelation = oneselfRelation ??
                throw new ArgumentNullException(nameof(oneselfRelation));
        }

        public void SetSpecialRelationWith(
            IReadOnlyRelationGroup group,
            IReadOnlyRelationType relationType)
        {
            if (group == this)
            {
                throw new InvalidOperationException(
                    "Invalid operation: для назначения отношения участников данной группы к " +
                    $"другим участникам данной группы используйте метод {nameof(SetOneselfRelation)}.");
            }
            else if (_specialRelations.ContainsKey(group))
            {
                _specialRelations[group] = relationType;
            }
            else
            {
                _specialRelations.Add(group, relationType);
            }
        }

        public bool RemoveSpecialRelationship(IReadOnlyRelationGroup group)
        {
            return _specialRelations.Remove(group);
        }
    }
}
