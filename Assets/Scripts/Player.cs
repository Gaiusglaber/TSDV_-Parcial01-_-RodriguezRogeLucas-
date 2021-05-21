using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private IEnumerator ActualEnumerator;
    [SerializeField] private RaycastHit hitforward;
    [SerializeField] public List<GameObject> bomblist;
    [SerializeField] private GameObject bomb;
    private int cantBombs=1;
    [SerializeField] public int currentbomb = 0;
    [SerializeField] public int lives = 2;
    [SerializeField] public bool powerUp = false;
    [SerializeField] public Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    public void PowerBombs()
    {
        cantBombs++;
    }
    bool rayCastForward()
    {
        
        Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hitforward, 1f);
        if (hitforward.transform != null)
        {
            if (hitforward.transform.gameObject.layer == LayerMask.NameToLayer("Wall") ||
                hitforward.transform.gameObject.layer == LayerMask.NameToLayer("Box"))
            {
                return false;
            }
        }
        return true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameover)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();
            if (rayCastForward())
            {
                transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
            }

            if (movementDirection != Vector3.zero)
            {
                if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    GetComponent<Animator>().Play("Walk");
                }
                transform.forward = movementDirection;
            }
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && currentbomb < cantBombs)
            {
                currentbomb++;
                GetComponent<Animator>().Play("Attack");
                bomblist.Add(Instantiate(bomb,transform.position,Quaternion.identity));
                StartCoroutine("ExploteBomb");
            }
        }
    }

    IEnumerator ExploteBomb()
    {
        yield return new WaitForSeconds(2);
        Destroy(bomblist[currentbomb-1]);
        bomblist.Remove(bomblist[currentbomb - 1]);
        currentbomb--;
        yield return null;
    }

    public void RespawnPlayer()
    {
        transform.position = startPosition;
    }
}
