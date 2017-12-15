using UnityEngine;
using UnityEngine.UI;

public class Start_text : MonoBehaviour
{
    public Text start;
    Color color;
    void Start()
    {
        color = start.material.color;
    }
    void Update()
    {
       color.a -= 0.2F;
    }
}
