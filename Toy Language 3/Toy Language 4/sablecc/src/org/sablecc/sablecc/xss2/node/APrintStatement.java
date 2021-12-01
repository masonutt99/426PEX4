/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.xss2.node;

import java.util.*;
import org.sablecc.sablecc.xss2.analysis.*;

public final class APrintStatement extends PStatement
{
    private PExpr _expr_;

    public APrintStatement ()
    {
    }

    public APrintStatement (
            PExpr _expr_
    )
    {
        setExpr (_expr_);
    }

    public Object clone()
    {
        return new APrintStatement (
            (PExpr)cloneNode (_expr_)
        );
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAPrintStatement(this);
    }

    public PExpr getExpr ()
    {
        return _expr_;
    }

    public void setExpr (PExpr node)
    {
        if(_expr_ != null)
        {
            _expr_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        _expr_ = node;
    }

    public String toString()
    {
        return ""
            + toString (_expr_)
        ;
    }

    void removeChild(Node child)
    {
        if ( _expr_ == child )
        {
            _expr_ = null;
            return;
        }
    }

    void replaceChild(Node oldChild, Node newChild)
    {
        if ( _expr_ == oldChild )
        {
            setExpr ((PExpr) newChild);
            return;
        }
    }

}