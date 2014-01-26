using UnityEngine;
using System.Collections;

public class UnitEx : MonoBehaviour {
	public GameObject MyPath;
	public float MySpeed;


	private WaypointSystem waypointSystem;
	private int currentPath;
	private Vector2 goalPoint;


	// Use this for initialization
	void Start () {
		WaypointSystem Script = MyPath.GetComponent<WaypointSystem>();
		waypointSystem = Script;
		BeginPath (0);

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPos = transform.position;
		Vector2 direction = waypointSystem.GetDirection (currentPath, currentPos);

		Vector2 nextPos = currentPos + direction * MySpeed*Time.deltaTime;
		this.gameObject.transform.position = nextPos;

		if(CheckNextPath(direction)){
			if(waypointSystem.GetWaypointsLength() == currentPath+2)
				Debug.Log("DONE!");
			else
				BeginPath(currentPath+1);
		}

	
	}
	private bool CheckNextPath(Vector2 direction){


		Vector2 pos = transform.position;
		Vector2 newDirection = waypointSystem.GetDirection(currentPath, pos);


		return (Mathf.Sign(direction.x) != Mathf.Sign(newDirection.x)) ||
		       (Mathf.Sign(direction.y) != Mathf.Sign(newDirection.y)) ||
			   (pos == goalPoint);


	}
	private void BeginPath(int path){
		currentPath = path;
		goalPoint = waypointSystem.GetEndPointPath (path);
		transform.position = waypointSystem.GetStartPointPath (path);


	}
}
