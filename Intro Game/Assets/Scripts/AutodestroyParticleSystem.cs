using UnityEngine;
using System.Collections;

public class AutodestroyParticleSystem : MonoBehaviour {

	private ParticleSystem _particleSystem;

	public void Start() {
		_particleSystem = GetComponent<ParticleSystem> ();
	}

	public void Update() {
		if (_particleSystem != null) {
			Destroy (gameObject, _particleSystem.duration + _particleSystem.startLifetime);
		}
	}
}
