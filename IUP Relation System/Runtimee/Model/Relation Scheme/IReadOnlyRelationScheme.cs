namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс неизменямой схемы взаимоотношений.
    /// </summary>
    public interface IReadOnlyRelationScheme
    {
        /// <summary>
        /// Коллекция групп взаимоотношений.
        /// </summary>
        public IReadOnlyRelationGroups Groups { get; }
        /// <summary>
        /// Коллекция типов отношений.
        /// </summary>
        public IReadOnlyRelationTypes Types { get; }
    }
}
