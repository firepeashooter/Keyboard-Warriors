using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Import the SceneManager class

public class SceneChange : MonoBehaviour
{

    public string scene;
    // Start is called before the first frame update
    void SceneChanger()
    {
        SceneManager.LoadScene(scene); // Loads the scene with the requested name
    }
}
