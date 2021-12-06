/* This file was generated by SableCC (http://www.sablecc.org/). */

using System;
using System.Collections;
using System.Text;

using  CS426.analysis;

namespace CS426.node {


public sealed class TInt : Token
{
    public TInt(string text)
    {
        Text = text;
    }

    public TInt(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TInt(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTInt(this);
    }
}

public sealed class TString : Token
{
    public TString(string text)
    {
        Text = text;
    }

    public TString(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TString(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTString(this);
    }
}

public sealed class TFloat : Token
{
    public TFloat(string text)
    {
        Text = text;
    }

    public TFloat(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TFloat(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTFloat(this);
    }
}

public sealed class TCommentLine : Token
{
    public TCommentLine(string text)
    {
        Text = text;
    }

    public TCommentLine(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TCommentLine(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTCommentLine(this);
    }
}

public sealed class TCommentMultiline : Token
{
    public TCommentMultiline(string text)
    {
        Text = text;
    }

    public TCommentMultiline(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TCommentMultiline(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTCommentMultiline(this);
    }
}

public sealed class TEol : Token
{
    public TEol(string text)
    {
        Text = text;
    }

    public TEol(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TEol(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTEol(this);
    }
}

public sealed class TAssign : Token
{
    public TAssign(string text)
    {
        Text = text;
    }

    public TAssign(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TAssign(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTAssign(this);
    }
}

public sealed class TPlus : Token
{
    public TPlus(string text)
    {
        Text = text;
    }

    public TPlus(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TPlus(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTPlus(this);
    }
}

public sealed class TMult : Token
{
    public TMult(string text)
    {
        Text = text;
    }

    public TMult(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMult(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMult(this);
    }
}

public sealed class TMinus : Token
{
    public TMinus(string text)
    {
        Text = text;
    }

    public TMinus(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMinus(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMinus(this);
    }
}

public sealed class TDiv : Token
{
    public TDiv(string text)
    {
        Text = text;
    }

    public TDiv(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TDiv(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTDiv(this);
    }
}

public sealed class TLeftCurly : Token
{
    public TLeftCurly(string text)
    {
        Text = text;
    }

    public TLeftCurly(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLeftCurly(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLeftCurly(this);
    }
}

public sealed class TRightCurly : Token
{
    public TRightCurly(string text)
    {
        Text = text;
    }

    public TRightCurly(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TRightCurly(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTRightCurly(this);
    }
}

public sealed class TLeftParenthesis : Token
{
    public TLeftParenthesis(string text)
    {
        Text = text;
    }

    public TLeftParenthesis(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLeftParenthesis(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLeftParenthesis(this);
    }
}

public sealed class TRightParenthesis : Token
{
    public TRightParenthesis(string text)
    {
        Text = text;
    }

    public TRightParenthesis(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TRightParenthesis(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTRightParenthesis(this);
    }
}

public sealed class TAnd : Token
{
    public TAnd(string text)
    {
        Text = text;
    }

    public TAnd(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TAnd(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTAnd(this);
    }
}

public sealed class TOr : Token
{
    public TOr(string text)
    {
        Text = text;
    }

    public TOr(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TOr(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTOr(this);
    }
}

public sealed class TNot : Token
{
    public TNot(string text)
    {
        Text = text;
    }

    public TNot(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TNot(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTNot(this);
    }
}

public sealed class TEquivalent : Token
{
    public TEquivalent(string text)
    {
        Text = text;
    }

    public TEquivalent(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TEquivalent(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTEquivalent(this);
    }
}

public sealed class TNotEquivalent : Token
{
    public TNotEquivalent(string text)
    {
        Text = text;
    }

    public TNotEquivalent(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TNotEquivalent(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTNotEquivalent(this);
    }
}

public sealed class TLessThan : Token
{
    public TLessThan(string text)
    {
        Text = text;
    }

    public TLessThan(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLessThan(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLessThan(this);
    }
}

public sealed class TGreaterThan : Token
{
    public TGreaterThan(string text)
    {
        Text = text;
    }

    public TGreaterThan(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TGreaterThan(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTGreaterThan(this);
    }
}

public sealed class TGreaterequal : Token
{
    public TGreaterequal(string text)
    {
        Text = text;
    }

    public TGreaterequal(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TGreaterequal(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTGreaterequal(this);
    }
}

public sealed class TLessequal : Token
{
    public TLessequal(string text)
    {
        Text = text;
    }

    public TLessequal(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLessequal(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLessequal(this);
    }
}

public sealed class TWhile : Token
{
    public TWhile(string text)
    {
        Text = text;
    }

    public TWhile(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TWhile(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTWhile(this);
    }
}

public sealed class TIf : Token
{
    public TIf(string text)
    {
        Text = text;
    }

    public TIf(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TIf(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTIf(this);
    }
}

public sealed class TElse : Token
{
    public TElse(string text)
    {
        Text = text;
    }

    public TElse(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TElse(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTElse(this);
    }
}

public sealed class TConst : Token
{
    public TConst(string text)
    {
        Text = text;
    }

    public TConst(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TConst(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTConst(this);
    }
}

public sealed class TDelimiter : Token
{
    public TDelimiter(string text)
    {
        Text = text;
    }

    public TDelimiter(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TDelimiter(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTDelimiter(this);
    }
}

public sealed class TDef : Token
{
    public TDef(string text)
    {
        Text = text;
    }

    public TDef(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TDef(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTDef(this);
    }
}

public sealed class TMain : Token
{
    public TMain(string text)
    {
        Text = text;
    }

    public TMain(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMain(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMain(this);
    }
}

public sealed class TId : Token
{
    public TId(string text)
    {
        Text = text;
    }

    public TId(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TId(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTId(this);
    }
}

public sealed class TBlank : Token
{
    public TBlank(string text)
    {
        Text = text;
    }

    public TBlank(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TBlank(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTBlank(this);
    }
}


public abstract class Token : Node
{
    private string text;
    private int line;
    private int pos;

    public virtual string Text
    {
      get { return text; }
      set { text = value; }
    }

    public int Line
    {
      get { return line; }
      set { line = value; }
    }

    public int Pos
    {
      get { return pos; }
      set { pos = value; }
    }

    public override string ToString()
    {
        return text + " ";
    }

    internal override void RemoveChild(Node child)
    {
    }

    internal override void ReplaceChild(Node oldChild, Node newChild)
    {
    }
}

public sealed class EOF : Token
{
    public EOF()
    {
        Text = "";
    }

    public EOF(int line, int pos)
    {
        Text = "";
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
        return new EOF(Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseEOF(this);
    }
}
}
