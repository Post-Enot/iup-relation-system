using System.IO;
using IUP.Toolkits.RelationSystemLegacy.Serialization;
using UnityEditor;
using UnityEngine;
using DTO = IUP.Toolkits.RelationSystemLegacy.Serialization.DTO;

namespace IUP.Toolkits.RelationSystemLegacy
{
    public sealed class RelationSchemeAsset : ScriptableObject
    {
        public IRelationScheme RelationScheme { get; private set; }

        [SerializeField] private DTO.RelationScheme _relationSchemeDTO;

        private void OnEnable()
        {
            LoadAsset();
        }

        /// <summary>
        /// Загружает ассет из связанного с ним файла клеточной карты, инициализируя свойство CellarMap.
        /// </summary>
        private void LoadAsset()
        {
#if UNITY_EDITOR
            string assetPath = AssetDatabase.GetAssetPath(this);
            /* Данное условие срабатывает в первый раз, когда ассет только создан;
             * в этом случае AssetDatabase.GetAssetPath(this) вернёт null.*/
            if (assetPath == null)
            {
                return;
            }
            string relationSchemeJson = File.ReadAllText(assetPath);
            _relationSchemeDTO = RelationSchemeSerializer.JsonToRelationSchemeDTO(relationSchemeJson);
#endif
            RelationScheme = RelationSchemeSerializer.DTO_ToRelationScheme(_relationSchemeDTO);
        }

        public static RelationSchemeAsset CreateAsset()
        {
            return CreateInstance<RelationSchemeAsset>();
        }
    }
}
