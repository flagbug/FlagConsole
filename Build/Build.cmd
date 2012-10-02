@echo on
call "%VS110COMNTOOLS%vsvars32.bat"

msbuild.exe /ToolsVersion:4.0 "..\FlagConsole\FlagConsole.sln" /p:configuration=Release

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