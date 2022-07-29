using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreBoard : MonoBehaviour
{
    public int Multiplier = 1;
  
    public float k;
    public float j;
    public float r;
    public float TargetScore;
    public Text scoreText;
    public Text hiScoreText;
    public CameraController cam;
    public PlayerController player;
    public LevelGenerator level;
    public WallDeactivator destroyer;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        scoreIncreasing = true;
        hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        Multiplier = PlayerPrefs.GetInt("Multiplier",1);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
        scoreCount += pointsPerSecond * Time.deltaTime * 300 * Multiplier;
        }

        if (scoreCount > hiScoreCount)
        {
            PlayerPrefs.SetFloat("HighScore", scoreCount);
            PlayerPrefs.Save();
        }
        scoreText.text = "Score " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score " + Mathf.Round (hiScoreCount);
       
        if (scoreCount >= TargetScore) // условие при котором выполняется прибавка скорости
        {
            //Camera.main.GetComponent<Camera>().backgroundColor = new Color(255f, 255f, 255f);
            player.speed = player.speed + k; // добавление скорости игрока, с которой он движется вперёд, с помощью значения k
            //player.joyspeed = player.joyspeed + k;
            player.arspeed = player.arspeed + r; // добавление скорости игрока, с которой он движется влево и вправо, с помощью значения к
            //cam.CamSpeed = cam.CamSpeed + j;
            destroyer.DeleteSpeed = destroyer.DeleteSpeed + j; // добавление скорости игрока с помощью значения k
            level.l = level.l - j; // уменьшение задержки создания новых объектов
            if (level.l == 0.3f) 
            {
                level.l = 0.3f;
                j = 0;
            }
            //cam.rb.velocity = new Vector3(cam.CamSpeed, 0, 0);
            player.rb.velocity = new Vector3(player.speed, 0, 0); // новая скорость игрока при достижении используемого условия
            destroyer.rb.velocity = new Vector3(destroyer.DeleteSpeed, 0, 0); // новая скорость стены, уничтожающая на пути объекты при достижении используемого условия
            TargetScore += 5000; // прибавление к значению 5000 очков
           
        }

    }
}
