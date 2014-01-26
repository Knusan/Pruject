using UnityEngine;
using System.Collections;
using System;
public class TimerEventArgs: EventArgs{
	public float TimeOffset;
}
public delegate void OnTimerFireHandler(object sender, TimerEventArgs args);
public class Timer {

	public event OnTimerFireHandler OnTimerFire;
	private float currentTime;
	private float goalTime;
	private float delay;
	private int intervals;

	public Timer(float delay){
		this.delay = delay;

	}
	public Timer(float delay, int intervals){
		this.intervals = intervals;
	}

	public void Start(){
		currentTime = 0;
		goalTime = delay;
		if (intervals == 0)
			intervals = 1;
	}

	public void Update(float dt){
		if (intervals == 0) return;

		currentTime += dt;
		if (currentTime >= goalTime) {
			if(OnTimerFire != null){
				TimerEventArgs args = new TimerEventArgs(){TimeOffset = currentTime - goalTime};
				currentTime = 0;
				intervals--;
			

				OnTimerFire(this, args);
			}

		}

	}
}
