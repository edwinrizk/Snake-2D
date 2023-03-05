using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.up;

    private List<Transform> _segments= new List<Transform>();
    
    public Transform segmmentPrefabs;

    public int initialSize = 0;
    public Text countText;

    private bool _right = true;
    private bool _left  = true;
    private bool _down  = true;
    private bool _up    = false;

    private int conpteur = 0;
    
    private void Start()
    {
        ResetState();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(_down)
            {
                _up=false;
                _direction = Vector2.up;
                _left = true;
                _right=true;

            }
            
        }else if(Input.GetKeyDown(KeyCode.S)) 
        {
            if(_up) 
            {
                _down = false;
                _direction = Vector2.down;
                _left=true;
                _right=true;
            }
            
        }else if(Input.GetKeyDown(KeyCode.Q))
        {   if(_right)
            {
                _left = false;
                _direction = Vector2.left;
                _down = true;
                _up= true;
               
            }
            
        }else if(Input.GetKeyDown(KeyCode.D)) 
        {
            if(_left)
            {
                _right= false;
                _direction = Vector2.right;
                _down = true;
                _up= true;
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
            0f
        );
    }

    private void Grow()
    {
        Transform segment= Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
  
        segment = Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        segment = Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        segment = Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        segment = Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        segment = Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        segment = Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        segment = Instantiate(this.segmmentPrefabs);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void ResetState()
    {
        for(int i =1;i<_segments.Count;i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmmentPrefabs));

        }
        this.transform.position = Vector3.zero;
        conpteur = 0;
        SetCountText ();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
           
            
            if(conpteur == 15) 
            {
                SceneManager.LoadScene(2);

            }
            conpteur+=1;
            SetCountText();

        }
        else if(other.tag=="Obstacle")
        {
            ResetState();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + conpteur.ToString();
    }
}
