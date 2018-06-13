using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardExpanding : MonoBehaviour {

	public float lerpSpeed = 8f;

	public RectTransform buttonRect;
	private Vector2 closeButtonMin;
	private Vector2 closeButtonMax;

	public Vector2 cardSize;
	public Vector2 pageSize;

	private Vector2 cardCenter;
	private Vector2 pageCenter = Vector2.zero;

	private Vector2 cardMin;
	private Vector2 cardMax;
	private Vector2 pageMin;
	private Vector2 pageMax;

	public Image titleBarImage;
	public Color32 hiddenTitleBarColor;
	public Color32 revealedTitleBarColor;

	private RectTransform rectTrans;
	///I wouldn't recommend changing animationActive's value here unless you want the card to start as a page.
	private int animationActive = -1;

	void Start() {
		rectTrans = GetComponent<RectTransform>();

		///Setting up the button's starting color and page position.
		buttonRect.GetComponent<Image>().color = new Color32(228, 0, 0, 0);
		
		closeButtonMin = new Vector2(pageMin.x + pageSize.x - 64, pageMin.y + pageSize.y - 64);
		closeButtonMax = new Vector2(pageMax.x - 16, pageMax.y - 16);

		///Setting up the card and page offsets.
		cardMin = new Vector2(cardCenter.x - cardSize.x * 0.5f, cardCenter.y - cardSize.y * 0.5f);
		cardMax = new Vector2(cardCenter.x + cardSize.x * 0.5f, cardCenter.y + cardSize.y * 0.5f);

		pageMin = new Vector2(pageCenter.x - pageSize.x * 0.5f, pageCenter.y - pageSize.y * 0.5f);
		pageMax = new Vector2(pageCenter.x + pageSize.x * 0.5f, pageCenter.y + pageSize.y * 0.5f);

		titleBarImage.color = hiddenTitleBarColor;
	}
	
	void Update() {
		///When animationActive == 1, the card is expanding into a page.
		if (animationActive == 1) {
			rectTrans.offsetMin = Vector2.Lerp(rectTrans.offsetMin, pageMin, Time.deltaTime * lerpSpeed);
			rectTrans.offsetMax = Vector2.Lerp(rectTrans.offsetMax, pageMax, Time.deltaTime * lerpSpeed);

			titleBarImage.color = Color32.Lerp(titleBarImage.color, revealedTitleBarColor, Time.deltaTime * lerpSpeed);

			if (rectTrans.offsetMin.x < pageMin.x * 0.995f && rectTrans.offsetMin.y < pageMin.y * 0.995f && rectTrans.offsetMax.x > pageMax.x * 0.995f && rectTrans.offsetMax.y > pageMax.y * 0.995f) {
				rectTrans.offsetMin = pageMin;
				rectTrans.offsetMax = pageMax;

				///Changes the button color so it's visible in the page view.
				buttonRect.GetComponent<Image>().color = Color32.Lerp(buttonRect.GetComponent<Image>().color, new Color32(228, 0, 0, 191), Time.deltaTime * lerpSpeed);

				if (Mathf.Abs(buttonRect.GetComponent<Image>().color.a - 191) < 2) {
					titleBarImage.color = revealedTitleBarColor;
					
					buttonRect.GetComponent<Image>().color = new Color32(228, 0, 0, 191);
					
					animationActive = 0;
					CardStack.canUseHorizontalAxis = true;
				}
			}
		///When animationActive == -1, the page is shrinking into a card.
		} else if (animationActive == -1) {
			titleBarImage.color = Color32.Lerp(titleBarImage.color, hiddenTitleBarColor, Time.deltaTime * lerpSpeed * 1.125f);

			buttonRect.GetComponent<Image>().color = Color32.Lerp(buttonRect.GetComponent<Image>().color, new Color32(228, 0, 0, 0), Time.deltaTime * lerpSpeed * 1.25f);

			rectTrans.offsetMin = Vector2.Lerp(rectTrans.offsetMin, cardMin, Time.deltaTime * lerpSpeed);
			rectTrans.offsetMax = Vector2.Lerp(rectTrans.offsetMax, cardMax, Time.deltaTime * lerpSpeed);	
			
			if (rectTrans.offsetMin.x > cardMin.x * 1.005f && rectTrans.offsetMin.y > cardMin.y * 1.005f && rectTrans.offsetMax.x < cardMax.x * 1.005f && rectTrans.offsetMax.y < cardMax.y * 1.005f) {
				rectTrans.offsetMin = cardMin;
				rectTrans.offsetMax = cardMax;

				titleBarImage.color = hiddenTitleBarColor;

				///Makes the button take up the whole card.
				buttonRect.offsetMin = Vector2.zero;
				buttonRect.offsetMax = Vector2.zero;

				animationActive = 0;
				CardStack.canUseHorizontalAxis = true;
			}		
		}
	}

	public void ToggleCard() {
		CardStack.canUseHorizontalAxis = false;
		if (animationActive != 1) {
			animationActive = 1;
			cardCenter = transform.localPosition;

			///Makes the button the right size in page view.
			buttonRect.offsetMin = closeButtonMin;
			buttonRect.offsetMax = closeButtonMax;
		} else if (animationActive != -1) {
			animationActive = -1;
		}
	}
}