using System;

namespace IUP.Toolkits.RelationSystem.Serialization.DTO
{
    [Serializable]
    public sealed record RelationGroup
    {
        public string relation_group_name;
        public string oneself_relation_type_name;
        public string default_relation_type_name;
        public int priority;
        public SpecialRelation[] special_relations;
    }
}
