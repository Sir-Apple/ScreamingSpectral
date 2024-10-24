using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneController : MonoBehaviour
{
	// Function to load the Main Menu scene
	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu"); // Replace with your actual Main Menu scene name
	}

	// Function to load the Main Game scene
	public void LoadHardGame()
	{
		SceneManager.LoadScene("Main"); // Replace with your actual Main Game scene name
	}
	public void LoadEasyGame()
	{
		SceneManager.LoadScene("Main1"); // Replace with your actual Main Game scene name
	}

	// Function to reload the current scene (useful for restarting the game)
	public void ReloadCurrentScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Function to load a scene asynchronously (optional for smoother transitions)
	public void LoadSceneAsync(string sceneName)
	{
		StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
	}

	// Coroutine to handle async scene loading with progress
	private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

		while (!asyncLoad.isDone)
		{
			// Optional: You can display loading progress here (e.g., via UI elements)
			Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");
			yield return null;
		}
	}

	// Function to quit the application (works only in the built game)
	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Game is exiting..."); // This is to test in the editor, as Application.Quit() only works in a build
	}
}
