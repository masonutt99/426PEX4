.assembly extern mscorlib {}
.assembly myprogram
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	ldc.i4 5
	ldc.i4 2
	bgt LABEL_TRUE1
		ldc.i4 0
	br LABEL_CONTINUE1
	LABEL_TRUE1:
		ldc.i4 1
	LABEL_CONTINUE1:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_11
	br LABEL_21
	LABEL_11:
	ldstr "  Greater than works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_31
	LABEL_21:
	LABEL_31:
	ldc.i4 2
	ldc.i4 5
	blt LABEL_TRUE2
		ldc.i4 0
	br LABEL_CONTINUE2
	LABEL_TRUE2:
		ldc.i4 1
	LABEL_CONTINUE2:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_12
	br LABEL_22
	LABEL_12:
	ldstr "  Less than works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_32
	LABEL_22:
	LABEL_32:
	ldc.i4 4
	ldc.i4 4
	bge LABEL_TRUE3
		ldc.i4 0
	br LABEL_CONTINUE3
	LABEL_TRUE3:
		ldc.i4 1
	LABEL_CONTINUE3:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_13
	br LABEL_23
	LABEL_13:
	ldstr "  Greater than or equal works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_33
	LABEL_23:
	LABEL_33:
	ldc.i4 4
	ldc.i4 4
	ble LABEL_TRUE4
		ldc.i4 0
	br LABEL_CONTINUE4
	LABEL_TRUE4:
		ldc.i4 1
	LABEL_CONTINUE4:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_14
	br LABEL_24
	LABEL_14:
	ldstr "  Less than or equal works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_34
	LABEL_24:
	LABEL_34:
	ldc.r8 5.0
	ldc.r8 5.0
	beq LABEL_TRUE5
		ldc.i4 0
	br LABEL_CONTINUE5
	LABEL_TRUE5:
		ldc.i4 1
	LABEL_CONTINUE5:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_15
	br LABEL_25
	LABEL_15:
	ldstr "  Equals works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_35
	LABEL_25:
	LABEL_35:
	ldc.r8 2.5
	ldc.r8 3.0
	bne.un LABEL_TRUE6
		ldc.i4 0
	br LABEL_CONTINUE6
	LABEL_TRUE6:
		ldc.i4 1
	LABEL_CONTINUE6:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_16
	br LABEL_26
	LABEL_16:
	ldstr "  Not Equals works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	br LABEL_36
	LABEL_26:
	LABEL_36:

	ret
}
