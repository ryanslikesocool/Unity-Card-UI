using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPopup : MonoBehaviour {

	public float rotationSpeed = 1f;
	public float centeringSpeed = 4f;

	private Vector3 startPosition;
	private Rigidbody rbody;
	private bool isFalling;
	private Vector3 cardFallRotation;
	private bool fallToZero;

	void Start() {
		rbody = GetComponent<Rigidbody>();
		rbody.useGravity = false;
		startPosition = transform.position;
	}

	void Update() {
		if (isFalling) {
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(cardFallRotation), Time.deltaTime * rotationSpeed);
		}

		///Everything in this fallToZero conditional is totally unnecessary.  I have it so the popup falls back nicely.		
		if (fallToZero) {
			transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * centeringSpeed);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * centeringSpeed);
			if (Vector3.Distance(transform.position, startPosition) < 0.0001f) {
				transform.position = startPosition;
				fallToZero = false;
			}
		}

		///This is also probably unnecessary.
		if (transform.position.y < -4) {
			isFalling = false;
			fallToZero = true;
			rbody.useGravity = false;
			rbody.velocity = Vector3.zero;
			transform.position = new Vector3(0, 8, startPosition.z);			
		}
	}

	///A negative fallRotation will result in the card turning clockwise, while a positive fallRotation makes the card turn counterclockwise.
	public void CardFall(float fallRotation) {
		fallToZero = false;
		rbody.useGravity = true;
		isFalling = true;
		cardFallRotation = new Vector3(0, 0, fallRotation);
	}
}