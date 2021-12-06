.assembly extern mscorlib {}
.assembly myprogram
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	ldc.i4 1
	ldc.i4 2
	clt
	ldc.i4 2
	ldc.i4 3
	clt
	and
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
	ldstr "And Works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_31
	LABEL_21:
	LABEL_31:
	ldc.i4 2
	ldc.i4 1
	clt
	ldc.i4 1
	ldc.i4 2
	clt
	or
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
	ldstr "Or works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_32
	LABEL_22:
	LABEL_32:
	ldc.i4 2
	ldc.i4 1
	clt
	not
	ldc.i4 1
	beq LABEL_TRUE3
		ldc.i4 0
	br LABEL_CONTINUE3
	LABEL_TRUE3:
		ldc.i4 1
	LABEL_CONTINUE3:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_13
	br LABEL_23
	LABEL_13:
	ldstr "Not works"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_33
	LABEL_23:
	LABEL_33:

	ret
}
