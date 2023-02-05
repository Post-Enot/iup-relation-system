using System;
using System.IO;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace IUP.Toolkits.RelationSystem
{
    [ScriptedImporter(_version, _fileExtension)]
    internal class RelationshipSchemeImporter : ScriptedImporter
    {
        internal const int _version = 1;
        internal const string _fileExtension = "relationshipscheme";
        private const string _defaultAssetLayout = "{\"data_format_version\":\"1.0.0\",\"relation_types\":[{\"relation_type_name\":\"enmity\"},{\"relation_type_name\":\"friendship\"},{\"relation_type_name\":\"mistrust\"}],\"relation_groups\":[{\"relation_group_name\":\"people\",\"oneself_relation_type_name\":\"mistrust\",\"default_relation_type_name\":\"mistrust\",\"priority\":0,\"special_relations\":[{\"relation_group_name\":\"monsters\",\"relation_type_name\":\"friendship\"},{\"relation_group_name\":\"farm_animals\",\"relation_type_name\":\"friendship\"}]},{\"relation_group_name\":\"monsters\",\"oneself_relation_type_name\":\"mistrust\",\"default_relation_type_name\":\"enmity\",\"priority\":0,\"special_relations\":[{\"relation_group_name\":\"people\",\"relation_type_name\":\"enmity\"},{\"relation_group_name\":\"farm_animals\",\"relation_type_name\":\"enmity\"}]},{\"relation_group_name\":\"farm_animals\",\"oneself_relation_type_name\":\"friendship\",\"default_relation_type_name\":\"mistrust\",\"priority\":0,\"special_relations\":[{\"relation_group_name\":\"monsters\",\"relation_type_name\":\"enmity\"},{\"relation_group_name\":\"people\",\"relation_type_name\":\"friendship\"}]}]}";

        public override void OnImportAsset(AssetImportContext ctx)
        {
            if (ctx == null)
            {
                throw new ArgumentNullException(nameof(ctx));
            }
            string relationshipSchemeJson;
            try
            {
                relationshipSchemeJson = File.ReadAllText(ctx.assetPath);
            }
            catch (Exception exception)
            {
                ctx.LogImportError($"Could not read file '{ctx.assetPath}' ({exception})");
                return;
            }

            RelationSchemeAsset asset = RelationSchemeAsset.CreateAsset();
            ctx.AddObjectToAsset("<root>", asset);
            ctx.SetMainObject(asset);
        }

        [MenuItem("Assets/Create/Relation System/Relation Scheme")]
        public static void CreateAsset()
        {
            ProjectWindowUtil.CreateAssetWithContent(
                $"Relation Scheme.{_fileExtension}",
                _defaultAssetLayout);
        }
    }
}
