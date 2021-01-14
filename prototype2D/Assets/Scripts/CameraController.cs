using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _playerPos;
    public float _speed = 5.0f;
    private Vector3 _cameraNewPos;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.Find("Player").transform;
        _cameraNewPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 camPosTemp = transform.position;

        if (Vector2.Distance(camPosTemp, _playerPos.position) > 4.0f)
        {
            _cameraNewPos.x = _playerPos.position.x;
            _cameraNewPos.y = _playerPos.position.y;

            transform.position = Vector3.MoveTowards(transform.position, _cameraNewPos, _speed * Time.deltaTime);
        }
    }
}
