/* This file was generated by SableCC (http://www.sablecc.org/). */

using System;
using System.Collections;
using System.Text;
using System.IO;
using CS426.node;

namespace CS426.lexer {

internal class PushbackReader {
  private TextReader reader;
  private Stack stack = new Stack ();


  internal PushbackReader (TextReader reader)
  {
    this.reader = reader;
  }

  internal int Peek ()
  {
    if ( stack.Count > 0 ) return (int)stack.Peek();
    return reader.Peek();
  }

  internal int Read ()
  {
    if ( stack.Count > 0 ) return (int)stack.Pop();
    return reader.Read();
  }

  internal void Unread (int v)
  {
    stack.Push (v);
  }
}

public class LexerException : ApplicationException
{
    public LexerException(String message) : base (message)
    {
    }
}

public class Lexer
{
    protected Token token;
    protected State currentState = State.INITIAL;

    private PushbackReader input;
    private int line;
    private int pos;
    private bool cr;
    private bool eof;
    private StringBuilder text = new StringBuilder();

    protected virtual void Filter()
    {
    }

    public Lexer(TextReader input)
    {
        this.input = new PushbackReader(input);
    }

    public virtual Token Peek()
    {
        while(token == null)
        {
            token = GetToken();
            Filter();
        }

        return token;
    }

    public virtual Token Next()
    {
        while(token == null)
        {
            token = GetToken();
            Filter();
        }

        Token result = token;
        token = null;
        return result;
    }

    protected virtual Token GetToken()
    {
        int dfa_state = 0;

        int start_pos = pos;
        int start_line = line;

        int accept_state = -1;
        int accept_token = -1;
        int accept_length = -1;
        int accept_pos = -1;
        int accept_line = -1;

        int[][][] gotoTable = Lexer.gotoTable[currentState.id()];
        int[] accept = Lexer.accept[currentState.id()];
        text.Length = 0;

        while(true)
        {
            int c = GetChar();

            if(c != -1)
            {
                switch(c)
                {
                case 10:
                    if(cr)
                    {
                        cr = false;
                    }
                    else
                    {
                        line++;
                        pos = 0;
                    }
                    break;
                case 13:
                    line++;
                    pos = 0;
                    cr = true;
                    break;
                default:
                    pos++;
                    cr = false;
                    break;
                };

                text.Append((char) c);
                do
                {
                    int oldState = (dfa_state < -1) ? (-2 -dfa_state) : dfa_state;

                    dfa_state = -1;

                    int[][] tmp1 =  gotoTable[oldState];
                    int low = 0;
                    int high = tmp1.Length - 1;

                    while(low <= high)
                    {
                        int middle = (low + high) / 2;
                        int[] tmp2 = tmp1[middle];

                        if(c < tmp2[0])
                        {
                            high = middle - 1;
                        }
                        else if(c > tmp2[1])
                        {
                            low = middle + 1;
                        }
                        else
                        {
                            dfa_state = tmp2[2];
                            break;
                        }
                    }
                }while(dfa_state < -1);
            }
            else
            {
                dfa_state = -1;
            }

            if(dfa_state >= 0)
            {
                if(accept[dfa_state] != -1)
                {
                    accept_state = dfa_state;
                    accept_token = accept[dfa_state];
                    accept_length = text.Length;
                    accept_pos = pos;
                    accept_line = line;
                }
            }
            else
            {
                if(accept_state != -1)
                {
                    switch(accept_token)
                    {
                    case 0:
                        {
                            Token token = New0(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 1:
                        {
                            Token token = New1(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 2:
                        {
                            Token token = New2(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 3:
                        {
                            Token token = New3(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 4:
                        {
                            Token token = New4(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 5:
                        {
                            Token token = New5(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 6:
                        {
                            Token token = New6(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 7:
                        {
                            Token token = New7(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 8:
                        {
                            Token token = New8(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 9:
                        {
                            Token token = New9(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 10:
                        {
                            Token token = New10(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 11:
                        {
                            Token token = New11(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 12:
                        {
                            Token token = New12(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 13:
                        {
                            Token token = New13(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 14:
                        {
                            Token token = New14(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 15:
                        {
                            Token token = New15(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 16:
                        {
                            Token token = New16(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 17:
                        {
                            Token token = New17(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    }
                }
                else
                {
                    if(text.Length > 0)
                    {
                        throw new LexerException(
                            "[" + (start_line + 1) + "," + (start_pos + 1) + "]" +
                            " Unknown token: " + text);
                    }
                    else
                    {
                        EOF token = new EOF(
                            start_line + 1,
                            start_pos + 1);
                        return token;
                    }
                }
            }
        }
    }

    private Token New0(String text, int line, int pos) { return new TAssign(text, line, pos); }
    private Token New1(String text, int line, int pos) { return new TPlus(text, line, pos); }
    private Token New2(String text, int line, int pos) { return new TSub(text, line, pos); }
    private Token New3(String text, int line, int pos) { return new TMult(text, line, pos); }
    private Token New4(String text, int line, int pos) { return new TEol(text, line, pos); }
    private Token New5(String text, int line, int pos) { return new TLeftParenthesis(text, line, pos); }
    private Token New6(String text, int line, int pos) { return new TRightParenthesis(text, line, pos); }
    private Token New7(String text, int line, int pos) { return new TLeftCurly(text, line, pos); }
    private Token New8(String text, int line, int pos) { return new TRightCurly(text, line, pos); }
    private Token New9(String text, int line, int pos) { return new TComma(text, line, pos); }
    private Token New10(String text, int line, int pos) { return new TMainDef(text, line, pos); }
    private Token New11(String text, int line, int pos) { return new TFunctionDef(text, line, pos); }
    private Token New12(String text, int line, int pos) { return new TKeywordIf(text, line, pos); }
    private Token New13(String text, int line, int pos) { return new TId(text, line, pos); }
    private Token New14(String text, int line, int pos) { return new TComment(text, line, pos); }
    private Token New15(String text, int line, int pos) { return new TInteger(text, line, pos); }
    private Token New16(String text, int line, int pos) { return new TString(text, line, pos); }
    private Token New17(String text, int line, int pos) { return new TBlank(text, line, pos); }

    private int GetChar()
    {
        if(eof)
        {
            return -1;
        }

        int result = input.Read();

        if(result == -1)
        {
            eof = true;
        }

        return result;
    }

    private void PushBack(int acceptLength)
    {
        int length = text.Length;
        for(int i = length - 1; i >= acceptLength; i--)
        {
            eof = false;

            input.Unread(text[i]);
        }
    }


    protected virtual void Unread(Token token)
    {
        String text = token.Text;
        int length = text.Length;

        for(int i = length - 1; i >= 0; i--)
        {
            eof = false;

            input.Unread(text[i]);
        }

        pos = token.Pos - 1;
        line = token.Line - 1;
    }

    private string GetText(int acceptLength)
    {
        StringBuilder s = new StringBuilder(acceptLength);
        for(int i = 0; i < acceptLength; i++)
        {
            s.Append(text[i]);
        }

        return s.ToString();
    }

    private static int[][][][] gotoTable = {
      new int[][][] {
        new int[][] {
          new int[] {9, 9, 1},
          new int[] {10, 10, 2},
          new int[] {13, 13, 3},
          new int[] {32, 32, 4},
          new int[] {34, 34, 5},
          new int[] {40, 40, 6},
          new int[] {41, 41, 7},
          new int[] {42, 42, 8},
          new int[] {43, 43, 9},
          new int[] {44, 44, 10},
          new int[] {45, 45, 11},
          new int[] {47, 47, 12},
          new int[] {48, 48, 13},
          new int[] {49, 57, 14},
          new int[] {58, 58, 15},
          new int[] {59, 59, 16},
          new int[] {65, 90, 17},
          new int[] {97, 101, 17},
          new int[] {102, 102, 18},
          new int[] {103, 104, 17},
          new int[] {105, 105, 19},
          new int[] {106, 108, 17},
          new int[] {109, 109, 20},
          new int[] {110, 122, 17},
          new int[] {123, 123, 21},
          new int[] {125, 125, 22},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {34, 34, 23},
          new int[] {65, 90, 24},
          new int[] {97, 122, 24},
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
          new int[] {47, 47, 25},
        },
        new int[][] {
        },
        new int[][] {
          new int[] {48, 57, 26},
        },
        new int[][] {
          new int[] {61, 61, 27},
        },
        new int[][] {
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 122, 17},
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 116, 17},
          new int[] {117, 117, 28},
          new int[] {118, 122, 17},
        },
        new int[][] {
          new int[] {65, 101, -2},
          new int[] {102, 102, 29},
          new int[] {103, 122, 17},
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 97, 30},
          new int[] {98, 122, 17},
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
          new int[] {34, 122, -7},
        },
        new int[][] {
          new int[] {0, 9, 31},
          new int[] {11, 12, 31},
          new int[] {14, 65535, 31},
        },
        new int[][] {
          new int[] {48, 57, 26},
        },
        new int[][] {
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 109, 17},
          new int[] {110, 110, 32},
          new int[] {111, 122, 17},
        },
        new int[][] {
          new int[] {65, 122, -19},
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 104, 17},
          new int[] {105, 105, 33},
          new int[] {106, 122, 17},
        },
        new int[][] {
          new int[] {0, 65535, -27},
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 98, 17},
          new int[] {99, 99, 34},
          new int[] {100, 122, 17},
        },
        new int[][] {
          new int[] {65, 109, -30},
          new int[] {110, 110, 35},
          new int[] {111, 122, 17},
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 115, 17},
          new int[] {116, 116, 36},
          new int[] {117, 122, 17},
        },
        new int[][] {
          new int[] {65, 122, -19},
        },
        new int[][] {
          new int[] {65, 104, -32},
          new int[] {105, 105, 37},
          new int[] {106, 122, 17},
        },
        new int[][] {
          new int[] {65, 90, 17},
          new int[] {97, 110, 17},
          new int[] {111, 111, 38},
          new int[] {112, 122, 17},
        },
        new int[][] {
          new int[] {65, 109, -30},
          new int[] {110, 110, 39},
          new int[] {111, 122, 17},
        },
        new int[][] {
          new int[] {65, 122, -19},
        },
      },
    };

    private static int[][] accept = {
      new int[] {
        -1, 17, 17, 17, 17, -1, 5, 6, 3, 1, 9, 2, -1, 15, 15, -1, 
        4, 13, 13, 13, 13, 7, 8, 16, -1, 14, 15, 0, 13, 12, 13, 14, 
        13, 13, 13, 10, 13, 13, 13, 11, 
      },
    };

    public class State
    {
        public static State INITIAL = new State(0);

        private int _id;

        private State(int _id)
        {
            this._id = _id;
        }

        public int id()
        {
            return _id;
        }
    }
}
}
