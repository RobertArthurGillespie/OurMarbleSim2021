using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField]
    GameObject camera;
    [SerializeField]
    float force;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    UnityEvent CorrectObjectCollision;

    public int hitCount;
    public string PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }

    public IEnumerator Movement()
    {
        while (true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (vertical > 0)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(camera.gameObject.transform.forward * force);
            }
            if (horizontal > 0)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(camera.gameObject.transform.right * force);
            }
            if (vertical < 0)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce((-1) * camera.gameObject.transform.forward * force);
            }
            if (horizontal < 0)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce((-1) * camera.gameObject.transform.right * force);
            }
            yield return null;
        }
    }

    public void WorkerThreadMethod()
    {
        int i = 0;
        while (i < 100)
        {
            Debug.Log("i is: " + i);
            i += 1;
        }
    }
    bool stopWorking = false;
    bool stopWorking2 = false;
    public IEnumerator WorkerMethod()
    {
        int i = 0;
        int i2 = 0;
        while (true)
        {
            if (stopWorking)
            {
                break;
            }
            Debug.Log("i is: " + i);
            i += 1;
            yield return null;
        }
        while (true)
        {
            if (stopWorking2)
            {
                break;
            }
            Debug.Log("i2 is: " + i2);
            i2 += 1;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            /*ThreadStart workerThreadRef = new ThreadStart(WorkerThreadMethod);
            Thread workerThread = new Thread(workerThreadRef);
            workerThread.Start();*/
            StartCoroutine(WorkerMethod());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            stopWorking = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            stopWorking2 = true;
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (gameManager.currentChapter != null)
        {
            if (collision.gameObject.name == gameManager.currentChapter.CorrectObjectName)
            {
                CorrectObjectCollision.Invoke();
            }
        }
    }
}
