using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    [Tooltip("Starting point")][SerializeField] Transform startPoint;
    [Tooltip("End point")][SerializeField] Transform endPoint;
    [Tooltip("Percentage of the distance beetween start and end that will reamin intact")][SerializeField][Range(0f,1f)] float easingThreshold;
    [Tooltip("Inverts which anchor affects start and end")][SerializeField] bool invertedEases;
    [Tooltip("Makes line look like a sawtooth")][SerializeField] bool diagonal;

    LineRenderer line;


    Vector3 easerIn,easerOut,anchor1,anchor2,anchor1Position,anchor2Position;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 4;

    }

    // Update is called once per frame
    void Update()
    {
        //Create a holder for calculated Positions
        Vector3[] positions = new Vector3[4];

        //Flag for inverted easing anchors 
        if (!invertedEases)
        {
            anchor1Position = new Vector3(endPoint.position.x, startPoint.position.y, endPoint.position.z);
            anchor1 = (anchor1Position - startPoint.position);
            anchor2Position = new Vector3(startPoint.position.x, endPoint.position.y, startPoint.position.z);
            anchor2 = (endPoint.position - anchor2Position);
        }
        else
        {
            anchor1Position = new Vector3(startPoint.position.x, endPoint.position.y, startPoint.position.z);
            anchor1 = (anchor1Position - startPoint.position);
            anchor2Position = new Vector3(endPoint.position.x, startPoint.position.y, endPoint.position.z);
            anchor2 = (endPoint.position - anchor2Position);
        }

        //Define "easing" points for holder
        easerIn = startPoint.position + anchor1 * easingThreshold;
        easerOut = endPoint.position - anchor2 * easingThreshold;

        //Assigning first point to holder
        positions[0] = startPoint.position;
        //Flag for diagonal sawteethed line
        //Also assigning middle points to holder
        if (!diagonal)
        {
            positions[1] = easerIn;
            positions[2] = easerOut;
        }
        else
        {
            positions[1] = easerOut;
            positions[2] = easerIn;
        }
        //assign last point to holder
        positions[3] = endPoint.position;

        //updating vertexcount of line
        line.positionCount = positions.Length;

        //assign holder positions to line renderer
        line.SetPositions(positions);
    }


    //debug for visualization
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float sphereRadius = 0.1f;
        Gizmos.DrawWireSphere(easerIn, sphereRadius);
        Gizmos.DrawSphere(easerIn, sphereRadius / 5f);
        Gizmos.color = new Color(66f/255f, 245f/255f, 155f/255f);
        Gizmos.DrawWireSphere(anchor1Position, sphereRadius);
        Gizmos.DrawLine(startPoint.position, startPoint.position + (anchor1Position - startPoint.position));
        Gizmos.color = new Color(245f/255f, 66f/255f, 141f/255f);
        Gizmos.DrawLine(endPoint.position,endPoint.position + (anchor2Position - endPoint.position));
        Gizmos.DrawWireSphere(anchor2Position, sphereRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(easerOut, sphereRadius);
        Gizmos.DrawSphere(easerOut, sphereRadius / 5f);
    }
#endif
}
