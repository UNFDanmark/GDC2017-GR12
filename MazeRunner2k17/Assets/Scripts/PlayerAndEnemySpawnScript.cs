using UnityEngine;
using System.Collections;

public class PlayerAndEnemySpawnScript : MonoBehaviour {

    public PlayerMovementScript player;
    public monsternav enemy;
    public int playerSpawn = 0;
    public int enemySpawn = 0;
    public float playHeight = 1.1f;

	// Use this for initialization
	void Start() {
        playerSpawn = Random.Range(0, 4);

        if (playerSpawn < 2)
        {
            enemySpawn = playerSpawn + 2;
        }
        else
        {
            enemySpawn = playerSpawn - 2;
        }

        enemy.gameObject.SetActive(false);

        player.transform.position = GameObject.Find("Spawn_" + playerSpawn).transform.position;
        enemy.transform.position = GameObject.Find("Spawn_" + enemySpawn).transform.position;

        player.transform.position = new Vector3(player.transform.position.x, playHeight, player.transform.position.z);

        enemy.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
