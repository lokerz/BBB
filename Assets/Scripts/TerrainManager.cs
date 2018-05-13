using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {
	public GameObject floor;
	public int boxLength;
	public int boxCount;
	public int towerPercentage;
	public int fallCount;
	public float fallTimer;

	private List<GameObject> terrains;
	private List<float> height;
	private List<int> randArr;
	private float timer;
	private int n = 0;
	private int o = 0;

	void Start () {
		height = new List<float> ();
		terrains = new List<GameObject> ();
		randArr = new List<int> ();

		addTower ();
		buildTerrain (boxCount);
		randomize ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer >= fallTimer) {
			timer = 0;
			for (int i = 0; i < fallCount; i++) {
				if (terrains [randArr[i+(o*fallCount)]] != null){
					terrains [randArr [i+(o*fallCount)]].GetComponent<TerrainMovement> ().isDown = true;

				}
			}
			o++;
		}
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
				terrains.Add(Instantiate (floor,new Vector3(x,y,z), transform.rotation));
				n++;
			}
			z = -i+(boxLength * j);
		}

        for (int j = 0; j < n; j++)
            if (terrains[j].transform.position.y > 0)
                terrains[j].tag = "Tower";

	}

	public void randomize(){
		int temp;
		int randIndex;

		for (int i = 0; i < n; i++) {
			randArr.Add(i);
		}

		for (int i = 0; i < n; i++) {
			temp = randArr [i];
			randIndex = Random.Range(i, n);
			randArr[i] = randArr[randIndex];
			randArr[randIndex] = temp;
		}
	}

}
