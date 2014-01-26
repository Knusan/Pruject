using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject EnemyPreFab;
	public GameObject Path;

	private ArrayList waveList = new ArrayList();

	void Start () {

		waveList.Add (1);
		waveList.Add (2);
		waveList.Add (3);
		waveList.Add (4);
	
		SpawnWave ();

	
	}

	void Update () {
	
	}
	private void SpawnWave(){

		for (int i = 0; i < 4; i++) {
			GameObject enemy = (GameObject)(Instantiate(EnemyPreFab));
			Enemy clone = enemy.GetComponent<Enemy>();
			clone.MySpeed = 2;
			clone.MyPath = Path;

				}
	}

	}
