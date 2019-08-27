PS> cmd \c cd C:\Users\Admin\.nuget\packages\nbench.runner\1.2.2\tools\netcoreapp2.0
PS> .\nbench.runner.exe "C:\Program Files (x86)\Jenkins\workspace\HackFSE_API\CTS.HackFSE.UnitTest\bin\Debug\netcoreapp2.0\CTS.HackFSE.UnitTest.dll"

PS> .\nbench.runner.exe "C:\Program Files (x86)\Jenkins\workspace\HackFSE_API\CTS.HackFSE.LoadTest\bin\Debug\netcoreapp2.0\CTS.HackFSE.LoadTest.dll" "C:\Program Files (x86)\Jenkins\workspace\HackFSE_API\LoadTestResult.txt"