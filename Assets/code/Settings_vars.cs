using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Events;

public class Settings_vars : MonoBehaviour {
    
	public static int sequence_size = 5;
	public static int time_limit = 10; 
	public static int trial_size=10;
	public static float completion_time=0;
	public static float incorrect_presses=0;

	public static string participant_ID;
	public static string date;
	public static string session;

	private static string filename;
	private static string path;
    
	void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Update () {
	}

	//---------------------------------------------
	public void GetID(InputField temp1){
		participant_ID = temp1.text.ToString();
	}
	public void GetDate(InputField temp2){
		date = temp2.text.ToString();
	}
	public void GetSession(InputField temp3){
		session = temp3.text.ToString();
	}
	public void saveToFile(){
		filename = participant_ID+date+session;
		path = "Assets/Data/"+filename+".txt";
		completion_time = button_v2.score;


		StreamWriter writer = new StreamWriter(path, true);
		writer.Write("Sequence Size: ");
		writer.Write(sequence_size);
		writer.Write(". Time Limit: ");
		writer.Write(time_limit);
		writer.Write(". Number of Trials: ");
		writer.Write(trial_size);

		writer.Write(". Time to complete: ");
		writer.Write(completion_time);
		writer.Write(". Incorrect Presses: ");
		writer.WriteLine(incorrect_presses);

		writer.Close();
		return;

	}
}
