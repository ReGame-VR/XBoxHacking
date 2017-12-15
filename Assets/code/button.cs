using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	
	public KeyCode key;
	public Transform explosionPrefab;
	public Color color = new Color(.2F, .3F, .4F);

	string[] sequence = { "butt_1", "butt_2", "butt_3", "butt_4", "butt_5" };
	int iterate = 0;

	bool active=false;
	GameObject note;
	float x=1,y=.1f,z=1,y2=0.001f;

	void Start () {
		note = GameObject.Find (sequence[iterate]);
	}

	void Update () {
		
		gameObject.GetComponent<Renderer> ().material.color = color;

		if(Input.GetKeyDown (key) && gameObject==note){
			transform.localScale = new Vector3(x, y2, z);
			print (iterate);
			print (sequence[iterate]);
			iterate++;
			print (iterate);
			print (sequence[iterate]);

		}

		if(Input.GetKeyUp (key)){
			transform.localScale = new Vector3(x, y, z);
		}
			
	}
		
}
