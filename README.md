## Copa Filmes 

Copa Filmes é um projeto desenvolvido com ASP.NET Core e Angular 10. O projeto consiste em realizar partidas entre filmes e encontrar um vencedor. 

#### Pré Requisitos:

Para executar os projetos, certifique-se que tenha instalado os recursos abaixo:

* Visual Studio 2019 e .NET Core SDK 3.1;
* Angular CLI > 10.x
* Node > 10.13.x 

#### Executando com Docker:

1. Faça o clone deste repositório em uma pasta de sua preferência. 
2. Navegue para o diretório que esteja localizado o arquivo docker-compose.yaml
3. Execute o comando abaixo:

```
docker-compose up -d
```
O projeto de Front End poderá ser acessado através da porta 20000

Exemplo: http://localhost:20000/

A API e sua respectiva documentação técnica estarão disponíveis na porta 20001

Exemplo: http://localhost:20001/swagger/index.html