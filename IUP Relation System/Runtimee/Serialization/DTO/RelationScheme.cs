using System;

namespace IUP.Toolkits.RelationSystemLegacy.Serialization.DTO
{
    [Serializable]
    public sealed record RelationScheme
    {
        public string data_format_version;
        public RelationType[] relation_types;
        public RelationGroup[] relation_groups;
    }
}
