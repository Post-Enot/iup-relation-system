namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс неизменямого типа отношения.
    /// </summary>
    public interface IReadOnlyRelationType
    {

        /// <summary>
        /// Названине типа отношения.
        /// </summary>
        public string TypeName { get; }
    }
}
