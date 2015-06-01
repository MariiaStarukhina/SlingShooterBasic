using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	// Fields seen in the Inspector panel
	public GameObject prefabProjectile;

	// Internal variable
	private GameObject launchPoint;
	private Vector3 launchPos;
	private GameObject projectile;

	void Start () {
	
	}

	bool aimingMode;

	void Awake() {
		Transform launchPointTransform = transform.Find ("launchPoint");
		launchPoint = launchPointTransform.gameObject;
		launchPoint.SetActive(false);

		launchPos = launchPointTransform.position;
	}
	void OnMouseEnter() {
		launchPoint.SetActive(true);
		//print ("Yay, the mouse has entered");
	}

	void OnMouseExit() {
		launchPoint.SetActive(false);
		//print ("Oh no, the mouse has exited");
	}

	void OnMouseDown() {
		aimingMode = true;

		// Instantiate a new projectile
		projectile = Instantiate (prefabProjectile) as GameObject;
	
		// Start at launch point
		projectile.transform.position = launchPos;
		// Set isKinematic to true for now
		projectile.GetComponent<Rigidbody> ().isKinematic = true;
	}
	// Update is called once per frame
	void Update () {
		// if we're not in aiming mode, do nothing
		if (!aimingMode) {
			return;
		}
	
	// get the current position in 2D
	Vector3 mousePos2D = Input.mousePosition;
	// convert it to 3D coordinates
	mousePos2D.z = -Camera.main.transform.position.z;
	Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
	// find the diffrence between the launch position and mouse position
		Vector3 mouseDelta = mousePos3D - launchPos;
	// move the projectile to this new position
		projectile.transform.position = mousePos3D;
	}
}
