//lol
using UnityEngine;

public class AvatarScript : MonoBehaviour {

	public Animator anim;
	public bool click = false;

	private float time = 0.0f;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (click && time < 1.0f) {
			float deltaTime = Time.deltaTime;
			transform.Translate (new Vector3 (-52.0f, -35.0f, 110.0f) * deltaTime);
			time += deltaTime;
			if (time >= 1.0f || transform.position.x >= -15.0f) {
				transform.position = new Vector3 (-15.0f, -80.0f, -40.0f);
				click = false;
				time = 0.0f;
			}
		}
	}
}