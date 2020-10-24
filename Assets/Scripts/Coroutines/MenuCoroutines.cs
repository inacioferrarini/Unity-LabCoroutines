using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCoroutines: MonoBehaviour {

	public GameObject pressAndWaitButton;
	public GameObject pressAndWaitOthersButton;

	public void StartPressAndWaitCompletion() {
		StartCoroutine(PressAndWaitCompletion(2.5f));
	}

	IEnumerator PressAndWaitCompletion(float waitTime) {
		Button button = pressAndWaitButton.GetComponent<Button>();
		if (button) {
			button.interactable = false;
		}
		Debug.Log("Coroutine1::will wait " + waitTime + " seconds");
		yield return new WaitForSeconds(waitTime);
		Debug.Log("After " + waitTime + " seconds, continuing PressAndWaitCompletion");
		if (button) {
			button.interactable = true;
		}
	}



	public void StartPressAndWaitOthersCompletion() {
		StartCoroutine(PressAndWaitOthersCompletion());
	}

	IEnumerator PressAndWaitOthersCompletion() {
		Button button = pressAndWaitOthersButton.GetComponent<Button>();
		if (button) {
			button.interactable = false;
		}

		Debug.Log("Will start SubCoroutine1");
		yield return StartCoroutine(SubCoroutine1());
		Debug.Log("ended SubCoroutine1");

		Debug.Log("Will start SubCoroutine2");
		yield return StartCoroutine(SubCoroutine2());
		Debug.Log("ended SubCoroutine2");

		Debug.Log("Will start SubCoroutine3");
		yield return StartCoroutine(SubCoroutine3());
		Debug.Log("ended SubCoroutine3");

		if (button) {
			button.interactable = true;
		}
	}

	IEnumerator SubCoroutine1() {
		yield return new WaitForSeconds(2.5f);
	}

	IEnumerator SubCoroutine2() {
		yield return new WaitForSeconds(2.5f);
	}

	IEnumerator SubCoroutine3() {
		yield return new WaitForSeconds(2.5f);
		Debug.Log("SubCoroutine3()::Done first wait");
		yield return new WaitForSeconds(2.5f);
		Debug.Log("SubCoroutine3()::Done second wait");
		yield return new WaitForSeconds(2.5f);
		Debug.Log("SubCoroutine3()::Done third wait");
		yield return new WaitForSeconds(2.5f);
		Debug.Log("SubCoroutine3()::Done fourth wait");
	}

}
