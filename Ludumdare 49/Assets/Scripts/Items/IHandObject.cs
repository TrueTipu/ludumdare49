using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandObject
{
    GameObject GameObject { get; set; }
    string ObjectName   { get; set; }
    bool Active { get; set; }
    Reactor Reactor { get; set; }
    Slime Slime { get; set; }

    void UseObject(bool field);  
}
