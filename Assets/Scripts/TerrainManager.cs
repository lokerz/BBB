using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {
	public GameObject floor;
	public int boxLength;
	public int boxCount;
	public int towerPercentage;

	private List<float> height;

	// Use this for initialization
	void Start () {
		height = new List<float> ();
		addTower ();
		buildTerrain (boxCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void addTower(){
		int total = boxCount * boxCount;
		int tower = total * towerPercentage / 100;
		for (int i = 0; i < total-tower; i++)
			height.Add (0);
		for (int i = 0; i < tower; i++)
			height.Add (floor.transform.localScale.y);
		
	}
	public void buildTerrain(int i){
		float x = -i; //-100
		float z = -i;
		float y;
		for (int j = 0; j < i; j++) {
			for (int k = 0; k < i; k++) {
				x = -i + (boxLength * k); //-50 50 , -100 100, -150 150; -100 0
				y = height[Random.Range(0,height.Count)];
				Instantiate (floor,new Vector3(x,y,z), transform.rotation);
			}
			z = -i+(boxLength * j);
			//Debug.Log (x+" "+z);
		}
	}
}
