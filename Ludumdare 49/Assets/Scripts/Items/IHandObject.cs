using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandObject
{
    string ObjectName   { get; set; }
    bool Active { get; set; }
    IFixableThing FixableThing { get; set; }

    void UseObject(bool field);

}
