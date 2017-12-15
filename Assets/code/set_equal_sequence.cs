using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_equal_sequence : MonoBehaviour {
    public Settings_vars settings_Vars;
    public int size;
    
	public void SetSequenceSize()
    {
        Settings_vars.sequence_size= size;
		Debug.Log (Settings_vars.sequence_size);
    }
}
