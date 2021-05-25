using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    /// <summary>
    /// Sub Class object UI panel displayable function.
    /// </summary>
    public virtual void OnEnter() 
    {

    }

    /// <summary>
    /// Sub Class object UI panel pause function, current UI panel froze.
    /// </summary>
    public virtual void OnPause()
    {

    }

    /// <summary>
    /// Sub Class object UI panel resume function, current UI panel re-active again.
    /// </summary>
    public virtual void OnResume()
    {

    }

    /// <summary>
    /// Sub Class object UI panel exit function, current UI panel close and inactive.
    /// </summary>
    public virtual void OnExit()
    {

    }

    private void OnDestroy()
    {
        //TODO
    }
}
