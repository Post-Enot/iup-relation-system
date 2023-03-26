using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс неизменямой группы взаимоотношений.
    /// </summary>
    public interface IReadOnlyRelationGroup
    {
        /// <summary>
        /// Название группы взаимоотношений.
        /// </summary>
        public string GroupName { get; }
        /// <summary>
        /// Приоритет группы взаимоотношений: в случае, если участник взаимоотношений имеет несколько 
        /// групп взаимоотношений, будет выбран вид взаимоотношений из группы с наибольшим численным 
        /// значением приоритета.
        /// </summary>
        public int Priority { get; }
        /// <summary>
        /// Стандартный тип отношения ко всем группам взаимоотношений, которым не назначено особое
        /// отношение.
        /// </summary>
        public IReadOnlyRelationType DefaultRelation { get; }
        /// <summary>
        /// Отношение участников взаимоотношений данной группы взаимоотношений к другим участникам
        /// из этой группы.
        /// </summary>
        public IReadOnlyRelationType OneselfRelation { get; }
        /// <summary>
        /// Словарь особенных отношений к конкретным группам взаимоотношений.
        /// </summary>
        public IReadOnlyDictionary<IReadOnlyRelationGroup, IReadOnlyRelationType> SpecialRelations { get; }

        /// <summary>
        /// Индексатор для доступа к типу отношения соответсветствующей групе взаимоотношений.
        /// </summary>
        /// <param name="group">Группа взаимоотношений.</param>
        /// <returns>Возвращает тип отношения, соответствующий группе взаимоотношений.</returns>
        public IReadOnlyRelationType this[IReadOnlyRelationGroup group] { get; }
    }
}
