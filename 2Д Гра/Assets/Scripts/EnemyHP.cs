using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public float HP = 100;

    if(Input.GetKeyDown(KeyCode.E))
{
	Fight2D.Action(punch1.position, punch1Radius, 8, 12, false);
}

}
}
