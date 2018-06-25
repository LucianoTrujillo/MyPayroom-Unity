using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UFO : MonoBehaviour {

	public float moveSpeed = 0.5f;
	Vector3 computerDirection;
	Vector3 moveDirection = Vector3.zero;
	Vector3 newPosition = Vector3.zero;

	public Transform lttr;

	private bool isDriven = false;
	private bool isMoving = true;
	private ParticleSystem exp;
	private Transform myLttr;

	/*public Transform[] wayPointList;
	public int currentWayPoint = 0;
	public float speed = 4f;

	private Transform targetWayPoint;
	private LineRend lr;

	void Awake () {
		lr = gameObject.AddComponent<LineRend> ();
	}

	void Update () {
		transform.Rotate (Quaternion.Euler (0f, 10f, 0f));

		if (currentWayPoint < wayPointList.Length) {
			if (targetWayPoint == null)
				targetWayPoint = wayPointList [currentWayPoint];
			
		}
	}

	void Walk () {
		transform.position = Vector3.MoveTowards (transform.position, targetWayPoint.position, speed * Time.deltaTime);

		if (transform.position == targetWayPoint.position) {
			currentWayPoint++;
			targetWayPoint = wayPointList [currentWayPoint];
		}
	}*/

	public GameObject objectPathMarker;	
	public RaycastHit rayHit;

	private Vector3 pointStore;
	private float[] posStoreX = new float[100];
	private float[] posStoreZ = new float[100];
	private GameObject[] arrayPathMarker = new GameObject[100];
	private Vector3 mousePoint;
	private int countMove;
	private float speed = 1.0f;
	private float startTime;

	private int countDrag;
	private bool dragging;
	private bool moving;

	void Start () {
		transform.Rotate (new Vector3 (0f, UnityEngine.Random.value, 0f));
		dragging = false;
		computerDirection = new Vector3 ((float)UnityEngine.Random.Range (-1, 2), 0f, (float)UnityEngine.Random.Range (-1, 2));
		exp = GetComponent<ParticleSystem> ();
		myLttr = Instantiate (lttr, transform.position, Quaternion.Euler (90f, 0f, 0f));
		myLttr.gameObject.GetComponent<TextMesh> ().text = AssignLetter ();
	}

	string AssignLetter () {
		int r = UnityEngine.Random.Range (1, 174);
		if (r >= 1 && r <= 9) return "A";
		if (r >= 10 && r <= 16) return "B";
		if (r >= 17 && r <= 23) return "C";
		if (r >= 24 && r <= 31) return "D";
		if (r >= 32 && r <= 40) return "E";
		if (r >= 41 && r <= 46) return "F";
		if (r >= 47 && r <= 54) return "G";
		if (r >= 55 && r <= 60) return "H";
		if (r >= 61 && r <= 69) return "I";
		if (r >= 70 && r <= 71) return "J";
		if (r >= 72 && r <= 76) return "K";
		if (r >= 77 && r <= 85) return "L";
		if (r >= 86 && r <= 92) return "M";
		if (r >= 93 && r <= 101) return "N";
		if (r >= 102 && r <= 110) return "O";
		if (r >= 111 && r <= 117) return "P";
		if (r >= 118 && r <= 126) return "R";
		if (r >= 127 && r <= 135) return "S";
		if (r >= 136 && r <= 144) return "T";
		if (r >= 145 && r <= 153) return "U";
		if (r >= 154 && r <= 159) return "V";
		if (r >= 160 && r <= 165) return "W";
		if (r >= 166 && r <= 167) return "X";
		if (r >= 168 && r <= 173) return "Y";
		return "A";
	}

	void Update () {

		if (isMoving) {
			transform.Rotate (new Vector3 (0f, 1f, 0));
			myLttr.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
			if (transform.position.x < -1f && transform.position.x > -2f && transform.position.z < -1.5f && transform.position.z > -2.5f) {
				if (UFOs.ufoPlanet1 != null) {
					exp.Play ();
					Destroy (gameObject, exp.duration / 2);
					Destroy (UFOs.ufoPlanet1, exp.duration / 2);
					UFOs.ufoPlanet1 = null;
				} else {
					transform.position = new Vector3 (-1.5f, 0f, -2f);
					UFOs.ufoPlanet1 = gameObject;
					isMoving = false;
				}
			}
			if (transform.position.x < 0.5f && transform.position.x > -0.5f && transform.position.z < -1.5f && transform.position.z > -2.5f) {
				if (UFOs.ufoPlanet2 != null) {
					exp.Play ();
					Destroy (gameObject, exp.duration / 2);
					Destroy (UFOs.ufoPlanet2, exp.duration / 2);
					UFOs.ufoPlanet2 = null;
				} else {
					transform.position = new Vector3 (0f, 0f, -2f);
					UFOs.ufoPlanet2 = gameObject;
					isMoving = false;
				}
			}
			if (transform.position.x < 2f && transform.position.x > 1f && transform.position.z < -1.5f && transform.position.z > -2.5f) {
				if (UFOs.ufoPlanet3 != null) {
					exp.Play ();
					Destroy (gameObject, exp.duration / 2);
					Destroy (UFOs.ufoPlanet3, exp.duration / 2);
					UFOs.ufoPlanet3 = null;
				} else {
					transform.position = new Vector3 (1.5f, 0f, -2f);
					UFOs.ufoPlanet3 = gameObject;
					isMoving = false;
				}
			}
			if (isDriven) {

				transform.position += transform.forward * speed * Time.deltaTime;

				if (transform.position.z >= 3f || transform.position.z <= -3f) {
					transform.localRotation = Quaternion.Euler (0f, -transform.localRotation.y, 0f);
				}
				if (transform.position.x <= -5.75f || transform.position.x >= 5.75f) {
					transform.localRotation = Quaternion.Euler (0f, -transform.localRotation.y + 180f, 0f);
				}

				// note - raycast needs a surface to hit against
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit)) {
					// where did the raycast hit in the world - position of rayhit
					mousePoint = rayHit.point;

					if (Input.GetMouseButtonDown (0)) {
						OnTouchBegin (mousePoint);
					} else if (Input.GetMouseButton (0)) {
						OnTouchMove (mousePoint);
					} else if (Input.GetMouseButtonUp (0)) {
						OnTouchEnd (mousePoint);
					}
				}
			} else if (!isDriven) {
				Vector3 newPosition = computerDirection * (moveSpeed * Time.deltaTime);
				newPosition = transform.position + newPosition;

				transform.position = newPosition;

				if (newPosition.x > 5) {
					newPosition.x = 5;
					computerDirection.x *= -1;
				} else if (newPosition.x < -5) {
					newPosition.x = -5;
					computerDirection.x *= -1;
				}


				transform.position = newPosition; 

				if (newPosition.z > 3) {
					newPosition.z = 3;
					computerDirection.z *= -1;
				} else if (newPosition.z < -3) {
					newPosition.z = -3;
					computerDirection.z *= -1;
				}
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("UFO")) {
			exp.Play ();
			Destroy (gameObject, exp.duration / 2);
			Destroy (UFOs.ufoPlanet2, exp.duration / 2);
			isMoving = false;
		}
	}

	void OnTouchBegin (Vector3 pointCurrent) {
		countDrag = 0;
		Array.Clear (posStoreX, 0, posStoreX.Length);
		Array.Clear (posStoreZ, 0, posStoreZ.Length);
		AddSplinePoint(pointCurrent);
		dragging = true;
		moving = false;
	}

	void OnTouchMove (Vector3 pointCurrent) {
		if ((dragging) && (countDrag < 100)) {
			AddSplinePoint(pointCurrent);
		} else {
			dragging = false;
			moving = true;
		}
	}

	void OnTouchEnd (Vector3 pointCurrent) {
		dragging = false;
		moving = true;
		startTime = Time.time;
	}

	void AddSplinePoint (Vector3 pointStore) {
		posStoreX[countDrag] = pointStore.x;
		posStoreZ[countDrag] = pointStore.z;

		arrayPathMarker [countDrag] = Instantiate (objectPathMarker, new Vector3 (pointStore.x, 0, pointStore.z), transform.rotation);

		countDrag ++;
	}

	void FixedUpdate () {
		if (moving) {
			if (countMove >= posStoreX.Length - 1) {
				moving = false;
			}

			float distanceBetween = Vector3.Distance(new Vector3 (posStoreX [countMove], 0, posStoreZ [countMove]), new Vector3 (posStoreX [countMove + 1], 0, posStoreZ [countMove + 1]));

			float distanceTime = (Time.time - startTime) * speed;

			float reltiveTime = distanceTime / distanceBetween;

			transform.position = Vector3.Lerp(transform.position, new Vector3 (posStoreX [countMove + 1], 0, posStoreZ [countMove + 1]),  reltiveTime);

			if (Vector3.Distance(new Vector3 (posStoreX [countMove], 0, posStoreZ [countMove]), new Vector3 (posStoreX [countMove + 1], 0, posStoreZ [countMove + 1])) > distanceBetween)
				countMove ++;
		} else {
			countMove = 0;
		}
	}
}