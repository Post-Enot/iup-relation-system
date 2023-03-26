namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс схемы взаимоотношений.
    /// </summary>
    public interface IRelationScheme : IReadOnlyRelationScheme
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
        public void AddRelationType(string relationTypeName);

        /// <summary>
        /// Удаляет тип отношения из коллекции по названию типа.
        /// </summary>
        /// <param name="relationTypeName">Название типа отношения.</param>
        public void RemoveRelationType(string relationTypeName);

        /// <summary>
        /// Переименовывает группу взаимоотношений.
        /// </summary>
        /// <param name="oldRelationGroupName">Название переименовываемой группы взаимоотношений.</param>
        /// <param name="newRelationGroupName">Новое название группы взаимоотношений.</param>
        public void RenameRelationGroup(
            string oldRelationGroupName,
            string newRelationGroupName);

        /// <summary>
        /// Добавляет новую группу взаимоотношений в коллекцию.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        /// <param name="defaultRelationTypeName">Название стандартного типа отношения группы.</param>
        /// <param name="oneselfRealtionTypeName">Название отношения участников группы взаимоотношений к 
        /// другим участникам данной группы.</param>
        /// <param name="priority">Приоритет группы взаимоотношений.</param>
        public void AddRelationGroup(
            string relationGroupName,
            string defaultRelationTypeName,
            string oneselfRealtionTypeName,
            int priority = 0);

        /// <summary>
        /// Удаляет группу взаимоотношений с переданным названием из коллекции.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        public void RemoveRelationGroup(string relationGroupName);

        /// <summary>
        /// Инициализирует стандартное отношение группы взаимоотношений.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        /// <param name="defaultRelationTypeName">Название типа отношения.</param>
        public void SetGroupDefaultRelation(
            string relationGroupName,
            string defaultRelationTypeName);

        /// <summary>
        /// Инициализирует отношение участников данной группы к другим участникам данной группы.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        /// <param name="oneselfRelationTypeName">Название типа отношения.</param>
        public void SetGroupOneselfRelation(
            string relationGroupName,
            string oneselfRelationTypeName);

        /// <summary>
        /// Инициализирует особенное отношение к группе взаимоотношений.
        /// </summary>
        /// <param name="whoGroupName">Название группы взаимоотношений, у которой инициализируется
        /// отношение.</param>
        /// <param name="withGroupName">Название группы взаимоотношений, к которой инициализируется
        /// отношение.</param>
        /// <param name="relationTypeName">Название типа отношения.</param>
        public void SetGroupSpecialRelationWith(
            string whoGroupName,
            string withGroupName,
            string relationTypeName);

        /// <summary>
        /// Удаляет особенное отношение к группе взаимоотношений.
        /// </summary>
        /// <param name="whoGroupName">Название группы взаимоотношений, у которой удаляется
        /// отношение.</param>
        /// <param name="withGroupName">Название группы взаимоотношений, к которой удаляется
        /// отношение.</param>
        /// <returns>Возвращает true, если удаление произошло успешно; иначе false.</returns>
        public bool RemoveGroupSpecialRelationWith(
            string whoGroupName,
            string withGroupName);
    }
}
