using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{
    private int box_number = 0;

    public float speed = 10f;

    private bool canMove = false;

    public Transform posToMove;

    public Transform posToStand;

    public GameObject vfxOnSuccess;

    private float min_X = -2.15f;

    private float max_X = 2.15f;

    private float min_Y = -4.85f;

    private float max_Y = 4.85f;

    public List<GameObject> boxes;

    public bool isOnStandPos;

    public bool canGoToStandPos = false;

    private void Awake()
    {
        foreach(GameObject box in boxes)
        {
            box.SetActive(false);
        }

        if (transform.position != posToStand.position)
        {
            isOnStandPos = false;
        }
    }

    public void PlusBox()
    {
        box_number += 1;

        boxes[box_number - 1].SetActive(true);

        if (box_number == 3)
        {
            canMove = true;

            //transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        }
    }

    private void FixedUpdate()
    {
        if (canGoToStandPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, posToStand.position, speed * Time.deltaTime);

            float distance = Vector2.Distance(transform.position, posToStand.position);
             
            if (distance <= 0.05f)
            {
                canGoToStandPos = false;

                isOnStandPos = true;
            }
        }

        if (canMove && isOnStandPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, posToMove.position, speed * Time.deltaTime);

            float distance = Vector2.Distance(transform.position, posToMove.position);

            if (distance <= 0.05f)
            {
                canMove = false;

                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
                GameObject explosion = Instantiate(vfxOnSuccess, transform.position, transform.rotation);
                Destroy(explosion, 1f);
                

                if (GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Count != 0) 
                {
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].SetDeliverToStandPos();
                }
                else
                {
                    GameManager.Instance.CheckLevelUp();
                }
                
                gameObject.SetActive(false);
            }
        }
    }


    private void CheckPos()
    {
        if (transform.position.x < min_X)
        {
            Vector3 moveDirX = new Vector3(min_X, transform.position.y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x > max_X)
        {
            Vector3 moveDirX = new Vector3(max_X, transform.position.y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.y < min_Y)
        {
            Vector3 moveDirX = new Vector3(transform.position.x, min_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.y > max_Y)
        {
            Vector3 moveDirX = new Vector3(transform.position.x, max_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x < min_X && transform.position.y < min_Y)
        {
            Vector3 moveDirX = new Vector3(min_X, min_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x < min_X && transform.position.y > max_Y)
        {
            Vector3 moveDirX = new Vector3(min_X, max_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x > max_X && transform.position.y > max_Y)
        {
            Vector3 moveDirX = new Vector3(max_X, max_Y, 0f);
            transform.position = moveDirX;
        }
        else if (transform.position.x > max_X && transform.position.y < min_Y)
        {
            Vector3 moveDirX = new Vector3(max_X, min_Y, 0f);
            transform.position = moveDirX;
        }
    }
}