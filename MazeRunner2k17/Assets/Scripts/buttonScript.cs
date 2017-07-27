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
    public void game()
    {
        SceneManager.LoadScene("movementtester");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void death()
    {
        SceneManager.LoadScene("deathscreen");
    }
    public void yes()
    {
        SceneManager.LoadScene("victoryscreen");
    }
    public void info()
    {
        SceneManager.LoadScene("InfoScreen");
    }

}
