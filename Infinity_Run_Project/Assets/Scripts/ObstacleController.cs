using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody2D obstacleRigidbody;

    public GameConfigurator config;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        obstacleRigidbody.velocity = new Vector2(-config.speed, 0f);
    }
}
