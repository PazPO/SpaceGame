using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    
    public UnityEngine.UI.Text scoreTextElemtent;
    public UnityEngine.UI.Button startButton;
    public GameObject menu;
    protected bool isStarted;
    protected int score = 0;

    public bool getIsStarted()
    {
        return isStarted;
    }
    private static GameControllerScript instance;

    public static GameControllerScript getInstance()
    {
        if(instance == null){
            instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        }
        return instance;

    }



    // Start is called before the first frame update
    void Start()
    {
        scoreTextElemtent.text = "Score: 0";
        startButton.onClick.AddListener(delegate
        {
            isStarted = true;
            menu.SetActive(false);
            
        });
    }

    public void increaseScore(int increment)
    {
        score += increment;

        scoreTextElemtent.text = "Score: " + score;

    }

}
