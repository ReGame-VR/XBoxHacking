using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial_size : MonoBehaviour {
    public Settings_vars settings_Vars;
    public int trials;
    public void SetTrialSize()
    {
        Settings_vars.trial_size = trials;
    }
}
