using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    CharacterController charCtrl;
    public bool Flag = false;
    public Vector3 m_maxPos;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        Flag = false;
        RaycastHit hit;

        Vector3 p1 = transform.position + charCtrl.center;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, charCtrl.height / 2, transform.forward, out hit, 10))
        {
            distanceToObstacle = hit.distance;
            m_maxPos = this.transform.position;
            Debug.Log(this.transform.position);
            Flag = true;
        }
    }
}
