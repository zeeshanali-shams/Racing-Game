using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

	public float carSpeed;
	Vector3 position;
	public float maxPos = 2.2f;
	public uiManager ui;
	public AudioManager am;
	bool currentPlatformAndroid = false;
	Rigidbody2D rb;


	void Awake () {
		
		am.backgroungSound.Play ();

		rb = GetComponent<Rigidbody2D> ();

		#if UNITY_ANDROID 
		currentPlatformAndroid = true;
		#else 
		currentPlatformAndroid = false;
		#endif
	}


	// Use this for initialization
	void Start () {
		
		position = transform.position;
		if (currentPlatformAndroid = true)
			Debug.Log ("android");

	}
	
	// Update is called once per frame
	void Update () {
		/*if (currentPlatformAndroid = true) {
			//android codes
			position = transform.position;
			position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);
			transform.position = position;

			
		}*/ 

		//else {
			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime * 1.2f;
			position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);
			transform.position = position;
		//}
		if (Time.timeScale == 0) {
			am.carSound.Stop ();
		}
		if (Time.timeScale == 1) {
			am.carSound.Play ();
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy car") {
			Destroy (gameObject);
			ui.GameOverActivated ();
			am.carSound.Stop ();
			am.skidSound.Play ();


		}
			
	}


	public void MoveLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);

	}

	public void MoveRight(){
		rb.velocity = new Vector2 (carSpeed, 0);
	}

	public void SetVelocityZero(){
		rb.velocity = new Vector2 (0, 0); 
		 
	}

}

