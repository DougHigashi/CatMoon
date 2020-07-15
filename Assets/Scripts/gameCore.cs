using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameCore : MonoBehaviour
{
	#region Variaveis
	//Monstra dentro do inspector -> serializedField
	[SerializeField] private int score;
	[SerializeField] private int lifeScore;

	bool gameHasEnded = false;
	#endregion

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ResetGame();
		}
	}

	public void ResetGame()
	{

		Restart();
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GameOver");
			Restart();
		}

	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	IEnumerator MagiaCD(float segundos)
	{

		yield return new WaitForSeconds(segundos);
		Debug.Log("skill em cd");
	}
}
