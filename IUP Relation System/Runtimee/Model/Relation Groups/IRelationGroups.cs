namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс коллекции групп взаимоотношений.
    /// </summary>
    public interface IRelationGroups : IReadOnlyRelationGroups
    {
        /// <summary>
        /// Переименовывает группу взаимоотношений.
        /// </summary>
        /// <param name="oldRelationGroupName">Название переименовываемой группы взаимоотношений.</param>
        /// <param name="newRelationGroupName">Новое название группы взаимоотношений.</param>
        public void RenameGroup(
            string oldRelationGroupName,
            string newRelationGroupName);

        /// <summary>
        /// Добавляет новую группу взаимоотношений в коллекцию.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        /// <param name="defaultRelationType">Стандартный тип отношения группы.</param>
        /// <param name="oneselfRealtionType">Отношение участников группы взаимоотношений к 
        /// другим участникам данной группы.</param>
        /// <param name="priority">Приоритет группы взаимоотношений.</param>
        public void AddGroup(
            string relationGroupName,
            IReadOnlyRelationType defaultRelationType,
            IReadOnlyRelationType oneselfRealtionType,
            int priority = 0);

        /// <summary>
        /// Удаляет группу взаимоотношений с переданным названием из коллекции.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        public void RemoveGroup(string relationGroupName);

        /// <summary>
        /// Инициализирует стандартное отношение группы взаимоотношений.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        /// <param name="defaultRelation">Тип отношения.</param>
        public void SetGroupDefaultRelation(
            string relationGroupName,
            IReadOnlyRelationType defaultRelation);

        /// <summary>
        /// Инициализирует отношение участников данной группы к другим участникам данной группы.
        /// </summary>
        /// <param name="relationGroupName">Название группы взаимоотношений.</param>
        /// <param name="oneselfRelation">Тип отношения.</param>
        public void SetGroupOneselfRelation(
            string relationGroupName,
            IReadOnlyRelationType oneselfRelation);

        /// <summary>
        /// Инициализирует особенное отношение к группе взаимоотношений.
        /// </summary>
        /// <param name="whoGroupName">Название группы взаимоотношений, у которой инициализируется
        /// отношение.</param>
        /// <param name="withGroupName">Название группы взаимоотношений, к которой инициализируется
        /// отношение.</param>
        /// <param name="relationType">Тип отношения.</param>
        public void SetGroupSpecialRelationWith(
            string whoGroupName,
            string withGroupName,
            IReadOnlyRelationType relationType);

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
