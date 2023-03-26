using System;

namespace IUP.Toolkits.RelationSystem
{
    public sealed class RelationType : IRelationType
    {
        public RelationType(string typeName)
        {
            TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
        }

        public string TypeName { get; }
    }
}
