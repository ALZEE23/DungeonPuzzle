// Editor/TilingManagerEditor.cs
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilingManager))]
public class TilingManagerEditor : Editor
{
    private TilingManager manager;
    private bool isPainting = false;

    void OnEnable()
    {
        manager = (TilingManager)target;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Toggle(isPainting, isPainting ? "Stop Painting" : "Start Painting", "Button"))
        {
            isPainting = !isPainting;
        }
    }

    void OnSceneGUI(SceneView sceneView)
    {
        if (!isPainting || manager.tilePrefab == null)
            return;

        Event e = Event.current;
        Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 point = hit.point;
            Vector3 aligned = new Vector3(
                Mathf.Floor(point.x / manager.tileSize) * manager.tileSize + manager.tileSize / 2,
                0,
                Mathf.Floor(point.z / manager.tileSize) * manager.tileSize + manager.tileSize / 2
            );

            Handles.color = new Color(0, 1, 0, 0.25f);
            Handles.DrawSolidDisc(aligned, Vector3.up, manager.tileSize / 2);

            if (e.type == EventType.MouseDown && e.button == 0 && !e.alt)
            {
                Undo.RegisterCompleteObjectUndo(manager.gameObject, "Place Tile");
                GameObject tile = (GameObject)PrefabUtility.InstantiatePrefab(manager.tilePrefab);
                tile.transform.position = aligned;
                tile.transform.SetParent(manager.transform);
                e.Use();
            }
        }

        HandleUtility.Repaint();
    }
}
