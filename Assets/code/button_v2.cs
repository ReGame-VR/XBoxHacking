using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class button_v2 : MonoBehaviour {
    public KeyCode key;
    private sequence sequence; // scripts we need variables frrom
    public Start_fade start_Fade;
    public Count_Score count_Score;
    public GameObject halo;
    public Color color = new Color(.2F, .3F, .4F);
    public int sequenceNum = 0;
    public Settings_vars settings_Vars;
    //while not decalred as static, other instances of this variable exist 
    //sequenceNum only changes uniformily because all isntances change together
    //but a variable like sequenceNumLag gets split into multiple values
    //and exists as both v,w,x,y, and z. We can't use static for sequenceNum though
    //since it will the value to always end false
    //also when static, they can be decalred from other scripts by bame, but w/out they
    //need to be told what object you are taking the specific variable from
    public static int sequenceNumLag = 0; 
    public static float score=0, round_clock = 0;
    bool prs =true, time_flag=true;
    float timer =0,error_timer,x=1,y=0.10F,z=1,y2=0.001F;
    int round = 0, round_size = 5;
    GameObject temp, correct;
    Color alpha;
	private bool sound = true;
    
	void Start ()
    {
        halo.SetActive(false);
    }
    
	public static bool scoreFlag = false;

	void Update () {
        round_size = Settings_vars.sequence_size;
        if (score > Settings_vars.time_limit)
        {
            sequenceNumLag = sequenceNum;
            start_Fade.tell_user= "Time! Try again";
        }
        else
        {
            start_Fade.tell_user = "Nice Job!";
        }

        temp = NumToButton(sequence.sequence_1[sequenceNum]);
        gameObject.GetComponent<Renderer> ().material.color = color;
        if(Start_fade.begin==true)//time before game starts
        {
            if (time_flag == true)//goes off at the begining of every sequence
            {
                timer = Time.time;
                round += round_size;
                time_flag = false;
            }
            if (sequenceNum < round && start_Fade.next_msg>0)
            {
                score = 0;
                Press(temp);
            }
            else
            {
                score = Time.time-timer;
                if (Input.GetKeyDown(key) && gameObject == NumToButton(sequence.sequence_1[sequenceNumLag]))
                {
					gameObject.GetComponent<AudioSource> ().Play ();
                    transform.localScale = new Vector3(x, y2, z);
                    sequenceNumLag++;
                    round_clock = Time.time;
                }
				sound = true;
                /*if (Input.GetKeyDown(key) && gameObject != NumToButton(sequence.sequence_1[sequenceNumLag]))
                {
                    print("errors: ");
                    print(errors);
                    errors++;

                }*/
				
                if (Input.GetKeyUp(key))
                {
                    transform.localScale = new Vector3(x, y, z);
                } 
                if (sequenceNumLag == sequenceNum && (Time.time - round_clock) > 0.4 && gameObject == NumToButton(sequence.sequence_1[sequenceNumLag]))//only resets in active button
                {
                    Start_fade.reset = true;
                }
                if (sequenceNumLag == sequenceNum && (Time.time - round_clock) > 0.4)//round_clock adds a delay to the end of eachc sequence for smooth transition
                {
                    score = Time.time;
                    transform.localScale = new Vector3(x, y, z);
                    Count_Score.currentScore = score - timer;
                    if (Count_Score.topScore > score - timer)
                        Count_Score.topScore = score - timer;
                    timer = Time.time;
                    scoreFlag = true;
                    time_flag = true;
                }
            }
        }
        if (sequenceNum >= 90)
        {
            sequenceNum = 0;
            sequenceNumLag = 0;
        }
    }

	void Press(GameObject obj) {
        scoreFlag = true;

        if ( prs == true && Time.time-timer < 0.5) //initaly true and 0
		{
			if (sound) {
				obj.GetComponent<AudioSource> ().Play ();
			}
			sound = false;
			obj.transform.localScale = new Vector3(x, y2, z);
            if(gameObject == temp)
               halo.SetActive(true);
            return;
		}

		sound = true;
		if(prs==false && Time.time-timer<0.5)
		{
			obj.transform.localScale = new Vector3(x, y, z);
            gameObject.GetComponent<button_v2>().halo.SetActive(false);
            return;
		}
        if (prs==false){
            sequenceNum++;
        }
        prs = !prs;
		timer = Time.time;
        return;
	}

	GameObject NumToButton(int num)
	{
		switch (num)
		{
		case 1:
			return GameObject.Find("B1");
		case 2:
			return GameObject.Find("B2");
		case 3:
			return GameObject.Find("B3");
		case 4:
			return GameObject.Find("B4");
		case 5:
			return GameObject.Find("B5");
		default:
			return gameObject;
		}
	}
}
