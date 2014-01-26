using UnityEngine;
using System.Collections;

public class WaypointSystem : MonoBehaviour {
	public Vector2[] Waypoints;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
	
	}
	public Vector2 GetNextPath(int prePoint){
		Vector2 preVector = Waypoints[prePoint];
		Vector2 nextVector = Waypoints [prePoint + 1];
		return (nextVector - preVector).normalized;
	}
	public Vector2 GetDirection(int path, Vector2 pos){
		Vector2 endPoint = GetEndPointPath (path);
		return (endPoint - pos).normalized;
	}
	public Vector2 GetStartPointPath(int path){
		return Waypoints [path];	
	}
	public Vector2 GetEndPointPath(int path){
		return Waypoints[path+1];
	}
	public int GetWaypointsLength(){
		return Waypoints.Length;
	}
}
