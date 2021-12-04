.assembly extern mscorlib {}
.assembly toyprogram
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint

	// Declaring Variable i
	.locals init (int32 i)

	ldc.i4 1
	stloc i

	// Declaring Variable f1
	.locals init (float f1)

	ldc.r8 2.3
	stloc f1

	// Declaring Variable f2
	.locals init (float f2)

	ldc.r8 3.4e5
	stloc f2

	// Declaring Variable s
	.locals init (string s)

	ldstr "hello world"
	stloc s


	ret
}
