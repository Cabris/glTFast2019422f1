using GLTFast;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class GLTFLoader : MonoBehaviour
{
    [SerializeField]
    string _url;

    // Start is called before the first frame update
    void Start()
    {
        LoadAsync();
        var oldSelection = Selection.objects;
        Selection.objects = new Object[0];
        void foo()
        {
            Selection.objects = oldSelection;
            EditorApplication.delayCall -= foo;
        }
        EditorApplication.delayCall += foo;

    }

    private async void LoadAsync()
    {
        var gltf = new GltfImport();

        // Create a settings object and configure it accordingly
        var settings = new ImportSettings
        {
            //generateMipMaps = true,
            //anisotropicFilterLevel = 3,
            nodeNameMethod = ImportSettings.NameImportMethod.OriginalUnique
        };

        // Load the glTF and pass along the settings
        var success = await gltf.Load(_url, settings);

        if (success)
        {
            gltf.InstantiateMainScene(new GameObject("glTF").transform);
        }
        else
        {
            Debug.LogError("Loading glTF failed!");
        }
    }
}
