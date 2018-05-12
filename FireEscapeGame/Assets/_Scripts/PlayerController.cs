using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public GameObject CollisionManager;

    private Rigidbody rb;
    private int count = 0;
    private CollisionManager cm;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cm = CollisionManager.GetComponent<CollisionManager>();
	}
	
	// Update is called once per frame
	void Update () {		
	}

    void FixedUpdate() {
        var moveHorizantal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizantal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count++;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            cm.DoShit();
        }
    }
}
