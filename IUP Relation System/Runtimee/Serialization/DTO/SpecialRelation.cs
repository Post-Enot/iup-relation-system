using System;

namespace IUP.Toolkits.RelationSystemLegacy.Serialization.DTO
{
    [Serializable]
    public sealed record SpecialRelation
    {
        public string relation_group_name;
        public string relation_type_name;
    }
}
