using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;

        float vertical = Input.GetAxis("Vertical");
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        transform.position = position;
    }
}
