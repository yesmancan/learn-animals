using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimalMotor))]
public class AnimalController : MonoBehaviour
{
    public Interactable focus;
    public bool spawnNextAnimal = true;

    AnimalMotor motor;
    GameManager manager;
    SkyboxChanger skybox;

    void Start()
    {
        motor = transform.GetComponent<AnimalMotor>();
        manager = GameManager.instance;
        skybox = SkyboxChanger.instance;

        if (focus != null)
            SetFocus(focus);
    }

    // Update is called once per frame
    void Update()
    {
        CalcDistanceSpawnPointAndNewSpawnAnimal();
    }
    void CalcDistanceSpawnPointAndNewSpawnAnimal()
    {
        if (transform != null && transform.position.z > -30 && spawnNextAnimal)
        {
            manager.SpawnAnimal();
            spawnNextAnimal = false;
        }

        if (transform.position.z > 9)
        {
            Destroy(transform.gameObject);
            manager.allSpawnAnimaCount++;
            PlayerPrefs.SetInt("Points", manager.allSpawnAnimaCount);

            manager.UpdateToPoints();
            manager.CreateRandomPostionUpPoints();

            if (manager.allSpawnAnimaCount.ToString().Length == 1)
            {
                manager.animalRunSpeed = 15;
                skybox.ActiveSkyBoxIndex = 0;
            }
            else if (manager.allSpawnAnimaCount.ToString().Length == 2)
            {
                switch (manager.allSpawnAnimaCount)
                {
                    case 10:
                        manager.animalRunSpeed = 17;
                        skybox.ActiveSkyBoxIndex = 1;
                        break;
                    case 20:
                        manager.animalRunSpeed = 19;
                        skybox.ActiveSkyBoxIndex = 1;
                        break;
                    case 30:
                        manager.animalRunSpeed = 21;
                        skybox.ActiveSkyBoxIndex = 1;
                        break;
                    case 40:
                        manager.animalRunSpeed = 23;
                        skybox.ActiveSkyBoxIndex = 1;
                        break;
                    case 50:
                        manager.animalRunSpeed = 25;
                        skybox.ActiveSkyBoxIndex = 1;
                        break;
                    case 60:
                        manager.animalRunSpeed = 27;
                        skybox.ActiveSkyBoxIndex = 2;
                        break;
                    case 70:
                        manager.animalRunSpeed = 29;
                        skybox.ActiveSkyBoxIndex = 2;
                        break;
                    case 80:
                        manager.animalRunSpeed = 31;
                        skybox.ActiveSkyBoxIndex = 2;
                        break;
                    case 90:
                        manager.animalRunSpeed = 33;
                        skybox.ActiveSkyBoxIndex = 2;
                        break;
                }
            }
            else if (manager.allSpawnAnimaCount.ToString().Length > 2)
            {
                switch (manager.allSpawnAnimaCount)
                {
                    case 100:
                        manager.animalRunSpeed = 34;
                        skybox.ActiveSkyBoxIndex = 3;
                        break;
                    case 150:
                        manager.animalRunSpeed = 35;
                        skybox.ActiveSkyBoxIndex = 3;
                        break;
                    case 200:
                        manager.animalRunSpeed = 38;
                        skybox.ActiveSkyBoxIndex = 3;
                        break;
                    case 250:
                        manager.animalRunSpeed = 39;
                        skybox.ActiveSkyBoxIndex = 3;
                        break;
                    case 300:
                        manager.animalRunSpeed = 40;
                        skybox.ActiveSkyBoxIndex = 3;
                        break;
                    case 350:
                        manager.animalRunSpeed = 41;
                        skybox.ActiveSkyBoxIndex = 4;
                        break;
                    case 400:
                        manager.animalRunSpeed = 42;
                        skybox.ActiveSkyBoxIndex = 4;
                        break;
                    case 450:
                        manager.animalRunSpeed = 43;
                        skybox.ActiveSkyBoxIndex = 4;
                        break;
                    case 500:
                        manager.animalRunSpeed = 44;
                        skybox.ActiveSkyBoxIndex = 4;
                        break;
                    default:
                        manager.animalRunSpeed = 45;
                        skybox.ActiveSkyBoxIndex = 4;
                        break;
                }
            }
        }
    }
    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        motor.FollowTarget(focus);
    }
}
