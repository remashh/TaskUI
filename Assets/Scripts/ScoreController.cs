using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject stage;
    [SerializeField] private GameObject[] emptyStars;
    [SerializeField] private GameObject[] fullStars;
    [SerializeField] private Button OK;
    [SerializeField] private Button first;
    [SerializeField] private Button second;
    [SerializeField] private Button third;
    [SerializeField] private Image fadeImage;
    
    [SerializeField] private Text startText;
    [SerializeField] private Text scoreText;
    

    private int score;
    
    private bool active;
    public int starsAmount;

    void Start()
    {
        score = 0;
        startText.gameObject.SetActive(true);
        active = true;
        stage.SetActive(false);
        startText.text = "Press 1 or 2 or 3";
        
        foreach (var fullStar in fullStars)
        {
            fullStar.SetActive(false);
        }
        victory.SetActive(false);
    }

    void Update()
    {
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                victory.SetActive(true);
                ActivateStars(1);
                startText.gameObject.SetActive(false);
                score = 100;
                active = false;
                UpdateScoreText();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            { 
                victory.SetActive(true);
                ActivateStars(2);
                startText.gameObject.SetActive(false);
                score = 200;
                active = false;
                UpdateScoreText();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3)) 
            {
                victory.SetActive(true);
                ActivateStars(3);
                startText.gameObject.SetActive(false);
                score = 300;
                active = false;
                UpdateScoreText();
            }
        }
    }

    private void ActivateStars(int amount)
    {
        for (var i = 0; i < emptyStars.Length; i++)
        {
            fullStars[i].SetActive(i < amount);
        }
        starsAmount = amount;
        Debug.Log(starsAmount);
        Debug.Log(active);
    }
    public void OKButtonPressed()
    {
        victory.SetActive(false);
        stage.SetActive(true);
        //FadingOut();
    }

    public void LevelButtonPressed()
    {
        stage.SetActive(false);
        victory.SetActive(true);
        active = true;
        Start();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    /*private IEnumerator FadingOut(float duration = 4f)
    {
      
    }*/
}
