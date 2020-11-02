 
dotnet test CopaFilmes.Testes.Integracao\CopaFilmes.Testes.Integracao.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=CopaFilmes.Testes.Integracao\relatorio-cobertura\coverage.opencover.xml
reportgenerator -reports:CopaFilmes.Testes.Integracao\relatorio-cobertura\coverage.opencover.xml -targetdir:CopaFilmes.Testes.Integracao\relatorio-cobertura

dotnet test CopaFilmes.Testes.Unidade\CopaFilmes.Testes.Unidade.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=CopaFilmes.Testes.Unidade\relatorio-cobertura\coverage.opencover.xml
reportgenerator -reports:CopaFilmes.Testes.Unidade\relatorio-cobertura\coverage.opencover.xml -targetdir:CopaFilmes.Testes.Unidade\relatorio-cobertura

pause