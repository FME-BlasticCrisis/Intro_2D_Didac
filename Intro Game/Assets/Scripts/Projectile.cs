using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	public float Speed;
	public LayerMask CollisionMask;

	public GameObject Owner { get; private set;}
	public Vector2 Direction { get; private set;}
	public Vector2 InitialVelocity { get; private set;}

	public void Initialize(GameObject owner, Vector2 direction, Vector2 initialVelocity) {
		Owner = owner;
		Direction = direction;
		InitialVelocity = initialVelocity;
		OnInitialized ();
	}

	protected virtual void OnInitialized() {

	}

	public virtual void OnTriggerEnter2D(Collider2D other) {

		// Builtin layers in unity
		//
		// Layer # = Binary    = Decimal
		// Layer 0 = 0000 0001 = 1
		// layer 1 = 0000 0010 = 2
		// layer 2 = 0000 0100 = 4
		// Layer 3 = 0000 1000 = 8
		// layer 4 = 0001 0000 = 16
		// layer 5 = 0010 0000 = 32
		// Layer 6 = 0100 0000 = 64
		// Layer 7 = 1000 0000 = 128
		//
		// LayerMask = 0100 0110 (means we take layers 1, 2, 6)

		if ((CollisionMask.value & (1 << other.gameObject.layer)) == 0) {
			OnNotCollideWith (other);
			return;
		}

		var isOwner = other.gameObject == Owner;
		if (isOwner) {
			OnCollideOwner ();
			return;
		}

		var takeDamage = (ITakeDamage)other.GetComponent (typeof(ITakeDamage));
		if (takeDamage != null) {
			OnCollideTakeDamage (other, takeDamage);
			return;
		}

		OnCollideOther (other);
	}

	protected virtual void OnNotCollideWith(Collider2D other) {

	}

	protected virtual void OnCollideOwner() {

	}

	protected virtual void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage) {

	}

	protected virtual void OnCollideOther(Collider2D other) {

	}
}
