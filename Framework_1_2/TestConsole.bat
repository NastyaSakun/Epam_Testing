cd Framework_1
msbuild.exe Framework_1.csproj
cd ../packages\NUnit.ConsoleRunner.3.10.0\tools
nunit3-console.exe --testparam:browser=Google --testparam:environment=dev "../../../Framework_1/bin/Debug/Framework_1.dll"