using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;
    public PlayerController()
    {
        instance = this;
    }
    #endregion

    public GameObject player;

    public Vector3 playergoMiddle;
    public Vector3 playergoLeft;
    public Vector3 playergoRight;

    public GameManager manager;
    public Animator animator;

    public bool pressLeft = false;
    public bool pressRight = false;
    public void Start()
    {
        manager = GameManager.instance;
        animator = transform.GetComponentInChildren<Animator>();

        animator.SetBool("IsDeadOnTop", false);
        animator.SetBool("IsDeadOnLeft", false);
        animator.SetBool("IsAlive", true);
    }
    void Update()
    {
        #region Move Controller
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || pressLeft) && player.transform.position == playergoMiddle && !manager.isGameOver)
        {
            player.transform.position = playergoLeft;
            pressRight = false;
            pressLeft = false;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || pressLeft) && player.transform.position == playergoRight && !manager.isGameOver)
        {
            player.transform.position = playergoMiddle;
            pressRight = false;
            pressLeft = false;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || pressRight) && player.transform.position == playergoMiddle && !manager.isGameOver)
        {
            player.transform.position = playergoRight;
            pressRight = false;
            pressLeft = false;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || pressRight) && player.transform.position == playergoLeft && !manager.isGameOver)
        {
            player.transform.position = playergoMiddle;
            pressRight = false;
            pressLeft = false;
        }

   
        #endregion
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            GameObject enemy = collision.collider.gameObject.transform.parent.parent.gameObject as GameObject;
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 1f);

            animator.SetBool("IsDeadOnTop", true);
            animator.SetBool("IsDeadOnLeft", false);
            animator.SetBool("IsAlive", false);

            manager.mobilControls.SetActive(false);
            manager.isGameOver = true;
            manager.buttons.FirstOrDefault(x => x.name == "Restart").gameObject.SetActive(true);
            manager.buttons.FirstOrDefault(x => x.name == "ContineWatchVideo").gameObject.SetActive(true);
        }
    }
}
