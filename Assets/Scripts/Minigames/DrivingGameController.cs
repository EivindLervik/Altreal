using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrivingGameController : MonoBehaviour
{
    [Header("Score")]
    public bool gameOn;
    public int level = 1;
    public int score = 0;
    private float actualScore;
    public Text level_text;
    public Text score_text;
    public RectTransform leaderboard_object;
    public RectTransform score_object;
    public RectTransform level_object;

    [Header("Difficulty")]
    public float difficulty;
    public float scoreModifier;

    [Header("Roads")]
    public Transform[] roads;
    public int roadSize;
    public float roadBaseSpeed;
    public float roadAcceleration;
    private float targetRoadSpeed;

    [Header("Cars")]
    public Transform playerCar;
    public MainCarScript playerCarScript;
    public float carTurnSpeed;
    private Animator playerCarAnimator;
    private int lane;
    public GameObject carObject;
    public float enemyCarBaseSpeed;
    public Transform carObjectHolder;

    private List<EnemyCarScript> spawnedCars;

    void Start()
    {
        lane = 2;
        playerCarAnimator = playerCarScript.gameObject.GetComponentInChildren<Animator>();
        playerCarScript.dgc = this;

        spawnedCars = new List<EnemyCarScript>();
        leaderboard_object.gameObject.SetActive(false);

        StartCoroutine("SpawnLoop");
    }

    void Update()
    {
        // Update score
        if (gameOn)
        {
            actualScore += Time.deltaTime * scoreModifier;
            score = Mathf.FloorToInt(actualScore);
            level = Mathf.CeilToInt(score / difficulty);
        }

        // Update GUI
        level_text.text = level.ToString();
        score_text.text = score.ToString();

        // Lerps
        if (gameOn)
        {
            targetRoadSpeed = Mathf.Lerp(targetRoadSpeed, roadBaseSpeed + ((level - 1) * 1.5f), roadAcceleration * Time.deltaTime);
            playerCar.position = new Vector3(Mathf.Lerp(playerCar.position.x, lane, carTurnSpeed * Time.deltaTime), playerCar.position.y, playerCar.position.z);
        }
        else
        {
            targetRoadSpeed = 0.0f;
        }

        // Enemy Cars
        if (gameOn)
        {
            for (int i = 0; i < spawnedCars.Count; i++)
            {
                GameObject go = spawnedCars[i].gameObject;
                int lane = spawnedCars[i].myLane;

                float speed = enemyCarBaseSpeed;
                switch (lane)
                {
                    case 0:
                        speed *= 1.5f;
                        speed += targetRoadSpeed;
                        break;
                    case 1:
                        speed *= 2.0f;
                        speed += targetRoadSpeed;
                        break;
                    case 2:
                        speed = targetRoadSpeed - (enemyCarBaseSpeed * 1.5f);
                        break;
                    case 3:
                        speed = targetRoadSpeed - enemyCarBaseSpeed;
                        break;
                }
                print(-go.transform.forward * speed * Time.deltaTime);

                go.transform.Translate(-go.transform.forward * speed * Time.deltaTime);

                if (go.transform.position.z <= -(roadSize * 2.0f))
                {
                    spawnedCars.Remove(spawnedCars[i]);
                    Destroy(go);
                    i--;
                }
            }
        }

        // Roads
        foreach (Transform t in roads)
        {
            t.Translate(-Vector3.forward * targetRoadSpeed * Time.deltaTime);
            if (t.position.z <= -(roadSize * 2.0f))
            {
                t.position = new Vector3(t.position.x, t.position.y, t.position.z + (roads.Length * roadSize));
            }
        }

        // Input
        if (gameOn)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                lane -= 4;
                if (lane < -6)
                {
                    lane = -6;
                }
                else
                {
                    playerCarAnimator.SetTrigger("TurnLeft");
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                lane += 4;
                if (lane > 6)
                {
                    lane = 6;
                }
                else
                {
                    playerCarAnimator.SetTrigger("TurnRight");
                }
            }
        }
    }

    public void Crash()
    {
        gameOn = false;
        playerCarAnimator.SetTrigger("Crash");
        
    }

    public void ShowLeaderboards()
    {
        // Show leaderboards
        leaderboard_object.gameObject.SetActive(true);
        level_object.gameObject.SetActive(false);
        score_object.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        leaderboard_object.gameObject.SetActive(false);
        level_object.gameObject.SetActive(true);
        score_object.gameObject.SetActive(true);
        playerCarAnimator.SetTrigger("Restart");

        // Enemy Cars
        for (int i = 0; i < spawnedCars.Count; i++)
        {
            Destroy(spawnedCars[i].gameObject);
            spawnedCars.Remove(spawnedCars[i]);
            i--;
        }

        playerCar.transform.position = new Vector3(2.0f, 0.0f, 0.0f);

        level = 1;
        score = 0;
        actualScore = 0.0f;
        lane = 2;

        gameOn = true;
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (gameOn)
            {
                int lane = Random.Range(0, 4);
                EnemyCarScript ecs = Instantiate(carObject, new Vector3(-6 + (lane * 4), 0.0f, roads.Length * roadSize), Quaternion.identity, carObjectHolder).GetComponent<EnemyCarScript>();
                ecs.myLane = lane;
                spawnedCars.Add(ecs);

                if(lane == 0 || lane == 1)
                {
                    ecs.gameObject.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                }

                yield return new WaitForSeconds(1.0f / (level * 0.5f));
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
