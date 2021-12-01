.assembly extern mscorlib {}
.assembly toyprogram
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	ldc.i4 1
	ldc.i4 2
	add
	ldc.i4 1
	beq LABEL_TRUE
		ldc.i4 0
	br LABEL_CONTINUE
	LABEL_TRUE:
		ldc.i4 1
	LABEL_CONTINUE:

	// IF TRUE CODE GOES HERE
	brtrue LABEL_1
	br LABEL_2
	LABEL_1:
	ldstr "hey"
	call void [mscorlib]System.Console::Write(string)

	LABEL_2:
	ldstr "quzzup"
	call void [mscorlib]System.Console::Write(string)


	ret
}
