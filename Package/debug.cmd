XCOPY "..\Client\bin\Debug\net7.0\MyCompany.Module.Dapper.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Client\bin\Debug\net7.0\MyCompany.Module.Dapper.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Server\bin\Debug\net7.0\MyCompany.Module.Dapper.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Server\bin\Debug\net7.0\MyCompany.Module.Dapper.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Shared\bin\Debug\net7.0\MyCompany.Module.Dapper.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
XCOPY "..\Shared\bin\Debug\net7.0\MyCompany.Module.Dapper.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
REM Copy Client to the Bin folder (and any dll dependencies)
XCOPY "..\Server\bin\Debug\net7.0\Dapper.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net7.0\" /Y
