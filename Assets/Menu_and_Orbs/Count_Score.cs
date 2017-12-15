using UnityEngine;
using UnityEngine.UI;

public class Count_Score : MonoBehaviour {
    public button_v2 button_V2;
    public Text scoreText;
    string score,current, best=" ";
    public static float topScore=100, currentScore = 0; 
	
	void Update () {
        score="Time: " + (button_v2.score).ToString("F"); //the "F" makes it desplay only 2 decimals
        current = "Last Time: " + (currentScore).ToString("F");
        if (topScore != 100)
        {
            best = "Best: " + (topScore).ToString("F");
        }
        scoreText.text = score + "\r\n"+ current+"\r\n" + best;
    }
}
