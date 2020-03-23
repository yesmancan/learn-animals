using UnityEngine;

public class AnimalMotor : MonoBehaviour
{
    Transform target;
    GameManager manager;
    void Start()
    {
        manager = GameManager.instance;
    }
    void Update()
    {
        if (target != null && !manager.isGameOver)
        {
            transform.Translate(0f, 0f, manager.animalRunSpeed * Time.deltaTime);
        }
    }
    public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.transform;
    }
    public void StopFollowingTarget()
    {
        target = null;
    }
}
