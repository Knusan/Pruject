using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	public float range;
	// Use this for initialization
	void Start () {
		CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D> ();
		collider.radius = range;
		collider.isTrigger = true;

	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void LookAtTarget(GameObject target){
		float dx = target.transform.position.x -transform.position.x;
		float dy = target.transform.position.y - transform.position.y;
		if(dx < 0)
			this.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Rad2Deg*Mathf.Atan2 (dx, dy));
		else
			this.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Rad2Deg*Mathf.Atan2 (dx, dy));

	}

	void OnTriggerEnter2D(Collider2D other){

		LookAtTarget (other.gameObject);
	}


}
