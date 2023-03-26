using System;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem
{
    [Serializable]
    public class RelationTypeUnsafeBuilder : IRelationType
    {
        public RelationTypeUnsafeBuilder(string relationTypeName)
        {
            TypeName = relationTypeName;
        }

        public string TypeName
        {
            get => _typeName;
            set => _typeName = value ?? throw new ArgumentNullException(nameof(value));
        }

        [SerializeField] private string _typeName;
    }
}
