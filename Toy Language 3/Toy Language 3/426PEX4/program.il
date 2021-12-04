.assembly extern mscorlib {}
.assembly myprogram
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
string 
	stloc i

	// Declaring Variable f1
	.locals init (float32 f1)

	ldc.r8 2.3
string 
	stloc f1

	// Declaring Variable f2
	.locals init (float32 f2)

	ldc.r8 3.4e5
string 
	stloc f2

	// Declaring Variable s
	.locals init (string s)

	ldstr "helloworld"
string 
	stloc s

	ldstr "i ="
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldloc i
	call void [mscorlib]System.Console::Write(int32)
	call void printInt()

	ldstr "f1 ="
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldloc f1
	call void [mscorlib]System.Console::Write(float32)

	ldstr "f2 ="
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldloc f2
	call void [mscorlib]System.Console::Write(float32)


	ret
}
