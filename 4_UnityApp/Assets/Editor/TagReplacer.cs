using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class TagReplacerEditor : EditorWindow
{
    private string oldTag = "OldTag"; // Tag to be replaced
    private string newTag = "NewTag"; // New tag to assign

    [MenuItem("Tools/Tag Replacer")]
    public static void ShowWindow()
    {
        GetWindow<TagReplacerEditor>("Tag Replacer");
    }

    void OnGUI()
    {
        GUILayout.Label("Replace Tags (including inactive objects)", EditorStyles.boldLabel);

        oldTag = EditorGUILayout.TextField("Old Tag", oldTag);
        newTag = EditorGUILayout.TextField("New Tag", newTag);

        if (GUILayout.Button("Replace Tags"))
        {
            ReplaceTags(oldTag, newTag);
        }
    }

    void ReplaceTags(string oldTag, string newTag)
    {
        if (string.IsNullOrEmpty(oldTag) || string.IsNullOrEmpty(newTag))
        {
            Debug.LogError("Both Old Tag and New Tag must be provided.");
            return;
        }

        // Find all objects with the old tag (active and inactive)
        List<GameObject> objectsWithOldTag = FindAllObjectsWithTag(oldTag);

        if (objectsWithOldTag.Count == 0)
        {
            Debug.LogWarning($"No objects found with the tag '{oldTag}'.");
            return;
        }

        // Replace the tag on each found object
        foreach (GameObject obj in objectsWithOldTag)
        {
            obj.tag = newTag;
            EditorUtility.SetDirty(obj); // Mark the object as dirty so changes are saved
        }

        Debug.Log($"Replaced tag '{oldTag}' with '{newTag}' on {objectsWithOldTag.Count} objects.");
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
