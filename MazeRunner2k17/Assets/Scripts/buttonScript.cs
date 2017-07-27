using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void restart()
    {
        SceneManager.LoadScene("movementtester");
    }
}
