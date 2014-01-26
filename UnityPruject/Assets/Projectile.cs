using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed;
	public Vector2 direction;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPos = this.transform.position;
		newPos.x += direction.x * speed * Time.deltaTime;
		newPos.y += direction.y * speed * Time.deltaTime;
		this.transform.position = newPos;
	}
}
