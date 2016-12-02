﻿using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume){
		if (volume > 0f && volume < 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range");
		}
	}

	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level) {
		if (level >= 0 && level < Application.levelCount) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1);
		} else {
			Debug.LogError ("Trying to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked(int level) {
		if (level >= 0 && level < Application.levelCount) {
			return PlayerPrefs.GetInt (LEVEL_KEY + level.ToString()) == 1;
		} else {
			Debug.LogError ("Trying to unlock level not in build order");
			return false;
		}
	}

	public static void SetDifficulty (float diff) {
		PlayerPrefs.SetFloat (DIFFICULTY_KEY, diff);
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}


}
