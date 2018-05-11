using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rigid;
    private CircleCollider2D coll;

    private float x;
    private float y;

    [SerializeField]
    private ITrigger trigger;
    private DialogueManager dialogueManager;

    private Vector2 destination;
    private bool gotoDestination;

    public LayerMask layerMask;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (dialogueManager != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))//GetButtonDown("Jump"))
            {
                if (trigger != null)
                {
                    StopMoving();
                    trigger.Trigger();
                }
            }

            if (dialogueManager.dialogueRunning) return;
        }

        //if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        //{
        //    x = Input.GetAxis("Horizontal");
        //    y = Input.GetAxis("Vertical");
        //    gotoDestination = false;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 curserPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.CircleCast(transform.position, coll.radius, curserPos, Vector2.Distance(transform.position, Input.mousePosition), layerMask);
            destination = curserPos;//hit.point != Vector2.zero ? curserPos : hit.point;
            gotoDestination = true;
        }
        if (gotoDestination)
        {
            Vector3 direction = (Vector3)destination - transform.position;
            //Debug.Log("dir: " + direction);
            Debug.DrawLine(transform.position, destination, Color.red);
            Vector2 step = direction.magnitude > 1f ? direction.normalized : direction;
            x = step.x;
            y = step.y;
        }
        //Collider[] colliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(coll.offset.x, coll.offset.y), coll.radius);
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(x) > 0.1f)
        {
            rigid.AddForce(x * Vector3.right * Time.fixedDeltaTime * speed);
        }
        if (Mathf.Abs(y) > 0.1f)
        {
            rigid.AddForce(y * Vector3.up * Time.fixedDeltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //StopMoving();

        ITrigger tmp = other.GetComponent<ITrigger>();
        if (tmp != null) trigger = tmp;
        //Debug.Log("Entered trigger");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ITrigger tmp = other.GetComponent<ITrigger>();
        if (tmp != null && tmp == trigger) trigger = null;
        //Debug.Log("Left trigger");
    }

    void OnDrawGizmos()
    {
        coll = GetComponent<CircleCollider2D>();

        //if (gotoDestination)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(new Vector3(destination.x, destination.y), coll.radius);
        }

        Vector2 curserPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(curserPos, coll.radius);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + new Vector3(x, y), coll.radius);
    }

    private void StopMoving()
    {
        gotoDestination = false;
        x = 0;
        y = 0;
    }
}
