using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Player player;
	public Bullet bullet;
	public Floof floof;
	public Basket basket;
	public TextMesh infoText;
	public GameObject floofPrefab;
	//public GameObject floofRedPrefab;
	//public GameObject floofBluePrefab;
	public GameObject enemyPrefab;
	//public GameObject enemyRedPrefab;
	//public GameObject enemyBluePrefab;
	public float speed = 5f;
	public float maxFloof = 10f;
	public float movingSpeed = 10f;
	public float spawnPointer = 0.5f;
	public float spawnDistance = 5f;
	public float spawnIncrement = 3f;
	public float gameOverTimer = 3f;
	public float spawnInterval = 5f;

	private float spawnTimer;

	// Use this for initialization
	void Start () {

		InstantiateFloof ();
		InstantiateFloof ();
		InstantiateFloof ();
		InstantiateFloof ();
		InstantiateFloof ();
		InstantiateFloof ();

		InstantiateEnemy ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player.dead == false) {
			infoText.text = "Sacrifice floof to kill enemies!\nAt least one pink and one blue needs to survive!\nScore: " + Mathf.Floor (player.score);
		} else {
			infoText.text = "All floofs died horrible death! :(\nScore: " + Mathf.Floor (player.score);
			gameOverTimer -= Time.deltaTime;
			if (gameOverTimer <= 0f){
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}

		int floofReds = GameObject.FindGameObjectsWithTag ("FloofRed").Length;
		int floofBlues = GameObject.FindGameObjectsWithTag ("FloofBlue").Length;
		int enemyReds = GameObject.FindGameObjectsWithTag ("EnemyRed").Length;
		int enemyBlues = GameObject.FindGameObjectsWithTag ("EnemyBlue").Length;

		if (floofReds + floofBlues > 5) {
			if (player.transform.position.z > spawnPointer) {
				InstantiateEnemy ();
			}
		} 
		else if (floofReds < 1 || floofBlues < 1 ){
			player.dead = true;
		}
		else {
			spawnTimer -= Time.deltaTime;
			if (spawnTimer <= 0f) {
				spawnTimer = spawnInterval;
				InstantiateFloof ();
			}
		}
	}

	public void InstantiateEnemy(){
		GameObject enemyObject = Instantiate (enemyPrefab);
		enemyObject.transform.position = new Vector3 (
			Random.Range (0f, 2f), 2f, player.transform.position.z + spawnDistance
		);
		spawnPointer = player.transform.position.z + spawnIncrement;
	}

	public void InstantiateFloof(){	
		GameObject floofObject = Instantiate (floofPrefab);
		floofObject.transform.position = new Vector3 (
			Random.Range (0f, 2f), 2.8f, Random.Range (player.transform.position.z + 0.2f, player.transform.position.z + 1.4f));
		floofObject.transform.SetParent (basket.transform);
		//CheckPosition (floofObject);		
	}

	//void CheckPosition(GameObject obj){
	//	if (obj.transform.position.z < basket.transform.position.z) {
	//		Destroy (obj.gameObject);
	//}
	//}
}
