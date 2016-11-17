using UnityEngine;
using System.Collections;

	
public class ClickToMove : MonoBehaviour {

	private NavMeshAgent navMeshAgent;

	private Ray ray;

	private bool walking;

	public GameObject marker;

	public GameObject player;


	//public GameObject groundPlane;


	// Use this for initialization
	void Awake () 
	{
		navMeshAgent = player.GetComponent<NavMeshAgent> ();
		transform.position = player.transform.position + new Vector3(0,2,0.5f);
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position = player.transform.position + new Vector3(0,2,0.5f);
		ray.origin = transform.position;
		ray.direction = transform.forward;

		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 50))
		{
			marker.transform.position = new Vector3 (hit.point.x, 0, hit.point.z);
		}

		if (Input.GetButtonDown ("Fire1")) 
		{
			if (Physics.Raycast(ray, out hit,50))
			{
				walking = true;
				navMeshAgent.destination = hit.point;
				navMeshAgent.Resume();
				marker.transform.position = hit.point;
			}
		}
			

		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
			if (!navMeshAgent.hasPath || Mathf.Abs (navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
				walking = false;
		} else {
			walking = true;
		}
			
	}

}

