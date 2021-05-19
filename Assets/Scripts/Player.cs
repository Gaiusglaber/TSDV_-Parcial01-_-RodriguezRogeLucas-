using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float distance = 2.5f;
    [SerializeField] private IEnumerator ActualEnumerator;
    [SerializeField] private RaycastHit hitforward;
    [SerializeField] private RaycastHit hitleft;
    [SerializeField] private RaycastHit hitright;
    [SerializeField] private RaycastHit hitback;
    [SerializeField] public List<GameObject> bomblist;
    [SerializeField] private GameObject bomb;
    [SerializeField] public int lives = 2;
    void Start()
    {
        
    }

    bool rayCastForward()
    {
        Physics.Raycast(this.transform.position, this.transform.forward, out hitforward, distance);
        if (hitforward.transform != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool rayCastBack()
    {
        Physics.Raycast(this.transform.position, -this.transform.forward, out hitback, distance);
        if (hitback.transform != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool rayCastLeft()
    {
        Physics.Raycast(this.transform.position, this.transform.right, out hitleft, distance);
        if (hitleft.transform != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool rayCastRight()
    {
        Physics.Raycast(this.transform.position, -this.transform.right, out hitright, distance);
        if (hitright.transform != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector3 actualposition = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        if (!rayCastForward() && verticalInput <= 1)
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

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))&&bomblist.Count==0)
        {
            GetComponent<Animator>().Play("Attack");
            bomblist.Add(Instantiate(bomb,this.transform.position,Quaternion.identity));
            StartCoroutine("ExploteBomb");
        }

    }

    IEnumerator ExploteBomb()
    {
        yield return new WaitForSeconds(2);
        Destroy(bomblist[0]);
        bomblist.Clear();
        yield return null;
    }
}
