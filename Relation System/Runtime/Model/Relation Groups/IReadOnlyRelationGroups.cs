using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystem
{
    /// <summary>
    /// Интерфейс неизменямой коллекции групп взаимоотношений.
    /// </summary>
    public interface IReadOnlyRelationGroups : IReadOnlyCollection<IReadOnlyRelationGroup>
    {
        /// <summary>
        /// Количество групп взаимоотношений.
        /// </summary>
        public new int Count { get; }

        /// <summary>
        /// Индексатор для доступа к группам взаимоотношений по переданному названию группы.
        /// </summary>
        /// <param name="groupName">Название группы взаимоотношений.</param>
        /// <returns>Возвращает группу взаимоотношений по переданному 
        /// названию группы.</returns>
        public IReadOnlyRelationGroup this[string groupName] { get; }

        /// <summary>
        /// Проверяет, содержит ли коллекция группу взаимоотношений с переданным названием.
        /// </summary>
        /// <param name="groupName">Название группы взаимоотношений.</param>
        /// <returns>Возвращает true, если коллекция содержит группу с переданным названием; 
        /// иначе false.</returns>
        public bool Contains(string groupName);

        /// <returns>Возвращает нумератор групп взаимоотношений.</returns>
        public new IEnumerator<IReadOnlyRelationGroup> GetEnumerator();
    }
}
