namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс группы взаимоотношений.
    /// </summary>
    public interface IRelationGroup : IReadOnlyRelationGroup
    {
        /// <summary>
        /// Переименовывает группу взаимоотношений.
        /// </summary>
        /// <param name="groupName">Новое название группы взаимоотношений.</param>
        public void Rename(string groupName);

        /// <summary>
        /// Инициализирует стандартное отношение группы взаимоотношений.
        /// </summary>
        /// <param name="defaultRelation">Тип отношения.</param>
        public void SetDefaultRelation(IReadOnlyRelationType defaultRelation);

        /// <summary>
        /// Инициализирует отношение участников данной группы к другим участникам данной группы.
        /// </summary>
        /// <param name="oneselfRelation">Тип отношения.</param>
        public void SetOneselfRelation(IReadOnlyRelationType oneselfRelation);

        /// <summary>
        /// Инициализирует особенное отношение к группе взаимоотношений.
        /// </summary>
        /// <param name="group">Группа взаимоотношений.</param>
        /// <param name="relationType">Тип отношения.</param>
        public void SetSpecialRelationWith(
            IReadOnlyRelationGroup group,
            IReadOnlyRelationType relationType);

        /// <summary>
        /// Удаляет особенное отношение к группе взаимоотношений.
        /// </summary>
        /// <param name="group">Группа взаимоотношений.</param>
        /// <returns>Возвращает true, если удаление произошло успешно; иначе false.</returns>
        public bool RemoveSpecialRelationship(IReadOnlyRelationGroup group);
    }
}
