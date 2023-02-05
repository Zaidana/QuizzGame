using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandle : MonoBehaviour
{
	public GameObject currentScore;
	public TextMeshProUGUI output;
    // Start is called before the first frame update
    void Start()
    {
	    
	    output.text = PlayerPrefs.GetString("currentScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
