using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityStandardAssets.Characters.ThirdPerson;
using UnitySteer.Behaviors;


[RequireComponent (typeof(SteerForPoint))]

public class MoveThirdPersonToClickPoint : MonoBehaviour
{
	SteerForPoint _steering;
	private Transform playerTransform;
	RaycastHit hit;

	void Start ()
	{
		_steering = GetComponent<SteerForPoint> ();
		playerTransform=GetComponent<Transform> ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("I hit something!");
				_steering.OnArrival += (_) => StopSteering ();
				_steering.TargetPoint = hit.point;
				_steering.enabled = true;
			} else {
				StopSteering ();
			}

		}
		if (_steering.enabled) {
			float journeyLength = Vector3.Distance (playerTransform.position, hit.point);
			if (journeyLength < 0.5f)
				StopSteering ();
		}
	}

	void StopSteering ()
	{
		_steering.TargetPoint = Vector3.zero;
		_steering.enabled = false;
	}
		
}


/***
 public class MoveThirdPersonToClickPoint : MonoBehaviour {
	private ThirdPersonCharacter thirdPersonScript;
	private Transform playerTransform;
	private bool completed;

	 Use this for initialization
	void Start () {
		thirdPersonScript = gameObject.GetComponent<ThirdPersonCharacter>();
		playerTransform = gameObject.GetComponent<Transform> ();
	}
	
	 Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit));
			{
				Debug.Log ("I hit something!");
				//StartCoroutine(movePlayer(hit.point));
				StartCoroutine(movePlayer(hit.point));
			}
		}
	}

	IEnumerator movePlayer (Vector3 finalDestination)
	{
		completed = false;

		var i     = 0.0f;

		float journeyLength = Vector3.Distance(playerTransform.position, finalDestination);

		while (journeyLength > 1.0f)
		{
			journeyLength = Vector3.Distance(playerTransform.position, finalDestination);
			thirdPersonScript.Move (Vector3.Lerp(playerTransform.position, finalDestination, 10F), false, false);
			Debug.Log (journeyLength);
			yield return null;
		}

		Debug.Log ("Done!");

		completed = true;

	}
}
*/