 
dotnet test CopaFilmes.Testes.Integracao /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=..\relatorio-cobertura\integracao.xml

dotnet test CopaFilmes.Testes.Unidade /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=..\relatorio-cobertura\unidade.xml

reportgenerator -reports:relatorio-cobertura/*.xml -targetdir:relatorio-cobertura

pause