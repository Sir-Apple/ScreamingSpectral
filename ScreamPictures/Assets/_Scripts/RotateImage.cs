using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
	public void ClickRotate()
	{
		// Prevent rotation if the player has already won or lost
		if (!GameControl.youWin && !GameControl.youLose)
		{
			// Rotate the image by 90 degrees on the z-axis
			transform.Rotate(0f, 0f, 90f);

			// Check if the win condition is met after the rotation
			GameObject.FindObjectOfType<GameControl>().CheckWinCondition();
		}
	}
}
