using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed = 1f;
    private Vector3 start, end;
    void Start()
    {
        if(target != null){
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(target != null){
            float enemyMove = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, enemyMove);
        }
        if(transform.position == target.position){
            target.position = target.position == start ? end : start;
        }
    }
}
