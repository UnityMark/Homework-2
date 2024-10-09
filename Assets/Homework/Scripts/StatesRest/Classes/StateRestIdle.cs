using UnityEngine;

public class StateRestIdle : IStateRest
{
    public Vector3 Rest()
    {
        return Vector3.zero;
    }
}
