using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour {

    public static PlayerManagement Instance;

   public bool player1 = false;
    public bool player2 = false;
   public  bool player3 = false;
    public bool player4 = false;
    public int player1Lives = 3;
    public int player2Lives = 3;
    public int player3Lives = 3;
    public int player4Lives = 3;
    public int playerCount = 0;

    public GameObject player1Object;
    public GameObject player2Object;
    public GameObject player3Object;
    public GameObject player4Object;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene);
        if (scene.name == "Lobby")
        {
            if (Input.GetButton("BackToMenu"))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetButton("P1Confirm"))
            {
                if (player1 == false)
                {
                    player1 = true;
                    Debug.Log(player1);
                    playerCount++;
                }
                
                
            }
            else if(Input.GetButton("P1Cancel"))
            {
                if(player1 == true)
                {
                    playerCount--;
                    player1 = false;
                    
                    Debug.Log("PLayer 1 cancelled");
                }
                
                
                
                
            }

            if (Input.GetButton("P2Confirm"))
            {
                if (!player2)
                {
                    player2 = true;
                    
                    playerCount++;
                }
            }
            else if (Input.GetButton("P2Cancel"))
            {
                if (player2)
                {
                    player2 = false;
                    playerCount--;
                }
            }

            if (Input.GetButton("P3Confirm"))
            {
                if (!player3)
                {
                    player3 = true;
                    playerCount++;
                }
            }
            else if (Input.GetButton("P3Cancel"))
            {
                if (player3)
                {
                    player3 = false;
                    playerCount--;
                }
            }

            if (Input.GetButton("P4Confirm"))
            {
                if (!player4)
                {
                    player4 = true;
                    playerCount++;
                }
            }
            else if (Input.GetButton("P4Cancel"))
            {
                if (player4)
                {
                    player4 = false;
                    playerCount--;
                }
            }

        }

        if(Input.GetButton("Tim's Level"))
        {
            Scene scene1 = SceneManager.GetActiveScene();
            if (scene.name == "Lobby")
            {
                if (playerCount >= 1)
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
		
	}

    void Awake()
    {
        
       if (Instance == null)
       {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            //Debug.Log(player1);
        }
       else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Debug.Log(player1);
       // Debug.Log(player2);
       // Debug.Log(player3);
       // Debug.Log(player4);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene scene1 = SceneManager.GetActiveScene();
        if (scene.name != "Lobby" && scene.name != "Callan")
        {
            Debug.Log(player1);
            if (player1)
            {
           // if (player1Lives != 0)
           // {
                Instantiate(player1Object);
                player1Object.transform.position = new Vector3(-5f, 2.0f, 0.0f);
           // }
            }

            if (player2)
            {
          //  if (player2Lives != 0)
        //    {
                Instantiate(player2Object);
                player2Object.transform.position = new Vector3(0f, 2.0f, 0.0f);
         //   }
            }

            if (player3)
            {
         //       if (player3Lives != 0)
         //       {
                    Instantiate(player3Object);
                    player3Object.transform.position = new Vector3(5f, 2.0f, 0.0f);
         //       }
            }

            if (player4)
            {
         //           if (player4Lives != 0)
          //          {
                        Instantiate(player4Object);
                        player4Object.transform.position = new Vector3(10f, 2.0f, 0.0f);
         //           }
            }
        }
    }
}
