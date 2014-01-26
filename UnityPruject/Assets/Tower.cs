using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Tower : MonoBehaviour {
	public enum TargetPolicy {FIFO}
	public TargetPolicy Policy;
	public float range;
	public float fireIntervall;
	public GameObject Projectile;

	private bool reloading;
	private Hashtable enemiesInRangeTable;
	private List<GameObject> enemiesInRangeList;
	private GameObject target;
	private Timer reloadTimer;
	// Use this for initialization
	void Start () {
		enemiesInRangeTable = new Hashtable();
		enemiesInRangeList = new List<GameObject> ();
		CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D> ();
		collider.radius = range;
		collider.isTrigger = true;
	
	}


	// Update is called once per frame
	void Update () {

		if (reloadTimer != null)
			reloadTimer.Update (Time.deltaTime);

		if (target) {
			LookAtTarget (target);
			if(!reloading)
				Fire();

		}
	}

	void Fire(){
		var projectile = (GameObject) Instantiate (Projectile);
		projectile.transform.position = this.transform.position;
		var projectileScript = projectile.GetComponent<Projectile> ();
		projectileScript.direction = transform.TransformDirection(Vector2.up);
		reloadTimer = new Timer (1);
		reloadTimer.OnTimerFire += OnReloadTimer;
		reloading = true;
		reloadTimer.Start();


	}

	void OnReloadTimer(object sender, TimerEventArgs args){
		reloading = false;
	}
	void LookAtTarget(GameObject target){
	
		float dx = target.transform.position.x -transform.position.x;
		float dy = target.transform.position.y - transform.position.y;
		if(dx < 0)
			this.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Rad2Deg*Mathf.Atan2 (dx, dy));
		else
			this.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Rad2Deg*Mathf.Atan2 (dx, dy));

	}

	void SelectEnemy(){
		if (enemiesInRangeList.Count == 0) { 
				target = null;
				return;
			}

		switch (Policy) {
		case TargetPolicy.FIFO: SelectEnemyFIFO();
			break;
		}

	}

	void SelectEnemyFIFO(){
		target = enemiesInRangeList [0];
	}
	void OnTriggerEnter2D(Collider2D other){
		Enemy enemy = other.gameObject.GetComponent<Enemy> ();
		enemiesInRangeTable [other.gameObject] = enemy;
		enemiesInRangeList.Add (other.gameObject);
		SelectEnemy ();
	}

	void OnTriggerExit2D(Collider2D other){
		enemiesInRangeTable.Remove (other.gameObject);
		enemiesInRangeList.Remove (other.gameObject);
		SelectEnemy ();

	}


}
