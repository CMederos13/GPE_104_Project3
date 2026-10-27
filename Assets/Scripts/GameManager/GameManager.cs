using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Lives")]
    public GameObject playerShipPreFab; //playership prefab, spawns at the player spawn point
    public Transform playerSpawnPoint; // where the ship spawns up in the air
    public int startingLives = 3; // Designers can set the amount of lives the player gets
    private int currentLives;
    public TMP_Text livesText; // Shows lives left in the UI 

    [Header("Player Health UI")]
    public Image playerHealthBar; // Health Bar fill image the ship updates
    public Transform playerDamageNumberParent; // Where the ghost damage numbers pop up

    [Header("Camera")]
    public CameraFollow cameraFollow; // The camera that follows the ship, gets the new ship after every respawn 

    [Header("Gameplay")]
    public PlayerController playerController;
    public LevelData currentLevel;
    public List<Obstacle> obstacleList; //kept for enemies from project 2

    public int score;

    public TMP_Text text;

    [Header("High Score")] // Highscore saved between plays
    public TMP_Text highScoreText; //Shows this run's score and the best score on the Game Over screen 
    public TMP_Text hudHighScoreText; // shows the best score on the gameplay HUD next to Current score and lives
    private int highScore; // best score so far, loaded from PlayerPrefs so it survives similar to settings  

    [Header("Audio Clips")]
    public AudioClip fireGunSound;

    public AudioClip gameOverSound;

    public AudioClip backgroundMusic;

    public AudioClip takingDamageSound;

    public AudioClip ufoHumSound; //kept for enemies from project 2

    public AudioClip deathSound; //Explosion when the ship or an enemy is destroyed

    [Header("Audio Sources")]
    public AudioSource sfxPlayer;

    public AudioSource musicPlayer;

    public AudioListener cameraListener; // The camera's ears the whole time in 3D

    [Header("Game Screens")]
    public GameObject mainMenuScreen;
    public GameObject creditsScreen;
    public GameObject settingsScreen;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    public GameObject titleScreen; // "Press Any Key to Start"


    [Header("Gameplay Screens")]
    public GameObject gameplay; // parent of the ship
    public GameObject gameplayUI; // Score and Health Bar


    // checks if win/lose while playing
    private bool isGameRunning = false;


    public void Awake()
    {
        obstacleList = new List<Obstacle>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Loads the saved High Score, starts the music and shows the title screen
    void Start()
    {
        // 0 if no high score was ever saved 
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        musicPlayer.clip = backgroundMusic;
        musicPlayer.Play();

        DoShowTitleScreen();
    }

    // Any Key on the title screen opens the main menu, then checks for lost ships and updates the UI
    void Update()
    {
        if (titleScreen != null && titleScreen.activeSelf && Input.anyKeyDown)
        {
            DoShowMainMenu();
        }

        // checking for a lost ship while game is running 
        if (isGameRunning)
        {
            if (playerController != null && playerController.pawn == null)
            {
                PlayerDied();
            }
        }

        if (text != null)
        {
            text.text = "" + score;
        }
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
        // Shows the best saved highscore, or current score once you've beaten it 
        if (hudHighScoreText != null)
        {
            hudHighScoreText.text = "Best: " + Mathf.Max(highScore, score);
        }
    }

    private void PlayerDied()
    {
        currentLives = currentLives - 1;

        if (currentLives > 0)
        {
            SpawnPlayer();
        }
        else
        {
            //Last Life Lost: Stops music so Game Over sound is Heard
            musicPlayer.Stop();
            sfxPlayer.PlayOneShot(gameOverSound);
            DoShowGameOver();
        }
    }
    // Creates new ship at the spawn point and connects it to controller, camera and Health UI
    private void SpawnPlayer()
    {
        // Removes the old ship if one is still in the scene 
        if (playerController.pawn != null)
        {
            Destroy(playerController.pawn.gameObject);
        }
        GameObject newShip = Instantiate(playerShipPreFab, playerSpawnPoint.position, playerSpawnPoint.rotation, gameplay.transform);

        // Hands over the new ship to the player controller
        playerController.pawn = newShip.GetComponent<Pawn>();

        if (cameraFollow != null) // tells the camera to follow the new ship 
        {
            cameraFollow.target = newShip.transform;
        }

        //Connect the new ship's health to the health bar UI
        Health shipHealth = newShip.GetComponent<Health>();
        if (shipHealth != null)
        {
            shipHealth.healthBar = playerHealthBar;
            shipHealth.damageNumberParent = playerDamageNumberParent;
        }
    }

    //Turns screen and gameplay off, this on what it needs when the bottons clicked
    private void HideAllScreens()
    {
        if (titleScreen != null) titleScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameplay.SetActive(false);
        gameplayUI.SetActive(false);

    }

    public void DoShowTitleScreen()
    {
        HideAllScreens();
        titleScreen.SetActive(true);
        cameraListener.enabled = true;
        isGameRunning = false;
        Time.timeScale = 1;
    }

    public void DoShowMainMenu()
    {
        //Restarts Music if game over stopped it
        if (!musicPlayer.isPlaying)
        {
            musicPlayer.Play();
        }

        HideAllScreens();
        mainMenuScreen.SetActive(true);
        cameraListener.enabled = true;
        isGameRunning = false;
        Time.timeScale = 1;
    }

    public void DoShowCredits()
    {
        HideAllScreens();
        creditsScreen.SetActive(true);
    }
    public void DoShowSettings()
    {
        HideAllScreens();
        settingsScreen.SetActive(true);
    }

    public void DoStartGame()
    {
        HideAllScreens();
        gameplay.SetActive(true);
        gameplayUI.SetActive(true);

        if (!musicPlayer.isPlaying)
        {
            musicPlayer.Play();
        }
        //Reset Run: Score 0, full lives, new ship at the spawn point

        score = 0;
        currentLives = startingLives;
        SpawnPlayer();

        if (currentLevel != null) // Fresh pickups and UFOs every new game
        {
            currentLevel.SpawnEntities();
        }

        Time.timeScale = 1;
        isGameRunning = true;
    }
    public void DoShowVictory()
    {
        isGameRunning = false;
        HideAllScreens();
        victoryScreen.SetActive(true);
        cameraListener.enabled = true;
    }

    // Saves a new high score and shows the Game Over screen
    public void DoShowGameOver()
    {
        isGameRunning = false;

        // Asks if new best? Save it so it persists between plays 
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (highScoreText != null)
        {
            highScoreText.text = "Score: " + score + "\nHigh Score: " + highScore;
        }

        HideAllScreens();
        gameOverScreen.SetActive(true);
        cameraListener.enabled = true;
    }
}