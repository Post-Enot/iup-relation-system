using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.RelationSystem.Serialization
{
    public static class RelationSchemeSerializer
    {
        public const string LastDataFormatVersion = "1.0.0";

        public static DTO.RelationScheme JsonToRelationSchemeDTO(string relationSchemeDTO)
        {
            return JsonUtility.FromJson<DTO.RelationScheme>(relationSchemeDTO);
        }

        public static RelationScheme DTO_ToRelationScheme(DTO.RelationScheme relationSchemeDTO)
        {
            var relationScheme = new RelationScheme();

            foreach (DTO.RelationType relationTypeDTO in relationSchemeDTO.relation_types)
            {
                relationScheme.AddRelationType(relationTypeDTO.relation_type_name);
            }

            foreach (DTO.RelationGroup relationGroupDTO in relationSchemeDTO.relation_groups)
            {
                relationScheme.AddRelationGroup(
                    relationGroupDTO.relation_group_name,
                    relationGroupDTO.default_relation_type_name,
                    relationGroupDTO.oneself_relation_type_name,
                    relationGroupDTO.priority);
            }

            foreach (DTO.RelationGroup relationGroupDTO in relationSchemeDTO.relation_groups)
            {
                foreach (DTO.SpecialRelation specialRelation in relationGroupDTO.special_relations)
                {
                    relationScheme.SetGroupSpecialRelationWith(
                        relationGroupDTO.relation_group_name,
                        specialRelation.relation_group_name,
                        specialRelation.relation_type_name);
                }
            }

            return relationScheme;
        }

        public static DTO.RelationScheme RelationScemeToDTO(
            IReadOnlyRelationScheme relationScheme)
        {
            var relationSchemeDTO = new DTO.RelationScheme
            {
                data_format_version = LastDataFormatVersion,
                relation_types = new DTO.RelationType[relationScheme.Types.Count],
                relation_groups = new DTO.RelationGroup[relationScheme.Groups.Count]
            };

            int i = 0;
            foreach (IReadOnlyRelationType relationType in relationScheme.Types)
            {
                relationSchemeDTO.relation_types[i] = new DTO.RelationType()
                {
                    relation_type_name = relationType.TypeName
                };
                i += 1;
            }

            i = 0;
            foreach (IReadOnlyRelationGroup relationGroup in relationScheme.Groups)
            {
                relationSchemeDTO.relation_groups[i] = new DTO.RelationGroup()
                {
                    relation_group_name = relationGroup.GroupName,
                    default_relation_type_name = relationGroup.DefaultRelation.TypeName,
                    oneself_relation_type_name = relationGroup.OneselfRelation.TypeName,
                    special_relations = new DTO.SpecialRelation[relationGroup.SpecialRelations.Count]
                };
                int j = 0;
                foreach (KeyValuePair<IReadOnlyRelationGroup, IReadOnlyRelationType> keyValuePair in
                    relationGroup.SpecialRelations)
                {
                    relationSchemeDTO.relation_groups[i].special_relations[j] = new DTO.SpecialRelation()
                    {
                        relation_group_name = keyValuePair.Key.GroupName,
                        relation_type_name = keyValuePair.Value.TypeName
                    };
                    j += 1;
                }
                i += 1;
            }

            return relationSchemeDTO;
        }
    }
}
