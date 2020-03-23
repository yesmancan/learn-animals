using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    public GameManager()
    {
        instance = this;
    }
    #endregion

    public GameObject mobilControls;

    public static bool restartGame = false;

    public GameObject spawnerLeft;
    public GameObject spawnerMiddle;
    public GameObject spawnerRight;

    public GameObject goPointLeft;
    public GameObject goPointMiddle;
    public GameObject goPointRight;

    public GameObject spawnAnimal;

    public float spawnSpeed = 1f;
    public float previosTime = 0f;
    public float animalRunSpeed = 10f;

    public bool twoIndex = false;
    public int spawnAnimaCount = 0;
    public int allSpawnAnimaCount = 0;

    public GameObject points;
    public GameObject pointsShadow;

    public GameObject topPoints;
    public GameObject topPointsShadow;

    public GameObject pointArea;

    public GameObject upPoints;

    public List<Button> buttons;

    public bool isGameOver = false;

    readonly System.Random rnd = new System.Random();
    public void SetRestartGame()
    {
        restartGame = true;
    }
    void Start()
    {
        topPoints.GetComponent<TextMeshProUGUI>().text = " TOP " + PlayerPrefs.GetInt("TopPoints", 0).ToString();
        topPointsShadow.GetComponent<TextMeshProUGUI>().text = " TOP " + PlayerPrefs.GetInt("TopPoints", 0).ToString();

        if (restartGame)
            StartGame();
    }
    public void StartGame()
    {
        buttons.FirstOrDefault(x => x.name == "Play").gameObject.SetActive(false);
        mobilControls.SetActive(true);

        SpawnAnimal();
    }

    public void RestartGame()
    {
        LevelLoader.instance.LoadLevel(0);
    }
    public void ContineWatchVideoGame()
    {
        buttons.FirstOrDefault(x => x.name == "Restart").gameObject.SetActive(false);
        buttons.FirstOrDefault(x => x.name == "ContineWatchVideo").gameObject.SetActive(false);
        mobilControls.SetActive(true);

        PlayerController.instance.animator.SetBool("IsDeadOnTop", false);
        PlayerController.instance.animator.SetBool("IsDeadOnLeft", false);
        PlayerController.instance.animator.SetBool("IsAlive", true);

        isGameOver = false;

        GoogleMobileAdsScript.instance.ShowRewardBasedVideo();
    }

    public void SpawnAnimal()
    {
        if (twoIndex && spawnAnimaCount > 0)
        {
            spawnAnimaCount = 0;
            return;
        }
        else if (!twoIndex)
        {
            spawnAnimaCount = 0;
        }

        int indexSingleOrTwo = rnd.Next(0, 2);
        if (indexSingleOrTwo == 0)//single
        {
            twoIndex = false;
            int index = rnd.Next(0, 3);
            switch (index)
            {
                case 0:
                    SpawnLeftAnimal();
                    break;
                case 1:
                    SpawnMiddleAnimal();
                    break;
                case 2:
                    SpawRightAnimal();
                    break;
                default:
                    Debug.Log(index.ToString());
                    break;
            }
        }
        else if (indexSingleOrTwo == 1)//multi
        {
            twoIndex = true;
            int index = rnd.Next(0, 3);
            switch (index)
            {
                case 0:
                    SpawnLeftAnimal();
                    SpawRightAnimal();
                    break;
                case 1:
                    SpawnLeftAnimal();
                    SpawnMiddleAnimal();
                    break;
                case 2:
                    SpawRightAnimal();
                    SpawnMiddleAnimal();
                    break;
                default:
                    Debug.Log(index.ToString());
                    break;
            }
        }

        spawnAnimaCount++;
    }
    private void SpawnLeftAnimal()
    {
        GameObject animal = Instantiate(spawnAnimal);
        animal.GetComponent<AnimalController>().focus = goPointLeft.GetComponent<Interactable>();
        animal.transform.position = spawnerLeft.transform.position;
        animal.GetComponent<AnimalController>().spawnNextAnimal = true;
    }
    private void SpawnMiddleAnimal()
    {
        GameObject animal = Instantiate(spawnAnimal);
        animal.GetComponent<AnimalController>().focus = goPointMiddle.GetComponent<Interactable>();
        animal.transform.position = spawnerMiddle.transform.position;
        animal.GetComponent<AnimalController>().spawnNextAnimal = true;
    }
    private void SpawRightAnimal()
    {
        GameObject animal = Instantiate(spawnAnimal);
        animal.GetComponent<AnimalController>().focus = goPointRight.GetComponent<Interactable>();
        animal.transform.position = spawnerRight.transform.position;
        animal.GetComponent<AnimalController>().spawnNextAnimal = true;
    }

    public void CreateRandomPostionUpPoints()
    {
        GameObject _up = Instantiate(upPoints, pointArea.transform, true);
        int x = rnd.Next(-250, 250);
        int y = rnd.Next(-700, -100);
        _up.GetComponent<RectTransform>().localPosition = new Vector2(x, y);
        //_up.transform.position = new Vector3(x, y, 0);
    }
    public void UpdateToPoints()
    {
        points.GetComponent<TextMeshProUGUI>().text = " " + PlayerPrefs.GetInt("Points", 0).ToString();
        pointsShadow.GetComponent<TextMeshProUGUI>().text = " " + PlayerPrefs.GetInt("Points", 0).ToString();

        if (PlayerPrefs.GetInt("Points", 0) > PlayerPrefs.GetInt("TopPoints", 0))
        {
            PlayerPrefs.SetInt("TopPoints", PlayerPrefs.GetInt("Points", 0));

            topPoints.GetComponent<TextMeshProUGUI>().text = " TOP " + PlayerPrefs.GetInt("TopPoints", 0).ToString();
            topPointsShadow.GetComponent<TextMeshProUGUI>().text = " TOP " + PlayerPrefs.GetInt("TopPoints", 0).ToString();
        }
    }

    public void PressLeft()
    {
        PlayerController.instance.pressLeft = true;
    }
    public void PressRight()
    {
        PlayerController.instance.pressRight = true;
    }
}
