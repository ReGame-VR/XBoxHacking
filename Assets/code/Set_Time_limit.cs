using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Time_limit : MonoBehaviour {
    public Settings_vars settings_Vars;
    public int time;
    public void SetTimeLimit()
    {
        Settings_vars.time_limit = time;
    }
}
