using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquette : MonoBehaviour
{
    [SerializeField] private Camera activeCamera;
    private float screenRatio;
    private float minXPaddle;
    private float maxXPaddle;
    private BoxCollider2D paddleCollider;
    private float worldUnitWidth;

    // Start is called before the first frame update
    void Start()
    {
        paddleCollider = GetComponent<BoxCollider2D>();
        screenRatio = (float)Screen.width / Screen.height;
        worldUnitWidth = activeCamera.orthographicSize * 2f * screenRatio;
        minXPaddle = activeCamera.transform.position.x - (worldUnitWidth / 2f) + (paddleCollider.size.x / 2f);
        maxXPaddle = activeCamera.transform.position.x + (worldUnitWidth / 2f) - (paddleCollider.size.x / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXPosition = (Input.mousePosition.x / Screen.width) * worldUnitWidth;
        Vector2 paddlePosition = new Vector2(Mathf.Clamp(mouseXPosition, minXPaddle, maxXPaddle), paddleCollider.transform.position.y);
        paddleCollider.transform.position = paddlePosition;
    }
}
