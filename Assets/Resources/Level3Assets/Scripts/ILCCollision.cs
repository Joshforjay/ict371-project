using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILCCollision : MonoBehaviour
{
    Score score = new Score();
    CellModeChange modeCheck = new CellModeChange();
    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.name == "ILC(Clone)" && CellModeChange.modeSwitch)
        {
            Destroy(collide.gameObject);
            Score.infectedCellsLeft--;
        }

    }
}
