using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundGuyScript : MonoBehaviour {

    public Scene currentScene;
    public string activeScene;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        activeScene = currentScene.name;

        if (activeScene == "mainmenu")
        {
            DontDestroyOnLoad(gameObject);
        }
    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        currentScene = SceneManager.GetActiveScene();
        activeScene = currentScene.name;
        if (activeScene == "movementester")
        {
            Destroy(gameObject);
        }
    }
}
