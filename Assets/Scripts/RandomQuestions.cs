using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class RandomQuestions : MonoBehaviour
{
	
	public int numberQuestions;
	public int count = 0;
	public List<int> numberRandom;
	public bool stop = false;
	public GameObject[] questions;
	public int countQuestions = 0;
	public int score = 0;
	public TextMeshProUGUI output;
	

	
	
    // Start is called before the first frame update
    void Start()
	{
		output.text = "Score: " + score;
		
		while (!stop)
		{
		
			int temp = Random.Range(0, numberQuestions-1);
				if (!numberRandom.Contains(temp))
				{
					numberRandom.Add(temp);
					count++;
				}
			if (count == numberQuestions-1)
			{ 
				break;
			}
        
		}
		questions[numberRandom[countQuestions]].SetActive(true);
			
		
	}
    
	void Update()
	{
		
		if (countQuestions == 7)
		{
			SceneManager.LoadScene ("Scene3");
			
		}
		
	}
	
	public void ActiveQuestion ()
	{
		if (countQuestions < numberRandom.Count && numberRandom[countQuestions] < questions.Length)
		{
			questions[numberRandom[countQuestions]].SetActive(false);
				countQuestions++;
				
		}
		if (countQuestions < numberRandom.Count && numberRandom[countQuestions] < questions.Length)
		{
			questions[numberRandom[countQuestions]].SetActive(true);
			
		}
	
	}
	
	public void correctOption(Button _boton)
	{
		StartCoroutine(CorrectOptionCoroutine(_boton));
		
	}
	
	public void incorrectOption(Button _boton)
	{
		StartCoroutine(IncorrectOptionCoroutine(_boton));
		
	}
	
	public IEnumerator CorrectOptionCoroutine(Button _boton)
	{
		_boton.image.color = Color.green;
		score+=100;
		output.text = "Score: " + score;
		yield return new WaitForSeconds(0.5f);
		ActiveQuestion();
	}
	
	public IEnumerator IncorrectOptionCoroutine(Button _boton)
	{
		_boton.image.color = Color.red;
		yield return new WaitForSeconds(0.5f);
		ActiveQuestion();
	}
	

}


