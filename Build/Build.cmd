@echo on
REM load Visual Studio 2017 developer command prompt if VS150COMNTOOLS is not set

if "%VS150COMNTOOLS%" EQU "" if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat" (
    call "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat"
)
if "%VS150COMNTOOLS%" EQU "" if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat" (
    call "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"
)
if "%VS150COMNTOOLS%" EQU "" if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat" (
    call "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"
)
if "%VS150COMNTOOLS%" EQU "" if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat" (
    call "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat"
)

call "%VS150COMNTOOLS%vsvars32.bat"

msbuild.exe /ToolsVersion:12.0 "..\FlagConsole\FlagConsole.sln" /p:configuration=Release

mkdir ..\Release\Library
mkdir ..\Release\Demo

copy ..\FlagConsole\FlagConsole\bin\Release\FlagConsole.dll ..\Release\Library\FlagConsole.dll
copy ..\FlagConsole\FlagConsole\bin\Release\FlagConsole.xml ..\Release\Library\FlagConsole.xml
copy ..\Changelog.txt ..\Release\Library\Changelog.txt

copy ..\FlagConsole\FlagConsole\bin\Release\FlagConsole.dll ..\Release\Demo\FlagConsole.dll
copy ..\FlagConsole\FlagConsole\bin\Release\FlagConsole.xml ..\Release\Demo\FlagConsole.xml
copy ..\FlagConsole\FlagConsole.Demo\bin\Release\FlagConsole.Demo.exe ..\Release\Demo\FlagConsole.Demo.exe
copy ..\Changelog.txt ..\Release\Demo\Changelog.txt

pause