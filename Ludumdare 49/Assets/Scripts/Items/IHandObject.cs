using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandObject
{
    GameObject GameObject { get; set; }
    string ObjectName   { get; set; }
    bool Active { get; set; }
    IFixableThing FixableThing { get; set; }

    void UseObject(bool field);  
}
