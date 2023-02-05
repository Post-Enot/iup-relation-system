namespace IUP.Toolkits.RelationSystem
{
    /// <summary>
    /// Интерфейс класс для взаимодействия с системой взаимоотношений.
    /// </summary>
    public interface IRelations
    {
        public IRelationScheme RelationScheme { get; }

        /// <summary>
        /// Индексатор для доступа к соответствующему виду взаимоотношений к переданному участнику 
        /// взаимоотношений.
        /// </summary>
        /// <param name="relationMember">Участник взаимоотношений.</param>
        /// <returns>Возвращает соответствующий вид взаимоотношений к переданному участнику 
        /// взаимоотношений.</returns>
        public IReadOnlyRelationType this[IRelationMember relationMember] { get; }
    }
}
