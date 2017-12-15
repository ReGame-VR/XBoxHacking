using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class halo_alpha : MonoBehaviour {
    public ParticleSystem halo; //basically the obejct
    public Color alpha;
    void Awake () {
        halo = GetComponent<ParticleSystem>(); //component within has same name (stupid imo)
        alpha = halo.main.startColor.color;
	}
	
	void Update () {
        var main = halo.main;
        main.startColor = alpha;
    }
}
