using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float distance = 0.1f;
    [SerializeField] private IEnumerator ActualEnumerator;
    [SerializeField] private RaycastHit hitforward;
    [SerializeField] private RaycastHit hitleft;
    [SerializeField] private RaycastHit hitright;
    [SerializeField] private RaycastHit hitback;
    [SerializeField] public List<GameObject> bomblist;
    [SerializeField] private GameObject bomb;
    [SerializeField] public int cantBombs=1;
    [SerializeField] public int lives = 2;
    void Start()
    {
        
    }

    bool rayCastForward()
    {
        
        Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hitforward, distance);
        if (hitforward.transform == null)
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

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))&&bomblist.Count<cantBombs)
        {
            cantBombs--;
            GetComponent<Animator>().Play("Attack");
            bomblist.Add(Instantiate(bomb));
            bomblist[0].transform.position = transform.position;
            StartCoroutine("ExploteBomb");
        }
    }

    IEnumerator ExploteBomb()
    {
        yield return new WaitForSeconds(2);
        Destroy(bomblist[0]);
        cantBombs++;
        bomblist.Clear();
        yield return null;
    }
}
