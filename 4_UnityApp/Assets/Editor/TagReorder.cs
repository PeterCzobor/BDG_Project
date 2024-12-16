using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class TagReorderEditor : EditorWindow
{
    private string[] oldTags = new string[5]; // Adjust array size based on how many tags you want to reorder
    private string[] newTags = new string[5]; // New tags that will replace the old tags

    [MenuItem("Tools/Tag Reorder")]
    public static void ShowWindow()
    {
        GetWindow<TagReorderEditor>("Tag Reorder");
    }

    void OnGUI()
    {
        GUILayout.Label("Reorder Tags (including inactive objects)", EditorStyles.boldLabel);

        // Input fields for old and new tag names
        for (int i = 0; i < oldTags.Length; i++)
        {
            oldTags[i] = EditorGUILayout.TextField("Old Tag " + (i + 1), oldTags[i]);
            newTags[i] = EditorGUILayout.TextField("New Tag " + (i + 1), newTags[i]);
        }

        if (GUILayout.Button("Reassign Tags"))
        {
            ReassignTags();
        }
    }

    void ReassignTags()
    {
        for (int i = 0; i < oldTags.Length; i++)
        {
            if (!string.IsNullOrEmpty(oldTags[i]) && !string.IsNullOrEmpty(newTags[i]))
            {
                // Find all objects (active and inactive) with the old tag
                List<GameObject> objectsWithOldTag = FindAllObjectsWithTag(oldTags[i]);

                foreach (GameObject obj in objectsWithOldTag)
                {
                    obj.tag = newTags[i];
                    EditorUtility.SetDirty(obj); // Mark the object as dirty so changes are saved
                }

                Debug.Log($"Reassigned {objectsWithOldTag.Count} objects from tag '{oldTags[i]}' to '{newTags[i]}'.");
            }
        }
    }

    // Function to find all active and inactive GameObjects with a specific tag
    List<GameObject> FindAllObjectsWithTag(string tag)
    {
        List<GameObject> taggedObjects = new List<GameObject>();

        // Get all root GameObjects in the scene
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject rootObject in rootObjects)
        {
            // Recursively search through the root object and its children
            SearchForTagRecursively(rootObject.transform, tag, taggedObjects);
        }

        return taggedObjects;
    }

    // Recursive function to search for objects with the tag, including inactive ones
    void SearchForTagRecursively(Transform parent, string tag, List<GameObject> taggedObjects)
    {
        if (parent.gameObject.CompareTag(tag))
        {
            taggedObjects.Add(parent.gameObject);
        }

        foreach (Transform child in parent)
        {
            SearchForTagRecursively(child, tag, taggedObjects);
        }
    }
}
