using UnityEngine;

public class TableController : MonoBehaviour {
    public GameObject collisionManager;

    private CollisionManager cm;

	// Use this for initialization
	void Start () {
        cm = collisionManager.GetComponent <CollisionManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
