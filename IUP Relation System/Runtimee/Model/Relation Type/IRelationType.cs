namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Интерфейс типа отношения.
    /// </summary>
    public interface IRelationType : IReadOnlyRelationType
    {
        /// <summary>
        /// Изменяет название типа отношения.
        /// </summary>
        /// <param name="newTypeName">Новое название типа отношения. Должно быть отличным от null; 
        /// иначе будет вызвано исключение.</param>
        public void Rename(string newTypeName);
    }
}
