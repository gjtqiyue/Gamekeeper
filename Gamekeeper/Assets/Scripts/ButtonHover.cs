using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour {

	public Image theImage;
	public Color HoverColor;
	public Color NormalColor;

	public void OnPointerEnter () {
		theImage.color = HoverColor;
	}

	public void OnPointerExit () {
		theImage.color = NormalColor;
	}
}
