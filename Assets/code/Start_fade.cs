using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Start_fade : MonoBehaviour {
	private static string filename;
	private static string path;
	public static float completion_time=0;
    public Text start;
    public Color color;
    public int next_msg = 0, trial_size = 0;
    public float fade = 0; 
    public float start_time=1.0f;
    public string tell_user;
    static public bool begin = false, reset = false;
    private bool end_flag = false;
	public bool send_flag= false;

	public void saveToFile(){
		filename = Settings_vars.participant_ID+Settings_vars.date+Settings_vars.session;
		path = "Assets/Data/"+filename+".txt";
		completion_time = button_v2.score;


		StreamWriter writer = new StreamWriter(path, true);
		writer.Write("Sequence Size: ");
		writer.Write(Settings_vars.sequence_size);
		writer.Write(". Time Limit: ");
		writer.Write(Settings_vars.time_limit);
		writer.Write(". Number of Trials: ");
		writer.Write(trial_size);

		writer.Write(". Time to complete: ");
		writer.Write(completion_time);
		writer.Write(". Incorrect Presses: ");
		writer.WriteLine(Settings_vars.incorrect_presses);

		writer.Close();
		return;

	}
    private void initialize()
    {
        trial_size++;
        color.a = 1;
        next_msg = 0;
        fade = 0;
        begin = false;
        next_msg = 0;
        start_time = Time.time+2;
        reset = false;
        start.text = tell_user;
        return;
    }
    private void trials_over()
    {
        reset = true;
        tell_user = "Trials Completed, thank you!";
        end_flag = true;
        return;
    }
    void Start()
    {
        start.material.color = color;

    }
    void Update()
    {
        if (trial_size == Settings_vars.trial_size)
        {
            trials_over();
        }
        if (reset == true)
            initialize();
        color.a -= fade;
        start.material.color = color;
        if ((Time.time > start_time) && (next_msg == 0))
        {
            start_time += .8f;
            next_msg++;
			if (send_flag == true) 
			{
				saveToFile();
				send_flag = false;
			}
            if (end_flag == true)
            {
                Time.timeScale = 0;
                SceneManager.LoadScene("Menu");
            }
            else
                start.text = "3";
        }
        if ((Time.time > start_time) && (next_msg == 1))
        {
            start_time += .8f;
            next_msg++;
            start.text = "2";
        }
        if ((Time.time > start_time) && (next_msg == 2))
        {
            start_time += .8f;
            next_msg++;
            start.text = "1";
        }
        if ((Time.time> start_time) && (next_msg==3))
        {
            fade = 0.02f;
            start.text = "Go!";
            begin=true;
			send_flag = true;
        }
    }
}
