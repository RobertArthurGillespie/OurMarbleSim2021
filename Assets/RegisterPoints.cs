using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPoints : MonoBehaviour
{
    [SerializeField]
    BallController playerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("player has increased their points");
        playerStats.hitCount += 1;
    }

}
