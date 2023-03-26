namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс коллекции типов отношений.
    /// </summary>
    public interface IRelationTypes : IReadOnlyRelationTypes
    {
        /// <summary>
        /// Переименовывает название типа отношения.
        /// </summary>
        /// <param name="oldRelationTypeName">Название переименовываемого типа отношения.</param>
        /// <param name="newRelationTypeName">Новое название типа отношения.</param>
        public void RenameRelationType(
            string oldRelationTypeName,
            string newRelationTypeName);

        /// <summary>
        /// Добавляет новый тип отношения в коллекцию.
        /// </summary>
        /// <param name="relationTypeName">Название типа отношения.</param>
        public void Add(string relationTypeName);

        /// <summary>
        /// Удаляет тип отношения из коллекции по названию типа.
        /// </summary>
        /// <param name="relationTypeName">Название типа отношения.</param>
        public void Remove(string relationTypeName);
    }
}
