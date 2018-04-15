using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnitySteer.Behaviors;


[RequireComponent (typeof(SteerForPoint))]

public class SteerForClickPoint : MonoBehaviour
{
	private SteerForPoint _steering;

	void Start ()
	{
		_steering = GetComponent<SteerForPoint> ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit    hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				_steering.TargetPoint = hit.point;
				_steering.enabled = true;
			}
		}
	}
}
	
