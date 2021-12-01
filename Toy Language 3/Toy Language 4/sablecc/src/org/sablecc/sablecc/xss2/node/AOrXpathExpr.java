/* This file was generated by SableCC (http://www.sablecc.org/). */

package org.sablecc.sablecc.xss2.node;

import java.util.*;
import org.sablecc.sablecc.xss2.analysis.*;

public final class AOrXpathExpr extends PXpathExpr
{
    private PXpathExpr _e1_;
    private PXpathExpr _e2_;

    public AOrXpathExpr ()
    {
    }

    public AOrXpathExpr (
            PXpathExpr _e1_,
            PXpathExpr _e2_
    )
    {
        setE1 (_e1_);
        setE2 (_e2_);
    }

    public Object clone()
    {
        return new AOrXpathExpr (
            (PXpathExpr)cloneNode (_e1_),
            (PXpathExpr)cloneNode (_e2_)
        );
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAOrXpathExpr(this);
    }

    public PXpathExpr getE1 ()
    {
        return _e1_;
    }

    public void setE1 (PXpathExpr node)
    {
        if(_e1_ != null)
        {
            _e1_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        _e1_ = node;
    }
    public PXpathExpr getE2 ()
    {
        return _e2_;
    }

    public void setE2 (PXpathExpr node)
    {
        if(_e2_ != null)
        {
            _e2_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        _e2_ = node;
    }

    public String toString()
    {
        return ""
            + toString (_e1_)
            + toString (_e2_)
        ;
    }

    void removeChild(Node child)
    {
        if ( _e1_ == child )
        {
            _e1_ = null;
            return;
        }
        if ( _e2_ == child )
        {
            _e2_ = null;
            return;
        }
    }

    void replaceChild(Node oldChild, Node newChild)
    {
        if ( _e1_ == oldChild )
        {
            setE1 ((PXpathExpr) newChild);
            return;
        }
        if ( _e2_ == oldChild )
        {
            setE2 ((PXpathExpr) newChild);
            return;
        }
    }

}
