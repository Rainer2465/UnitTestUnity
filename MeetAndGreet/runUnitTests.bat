@ECHO off
cls
:start
ECHO.
ECHO 1. 2020.3.25f1
ECHO 2. 2020.3.19f1
ECHO 3. 2021.2.6
ECHO.

set CUR_HH=%time:~0,2%
if %CUR_HH% lss 10 (set CUR_HH=0%time:~1,1%)

set CUR_NN=%time:~3,2%
set CUR_SS=%time:~6,2%
set CUR_MS=%time:~9,2%

set SUBFILENAME=%CUR_HH%%CUR_NN%%CUR_SS%
set choice=
set /p choice=Select your versions. 
if not '%choice%'=='' set choice=%choice:~0,1%
if '%choice%'=='1' goto runTest
if '%choice%'=='2' goto invalidVersion
if '%choice%'=='3' goto invalidVersion
ECHO "%choice%" is not valid, try again
ECHO.
goto start
:invalidVersion
ECHO Your version is not implemented yet
goto end
:runTest
ECHO Tests running...
ECHO %SUBFILENAME%
start cmd.exe /c ""C:\Program Files\Unity\Hub\Editor\2020.3.25f1\Editor\Unity.exe" -runTests -batchmode -projectPath "C:\Users\Ellevo\Unit Testes" -testResults "C:\Users\Ellevo\Documents\results_%SUBFILENAME%.xml" -testPlatform EditMode"
goto end
:end
ECHO All tests completed...
pause
echo %DATE%-%TIME%