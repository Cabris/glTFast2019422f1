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
    [SerializeField]
    Transform _root;
    // Start is called before the first frame update
    void Start()
    {
        LoadAsync();
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
            gltf.InstantiateMainScene(_root);
        }
        else
        {
            Debug.LogError("Loading glTF failed!");
        }
    }
}
