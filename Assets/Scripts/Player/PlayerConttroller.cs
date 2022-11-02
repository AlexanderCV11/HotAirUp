using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConttroller : MonoBehaviour
{
    public float minX;
    public float movXForce;
    public float horizontalSpeed;
    public float upVelocity;
    public bool escudo = false;
    public Rigidbody Ply;
    public ParticleSystem particle;

    void Start()
    {
        Ply = GetComponent<Rigidbody>();
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalSpeed = Input.GetAxis("Horizontal") * movXForce;
        Ply.velocity = new Vector3(Ply.velocity.x, upVelocity, 0f);
        if (transform.position.x <= -minX)
        {
            transform.position = new Vector3(-minX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        
    }

    private void FixedUpdate()
    {
#if UNITY_STANDLONE || UNITY_WEBPLAYER || UNITY_EDITOR
        horizontalSpeed = Input.GetAxis("Horizontal") * movXForce;
        if (Input.GetMouseButton(0))
        {
            horizontalSpeed = MovPlayer(Input.mousePosition);
        }
#elif UNITY_IOS || UNITY_ANDROID
    if (Input.touchCount > 0)
	{
        Touch touch = Input.touches[0];
        horizontalSpeed = MovPlayer(touch.position);
	}
#endif
        Ply.velocity = new Vector3(horizontalSpeed, Ply.velocity.y, 0f);
    }

    private float MovPlayer(Vector3 pixelPos)
    {
        var worldPos = Camera.main.ScreenToViewportPoint(pixelPos);
        float xMove = 0;

        if (worldPos.x < 0.5f)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }
        return xMove * movXForce;
    }
}
