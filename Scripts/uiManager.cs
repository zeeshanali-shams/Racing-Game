using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour {

	public Text scoreText = null;
	public Button finalMenu;
	bool gameOver;
	float score;



	// Use this for initialization
	void Start () {
		gameOver = false;
		score = 0f;
		InvokeRepeating ("ScoreUpdate", 1f, 0.25f);

	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = " SCORE: " + score;

	}

	void ScoreUpdate(){
		if (gameOver == false) {
			score += 1f;
		}

	}

	public void GameOverActivated(){
		gameOver = true;
		finalMenu.gameObject.SetActive (true);


	}

	public void Pause() {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;

		}
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;

		} 
	}

	public void Play() {
		SceneManager.LoadScene ("level1", LoadSceneMode.Single);
		//Application.LoadLevel("level1");
	}

	public void MainMenu(){
		SceneManager.LoadScene ("menuScene", LoadSceneMode.Single);
		//Application.LoadLevel("menuScene");
	}

	public void EnterMenu(){
		SceneManager.LoadScene ("endScene", LoadSceneMode.Single);
		//Application.LoadLevel("endScene");
	}

	public void Exit() {
		Application.Quit ();
	}

}
