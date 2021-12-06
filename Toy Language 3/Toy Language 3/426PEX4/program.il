.assembly extern mscorlib {}
.assembly myprogram
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	ldc.r8 1.0
	ldc.r8 1.0
	add
	ldc.r8 3.0
	clt
	ldc.i4 1
	beq LABEL_TRUE1
		ldc.i4 0
	br LABEL_CONTINUE1
	LABEL_TRUE1:
		ldc.i4 1
	LABEL_CONTINUE1:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_11
	br LABEL_21
	LABEL_11:
	ldstr "  If (true) Statement Passes"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_31
	LABEL_21:
	ldstr "  adrian"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	LABEL_31:
	ldc.r8 5.0
	ldc.r8 3.0
	mul
	ldc.i4 1
	clt
	ldc.i4 1
	beq LABEL_TRUE2
		ldc.i4 0
	br LABEL_CONTINUE2
	LABEL_TRUE2:
		ldc.i4 1
	LABEL_CONTINUE2:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_12
	br LABEL_22
	LABEL_12:
	ldstr "  boby"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_32
	LABEL_22:
	ldstr "  If (false) Statement Passes"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	LABEL_32:

	ret
}
