using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_board : MonoBehaviour {
    public Text score;
    private int points;

	// Use this for initialization
	void Start () {
        points = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        this.score.text = this.points.ToString();
    }

    public void updatePoints(int add) {
        this.points += add;
        
    }

    public void Reset()
    {
        this.points = 0;
    }
}
