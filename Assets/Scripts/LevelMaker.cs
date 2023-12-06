using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    [System.Serializable]
    public class Row
    {
        public ScriptableBrick Brick;
    }

    [System.Serializable]
    public class Column
    {
        public ScriptableBrick Brick;
    }

    [Range(0,8)]
    public List<Row> Rows;
    
    [Range(0,7)]
    public List<Column> Columns;
}
