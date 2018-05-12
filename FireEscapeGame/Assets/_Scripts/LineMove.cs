using UnityEngine;
using System.Collections;

public class LineMove : MonoBehaviour {
	bool upOrDown = true; //whether we are moving up or down
	bool stopped = false;    //whether we have stopped or not
	public float upSpeed;    //our upwards movement speed
	public float downSpeed;    //our downwards movement speed
	public float minHeight;    //the min height at which we will change direction
	public float maxHeight;    //the max height at which we will change direction
	public float minWinHeight;    //the minimum height we must be at to win
	public float maxWinHeight;    //the maximum height we must be at to win

    public GameObject gameBar;
    public GameObject player;

    private void Start()
    {

    }

    void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {    //if the mouse is clicked
			if(!stopped){ //if we haven't stopped
				stopped = true;    //then stop
				Stopped ();
			}
			else {
				stopped = false;
			}
		}
		if(!stopped){ //if we haven't stopped
			MoveUpDown (); //move line
		}
	}


	void MoveUpDown()
	{
		if (upOrDown) {    //if we are moving up
			var speed = upSpeed;
			if(transform.position.y >= minWinHeight && transform.position.y <= maxWinHeight) {
				speed = upSpeed * 1.5f;
			}
			transform.Translate (Vector3.up * speed);    //move up
			if (transform.position.y > maxHeight) {    //if we are at the max height
				upOrDown = false;    //switch to moving down
			}
		} else {    //if we are moving down
			var speed = downSpeed;
			if(transform.position.y >= minWinHeight && transform.position.y <= maxWinHeight) {
				speed = downSpeed * 1.5f;
			}
			transform.Translate (Vector3.up * -speed);    //move down
			if (transform.position.y < minHeight) {    //if we are at the min height
				upOrDown = true; //switch to moving up
			}
		}
	}


	void Stopped()    //when we have stopped
	{
		Debug.Log(transform.position.y);
		if (transform.position.y > minWinHeight && transform.position.y < maxWinHeight) {
			
			Debug.Log ("YOU WIN!!!");    //if line is between win min and max height we win or lose

            // Mike's Random shit do with it as you please
            gameBar.SetActive(false); // hide bar when user has clicked it.
            player.transform.SetPositionAndRotation(new Vector3(50, 50, 0), new Quaternion(0, 0, 0, 45));


		} else {
			Debug.Log ("YOU LOSE");
		}
	}
}