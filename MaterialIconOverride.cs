using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class MaterialIconOverride
{
    static MaterialIconOverride()
    {
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
    }

    private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
    {
        string path = AssetDatabase.GUIDToAssetPath(guid);
        var mat = AssetDatabase.LoadAssetAtPath<Material>(path);

        if (mat == null) return;

        // Get correct icon rect
        bool isListView = selectionRect.height <= 20;

        if (!isListView)
            return;

        var iconRect = new Rect(selectionRect.x + 3, selectionRect.y, 16, 16);

        var preview = AssetPreview.GetAssetPreview(mat);
        if (preview)
            GUI.DrawTexture(iconRect, preview);
    }
}
