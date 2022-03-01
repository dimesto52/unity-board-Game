using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(cellLink))]
public class moveCell : MonoBehaviour
{
    public float speed = 2.0f;
    public bool update = true;
    public cellLink cell
    {
        get
        {
            return this.GetComponent<cellLink>();
        }
    }

    public bool lasmove = false;
    static public int hasmove = 0;

    static public bool canmove
    {
        get
        {
            return (hasmove == 0);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawLine(transform.position, cell.position, Color.yellow);

        if (Vector3.Distance(transform.position, cell.position) > 0.1f)
        {
            Vector3 dir = (cell.position - transform.position).normalized;
            transform.position = transform.position + dir * Time.deltaTime * speed;

            if (lasmove == false)
            {
                lasmove = true;
                hasmove += 1;
            }
        }
        else
        {
            transform.position = cell.position;

            if (lasmove == true)
            {
                lasmove = false;
                hasmove -= 1;

                if(update)
                    cell.board.SendMessage("killUpdate",cell.pos, SendMessageOptions.DontRequireReceiver);

                update = true;
            }

        }
    }
}
