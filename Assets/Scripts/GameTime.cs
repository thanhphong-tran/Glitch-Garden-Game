﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTime : MonoBehaviour {

	// measure by seconds
	public float LevelSeconds = 60;
	public AudioClip clip;
	
	private Slider slider;
	private AudioSource audioSource;
	private bool isEnd = false;
	private LevelManager levelManager;
	private GameObject wonLabel;


	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		FindWonLabel ();
	}

	void FindWonLabel ()
	{
		wonLabel = GameObject.Find ("You Won");
		if (wonLabel == null) {
			Debug.Log ("Your won label is null");
		} else {
			wonLabel.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeSinceLevelLoad >= LevelSeconds && !isEnd) {
			audioSource.Play();
			wonLabel.SetActive(true);
			Invoke("LoadNextLevel", audioSource.clip.length);
			isEnd = true;
		} else {
			slider.value = Time.timeSinceLevelLoad / LevelSeconds;
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
}