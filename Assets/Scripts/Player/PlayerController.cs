using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Vector2 input;
    Direction currentDir;
    bool isMoving;
    Vector3 startPos;
    Vector3 endPos;
    float t;

    public float walkSpeed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isMoving)
        {
            input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Mathf.Abs(input.x) >Mathf.Abs(input.y) )
            {
                input.y = 0;
            }else
            {
                input.x = 0;
            }
            if (input != Vector2.zero)
            {
                StartCoroutine(Move(transform));
            }
        }
	}

    public IEnumerator Move(Transform entity)
    {
        isMoving = true;
        startPos = entity.position;
        t = 0f;
        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);
        while(t < 1f)
        {
            t += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, t);
        }
        isMoving = false;
        yield return 0;
    }
}

enum Direction
{
    North,
    East,
    South,
    West
}
