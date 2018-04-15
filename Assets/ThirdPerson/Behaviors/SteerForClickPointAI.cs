using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnitySteer;
using UnitySteer.Behaviors;

[RequireComponent (typeof(SteerForPathSimplified))]
public class SteerForClickPointAI : MonoBehaviour {
	private SteerForPathSimplified	 _steering;
	private NavMeshAgent 			 _agent;
	private RaycastHit  			 _hit = new RaycastHit();
	// Use this for initialization
	void Start () {
		_steering = GetComponent<SteerForPathSimplified> ();
		_agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out _hit)) {
				//_agent.updatePosition = false;
				//_agent.updateRotation = false;
				//_agent.destination = _hit.point;
				NavMeshPath path=new NavMeshPath();
				_agent.CalculatePath ( _hit.point, path);
				_steering.Path=new Vector3Pathway(path.corners,1);
				// Debug.Log (_steering.Path);
				// _steering.TargetPoint = hit.point;
				_steering.enabled = true;
			}
		}
	}
}
