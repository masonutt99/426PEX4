.assembly extern mscorlib {}
.assembly myprogram
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	// Declaring Variable x
	.locals init (int32 x)

	ldc.i4 0

	stloc x

	// Declaring Variable y
	.locals init (int32 y)

	ldc.i4 0

	stloc y

	LABEL_START1:
	ldloc y
	ldc.i4 3
	ble LABEL_TRUEw1
	br LABEL_FALSE1
	LABEL_TRUEw1:
	LABEL_START2:
	ldloc x
	ldc.i4 3
	ble LABEL_TRUEw2
	br LABEL_FALSE2
	LABEL_TRUEw2:
	ldstr "  "
	call void [mscorlib]System.Console::Write(string)

	ldloc x
	call void [mscorlib]System.Console::Write(int32)

	ldstr ", "
	call void [mscorlib]System.Console::Write(string)

	ldloc y
	call void [mscorlib]System.Console::Write(int32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldloc x
	ldc.i4 1
	add

	stloc x

	br LABEL_START2
	LABEL_FALSE2:
	ldc.i4 0

	stloc x

	ldloc y
	ldc.i4 1
	add

	stloc y

	br LABEL_START1
	LABEL_FALSE1:
	ldstr "  Loop Complete"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)


	ret
}
