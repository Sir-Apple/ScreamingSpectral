using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	[SerializeField]
	private Transform[] pictures;

	[SerializeField]
	private GameObject winText;

	[SerializeField]
	private GameObject loseText;

	[SerializeField]
	private Slider timeSlider;

	[SerializeField]
	private AudioSource sound1; 

	[SerializeField]
	private AudioSource sound2;  
	[SerializeField]
	private AudioSource sound3;  

	[SerializeField]
	private Image image1;

	[SerializeField]
	private Image jumpScare;

	[SerializeField]
	private GameObject mainMenuButton;

	public static bool youWin;
	public static bool youLose;

	private float[] rotationAngles = { -270, -180, -90, 90, 180, 270 };
	public float totalTime = 90f;
	private bool gameActive = true;
	private bool isBlinking = false;

	private void Start()
	{
		winText.SetActive(false);
		loseText.SetActive(false);
		image1.gameObject.SetActive(false); 
		jumpScare.gameObject.SetActive(false);
		mainMenuButton.gameObject.SetActive(false);
		youWin = false;
		youLose = false;

		// Randomly rotate each picture on the z-axis
		foreach (Transform picture in pictures)
		{
			float randomAngle = rotationAngles[Random.Range(0, rotationAngles.Length)];
			picture.rotation = Quaternion.Euler(0, 0, randomAngle);
		}

		timeSlider.maxValue = totalTime;
		timeSlider.value = totalTime;
	}

	private void Update()
	{
		if (gameActive)
		{
			totalTime -= Time.deltaTime;
			timeSlider.value = totalTime;

			if (totalTime <= 20f && !sound1.isPlaying)
			{
				sound1.Play();
				image1.gameObject.SetActive(true);
				StartCoroutine(BlinkImage());
			}

			if (totalTime <= 0)
			{
				LoseGame();
			}
		}
	}


	public void CheckWinCondition()
	{
		foreach (Transform picture in pictures)
		{
			if (Mathf.Abs(picture.rotation.eulerAngles.z) > 0.1f)
			{
				return;
			}
		}

		
		youWin = true;
		gameActive = false;
		winText.SetActive(true);
		image1.gameObject.SetActive(false);
		sound1.Stop();
		StartCoroutine(ShowBacktoMainMenu());
		StopCoroutine(BlinkImage());
	}

	private void LoseGame()
	{
		gameActive = false;
		youLose = true;
		loseText.SetActive(true);
		StopCoroutine(BlinkImage());
		image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 1f);
		StartCoroutine(PlayLoseSoundAndShowImage());
		StartCoroutine(ShowBacktoMainMenu());
		jumpScare.gameObject.SetActive(true);
	}

	
	private IEnumerator PlayLoseSoundAndShowImage()
	{
		yield return new WaitForSeconds(1f);

		sound1.Stop(); 
		sound2.Play();  
		sound3.Play();
	}
	private IEnumerator ShowBacktoMainMenu()
	{
		yield return new WaitForSeconds(2f);

		mainMenuButton.gameObject.SetActive(true);
	}

	// Coroutine to make the image blink with low opacity
	private IEnumerator BlinkImage()
	{
		isBlinking = true;
		while (isBlinking)
		{
			image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 0.1f);
			yield return new WaitForSeconds(0.9f);
			image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 0.5f);
			yield return new WaitForSeconds(0.9f);
		}
	}
}
