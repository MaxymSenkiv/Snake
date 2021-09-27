﻿using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement3d : MonoBehaviour
{
    [SerializeField] private int _initialSize = 4;

    private Vector3 _direction = Vector3.right;

    [SerializeField] private Transform _segmentPrefab;

    private List<Transform> _segments = new List<Transform>();

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (this._direction.x != 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector3.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector3.down;
            }
        }

        if (this._direction.y != 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector3.left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector3.right;
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this._segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this._initialSize; i++)
        {
            _segments.Add(Instantiate(this._segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
        else if (collision.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
