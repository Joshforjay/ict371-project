using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	[SerializeField]
	AudioSource musicSrc_;
	[SerializeField]
	AudioSource pickupSfxSrc_;

	// Start is called before the first frame update
	void Start() {
		musicSrc_.loop = true;
		musicSrc_.Play();
	}

	void OnEnable() {
		TCellCollision.OnBCellCollect += PlayPickupSfx;
	}

	void OnDisable() {
		TCellCollision.OnBCellCollect -= PlayPickupSfx;
	}

	void PlayPickupSfx() {
		pickupSfxSrc_.Play();
	}
}
