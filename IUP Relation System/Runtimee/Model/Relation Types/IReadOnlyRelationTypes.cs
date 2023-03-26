using System.Collections.Generic;

namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс неизменяемой коллекции типов отношений.
    /// </summary>
    public interface IReadOnlyRelationTypes : IReadOnlyCollection<IReadOnlyRelationType>
    {
        /// <summary>
        /// Количество типов отношений.
        /// </summary>
        public new int Count { get; }

        /// <summary>
        /// Индексатор для доступа к типам отношений по названию типа.
        /// </summary>
        /// <param name="typeName">Название типа отношения.</param>
        /// <returns>Возвращает тип отношения по названию типа.</returns>
        public IReadOnlyRelationType this[string typeName] { get; }

        /// <summary>
        /// Проверяет, содержит ли коллекция тип отношения с переданным названием.
        /// </summary>
        /// <param name="relationTypeName">Название типа отношения.</param>
        /// <returns>Возвращает true, если коллекция содержит тип отношения с переданным названием; 
        /// иначе false.</returns>
        public bool Contains(string relationTypeName);

        /// <returns>Возвращает нумератор типов отношений.</returns>
        public new IEnumerator<IReadOnlyRelationType> GetEnumerator();
    }
}
