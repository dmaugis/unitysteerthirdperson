using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

[RequireComponent(typeof(BipedThirdPerson)), RequireComponent(typeof(SteerForPoint))]
public class GoForPointControllerThirdPerson : MonoBehaviour 
{
	SteerForPoint _steering;

	[SerializeField]
	Vector3 _pointRange = Vector3.one * 20;

	void Start() 
	{
		_steering = GetComponent<SteerForPoint>();
		_steering.OnArrival += (_) => FindNewTarget();
		FindNewTarget();
	}


	void FindNewTarget()
	{
		_steering.TargetPoint = Vector3.Scale(Random.onUnitSphere, _pointRange);
		_steering.enabled = true;
	}
}
