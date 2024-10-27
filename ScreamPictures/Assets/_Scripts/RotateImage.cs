using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
	public void ClickRotate()
	{
		if (!GameControl.youWin && !GameControl.youLose)
		{
			transform.Rotate(0f, 0f, 90f);
			GameObject.FindObjectOfType<GameControl>().CheckWinCondition();
		}
	}
}
