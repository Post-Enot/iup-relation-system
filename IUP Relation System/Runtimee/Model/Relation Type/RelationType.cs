using System;

namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Тип отношения.
    /// </summary>
    public sealed class RelationType : IRelationType
    {
        /// <summary>
        /// Инициализирует тип отношения.
        /// </summary>
        /// <param name="typeName">Название типа отношения. Должно быть отличным от null; иначе 
        /// будет вызвано исключение.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelationType(string typeName)
        {
            Rename(typeName);
        }

        public string TypeName { get; private set; }

        public void Rename(string newTypeName)
        {
            TypeName = newTypeName ?? throw new ArgumentNullException(nameof(newTypeName));
        }
    }
}
