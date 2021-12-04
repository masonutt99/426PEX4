/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.node;

import java.util.*;
import org.sablecc.sablecc.analysis.*;

public final class ASetBasic extends PBasic
{
    private PSet _set_;

    public ASetBasic ()
    {
    }

    public ASetBasic (
            PSet _set_
    )
    {
        setSet (_set_);
    }

    public Object clone()
    {
        return new ASetBasic (
            (PSet)cloneNode (_set_)
        );
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseASetBasic(this);
    }

    public PSet getSet ()
    {
        return _set_;
    }

    public void setSet (PSet node)
    {
        if(_set_ != null)
        {
            _set_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        _set_ = node;
    }

    public String toString()
    {
        return ""
            + toString (_set_)
        ;
    }

    void removeChild(Node child)
    {
        if ( _set_ == child )
        {
            _set_ = null;
            return;
        }
    }

    void replaceChild(Node oldChild, Node newChild)
    {
        if ( _set_ == oldChild )
        {
            setSet ((PSet) newChild);
            return;
        }
    }

}
