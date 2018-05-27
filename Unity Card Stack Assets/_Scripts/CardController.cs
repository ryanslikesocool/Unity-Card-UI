using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

	public float cardMoveSpeed = 8f;
	public float buttonCooldownTime = 0.125f;
	public int cardArrayOffset;
	public GameObject[] cards;
	public Vector3[] cardPositions;

	private bool canMove = true;
	private int xPowerDifference;

	void Start () {
		xPowerDifference = 9 - cards.Length;

		cardPositions = new Vector3[cards.Length * 2 - 1];
		
		for (int i = cards.Length; i > -1; i--) {
			if (i < cards.Length - 1) {
				cardPositions[i] = new Vector3 (- Mathf.Pow(2, i + xPowerDifference) + cardPositions[i + 1].x, 0, 32 * Mathf.Abs(i + 1 - cards.Length));
			} else {
				cardPositions[i] = Vector3.zero;
			}
		}

		for (int i = cards.Length; i < cardPositions.Length; i++) {
			cardPositions[i] = new Vector3 (1152 + 4 * (i - cards.Length), 0, -2 + -2 * (i - cards.Length));
		}
	}
	
	void Update () {
		if (canMove) {
			if (Input.GetAxisRaw("Horizontal") < 0 && cardArrayOffset > 0) {
				cardArrayOffset--;
				StartCoroutine(ButtonCooldown());
			} else if (Input.GetAxisRaw("Horizontal") > 0 && cardArrayOffset < cards.Length - 1) {
				cardArrayOffset++;
				StartCoroutine(ButtonCooldown());
			}
		}

		for (int i = 0; i < cards.Length; i++) {
			cards[i].transform.localPosition = Vector3.Lerp(cards[i].transform.localPosition, cardPositions[i + cardArrayOffset], Time.deltaTime * cardMoveSpeed);
		}
	}

	IEnumerator ButtonCooldown() {
		canMove = false;
		yield return new WaitForSeconds(buttonCooldownTime);
		canMove = true;
	}
}
