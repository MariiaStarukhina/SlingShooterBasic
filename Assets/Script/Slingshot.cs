using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public GameObject launchPoint;
	void Awake() {
		Transform launchPointTransform = transform.Find ("launchPoint");
		launchPoint = launchPointTransform.gameObject;
		launchPoint.SetActive(false);
	}
	void OnMouseEnter() {
		launchPoint.SetActive(true);
		//print ("Yay, the mouse has entered");
	}

	void OnMouseExit() {
		launchPoint.SetActive(false);
		//print ("Oh no, the mouse has exited");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
