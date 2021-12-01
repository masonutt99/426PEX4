:: Creates a Variable for the Output File
@SET file="pex_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

:: ----------------------------------------
:: TITLE
:: ----------------------------------------
echo TITLE GOES HERE >> %file%
echo Running Correct Test Cases >> %file%
echo. >> %file%

:: ----------------------------------------
:: GOOD EXAMPLES
:: ----------------------------------------
echo Testing Declaration Statements >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\test1.txt >> %file%
echo. >> %file%

:: ----------------------------------------
:: BAD EXAMPLES
:: ----------------------------------------
::echo Running Incorrect Test Cases >> %file%
::echo. >> %file%

pause