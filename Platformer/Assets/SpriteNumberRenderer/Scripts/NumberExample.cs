using UnityEngine;
using System.Collections;

public class NumberExample : MonoBehaviour {


	public NumberRenderer theScore;

	public int score;

	// Use this for initialization
	void Start () 
	{
		//This is the main render function. Give this fuction the number you want to render.
		theScore.RenderNumber (0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		theScore.RenderNumber (score); //Render the score
	}


	public void OnGUI()
	{
		if (GUI.Button (new Rect (0, 0, 150, 100), "Press to Increase"))
		{
			score++;
		}
		if (GUI.Button (new Rect (0, 100, 150, 100), "Press to Decrease"))
		{
			if(score > 0) //Prevents going into negative, currently the system does not support negatives. 
			{
				score--;
			}
		}
		if (GUI.Button (new Rect (0, 200, 150, 100), "Press to Increase \n by 10"))
		{
			score += 10;
		}
		if (GUI.Button (new Rect (0, 300, 150, 100), "Press to Decrease \n by 10"))
		{
			if(score > 0) //Prevents going into negative, currently the system does not support negatives. 
			{
				score -= 10;
			}
		}
		if (GUI.Button (new Rect (0, 400, 150, 100), "Press to Increase \n by 100"))
		{
			score += 100;
		}
		if (GUI.Button (new Rect (0, 500, 150, 100), "Press to Decrease \n by 100"))
		{
			if(score > 99) //Prevents going into negative, currently the system does not support negatives. 
			{
				score -= 100;
			}
		}
	}
}
