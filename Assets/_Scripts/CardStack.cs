using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour {

	public float cardMoveSpeed = 8f;
	public float buttonCooldownTime = 0.125f;
	public int cardZMultiplier = 32;
	public int usedCardXPos = 1280;
	public GameObject[] cards;
	
	private int cardArrayOffset;
	private Vector3[] cardPositions;
	private bool canMove = true;
	private int xPowerDifference;

	void Start () {
///I've found that 9 is a good number for this.  I wouldn't really recommend changing it, but go ahead if you want to.		
		xPowerDifference = 9 - cards.Length;

		cardPositions = new Vector3[cards.Length * 2 - 1];

///This for loop is for cards still in the stack.		
		for (int i = cards.Length; i > -1; i--) {
			if (i < cards.Length - 1) {
				cardPositions[i] = new Vector3 (- Mathf.Pow(2, i + xPowerDifference) + cardPositions[i + 1].x, 0, cardZMultiplier * Mathf.Abs(i + 1 - cards.Length));
			} else {
				cardPositions[i] = Vector3.zero;
			}
		}

///This for loop is for cards outside of the stack.
		for (int i = cards.Length; i < cardPositions.Length; i++) {
			cardPositions[i] = new Vector3 (usedCardXPos + 4 * (i - cards.Length), 0, -2 + -2 * (i - cards.Length));
		}
	}
	
	void Update () {
		if (canMove) {
///Controls for the cards.  Kinda obvious imo.			
			if (Input.GetAxisRaw("Horizontal") < 0 && cardArrayOffset > 0) {
				cardArrayOffset--;
				StartCoroutine(ButtonCooldown());
			} else if (Input.GetAxisRaw("Horizontal") > 0 && cardArrayOffset < cards.Length - 1) {
				cardArrayOffset++;
				StartCoroutine(ButtonCooldown());
			}
		}

///Moves the cards.  I know that none of my lerps are the "right way," but it looks much nicer.
		for (int i = 0; i < cards.Length; i++) {
			cards[i].transform.localPosition = Vector3.Lerp(cards[i].transform.localPosition, cardPositions[i + cardArrayOffset], Time.deltaTime * cardMoveSpeed);
		}
	}

///Stops the cards from scrolling really fast.
	IEnumerator ButtonCooldown() {
		canMove = false;
		yield return new WaitForSeconds(buttonCooldownTime);
		canMove = true;
	}
}