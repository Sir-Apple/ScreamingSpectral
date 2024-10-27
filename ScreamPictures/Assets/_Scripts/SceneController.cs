using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneController : MonoBehaviour
{
	// Load the Main Menu scene
	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	// Load the Main Game scene
	public void LoadHardGame()
	{
		SceneManager.LoadScene("Main");
	}
	public void LoadEasyGame()
	{
		SceneManager.LoadScene("Main1");
	}

	// Reload the current scene
	public void ReloadCurrentScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Load a scene asynchronously (optional for smoother transitions)
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

	// Quit the application (works only in the built game)
	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Game is exiting...");
	}
}
