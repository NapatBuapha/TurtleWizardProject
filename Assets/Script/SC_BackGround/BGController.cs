using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] private Parallax[] bgs;
    PlayerStateManager player;
    Transform cam;
    [SerializeField] private GameObject hell, forest, cave;
    [SerializeField] private GameObject currentScene;
    [SerializeField] private Animator blackScene;


    void Start()
    {
        cam = Camera.main.transform;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>();

        currentScene = hell;
        GetAllBGLayer(currentScene);
    }
    void GetAllBGLayer(GameObject groupHead)
    {
        HideAllLayer();
        groupHead.SetActive(true);
        bgs = groupHead.GetComponentsInChildren<Parallax>();
    }

    void HideAllLayer()
    {
        hell.SetActive(false);
        forest.SetActive(false);
        cave.SetActive(false);
    }

    void Update()
    {
        if (player.isRunning)
        {
            for (int i = 0; i < bgs.Length; i++)
            {
                float multiplier = 1;
                multiplier /= i + 1;
                bgs[i].speed = player.speed * multiplier * 0.05f;
            }
        }
        else
        {
            for (int i = 0; i < bgs.Length; i++)
            {
                bgs[i].speed = 0;
            }
        }

        transform.position = new Vector2(cam.position.x, cam.position.y);

    }

    public IEnumerator ChangeIntoScene(int levelNum)
    {
        switch (levelNum)
        {
            case 1:
                currentScene = hell;
                break;
            case 2:
                currentScene = forest;
                break;
            case 3:
                currentScene = cave;
                break;
            default:
                Debug.Log("Error");
                break;
        }

        blackScene.SetTrigger("ChangeScene");
        yield return new WaitForSeconds(2);
        GetAllBGLayer(currentScene);
    }
}
