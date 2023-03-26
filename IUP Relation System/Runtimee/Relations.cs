using System;

namespace IUP.Toolkits.RelationSystemLegacy
{
    /// <summary>
    /// Класс для инициализации и взаимодействия с системой взаимоотношений.
    /// </summary>
    public sealed class Relations : IRelations
    {
        public IRelationScheme RelationScheme { get; private set; }

        public Relations(IRelationScheme relationScheme)
        {
            RelationScheme = relationScheme ?? throw new ArgumentNullException(nameof(relationScheme));
        }

        public IReadOnlyRelationType this[IRelationMember relationMember]
        {
            get
            {
                return null;
            }
        }
    }
}
