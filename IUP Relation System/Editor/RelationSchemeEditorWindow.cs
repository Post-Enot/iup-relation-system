using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

namespace IUP.Toolkits.RelationSystemLegacy.Editor
{
    internal sealed class RelationSchemeEditorWindow : EditorWindow
    {
        [SerializeField] private RelationSchemeAsset _asset;

        private void Awake()
        {
            saveChangesMessage = "You have unsaved changes. Would you like to keep them?";
            titleContent.text = "Relation Scheme Editor";
        }

        private void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                UI_FilePathes.UXML_CellarMapAssetInspector);
            visualTree.CloneTree(root);
            StyleSheet uss = AssetDatabase.LoadAssetAtPath<StyleSheet>(UI_FilePathes.USS_StyleSheetPath);
            root.styleSheets.Add(uss);
        }

        [MenuItem("IUP/Relation Scheme Editor")]
        public static void OpenWindow()
        {
            _ = GetWindow<RelationSchemeEditorWindow>();
        }

        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceId, int line)
        {
            var path = AssetDatabase.GetAssetPath(instanceId);
            if (!path.EndsWith(RelationshipSchemeImporter._fileExtension,
                StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            UnityEngine.Object assetObject = EditorUtility.InstanceIDToObject(instanceId);
            var asset = assetObject as RelationSchemeAsset;
            if (asset == null)
            {
                return false;
            }
            _ = OpenEditor(asset);
            return true;
        }

        public static RelationSchemeEditorWindow OpenEditor(RelationSchemeAsset asset)
        {
            RelationSchemeEditorWindow window = FindEditorForAsset(asset);
            if (window == null)
            {
                window = CreateInstance<RelationSchemeEditorWindow>();
                window.SetAsset(asset);
            }
            window.Show();
            window.Focus();
            return window;
        }

        public static RelationSchemeEditorWindow FindEditorForAsset(RelationSchemeAsset asset)
        {
            var windows = Resources.FindObjectsOfTypeAll<RelationSchemeEditorWindow>();
            return windows.FirstOrDefault(window => window._asset == asset);
        }

        private void SetAsset(RelationSchemeAsset asset)
        {
            _asset = asset;
        }
    }
}

