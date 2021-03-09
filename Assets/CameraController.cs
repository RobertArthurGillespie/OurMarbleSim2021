using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(this.gameObject.transform.position.x - ball.gameObject.transform.position.x,
            this.gameObject.transform.position.y - ball.gameObject.transform.position.y,
            this.gameObject.transform.position.z - ball.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = ball.gameObject.transform.position + offset;

        float movement = Input.GetAxis("Mouse X") * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (!Mathf.Approximately(movement, 0))
            {
                this.gameObject.transform.RotateAround(ball.gameObject.transform.position, Vector3.up, movement * 100);
                offset = this.gameObject.transform.position - ball.gameObject.transform.position;
            }
        }

    }
}
