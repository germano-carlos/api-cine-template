
# Api de Cinemas 

O presente projeto é uma API simples e fictía para armazenamento e operações de filmes. Para trabalhos futuros poderá ser integrado a api de filmes para uma melhor massa de dados.

# Instalação

A instalação da aplicação é bem simples, você precisará das seguintes aplicações:

- [.NET 6 Core (SDK)](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - Faça o download da SDK do .NET Core 6
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) - Escolha entre Visual Studio ou Rider JetBrains
- [Rider](https://www.jetbrains.com/pt-br/rider/) - Escolha entre Visual Studio ou Rider JetBrains

# Baixando o Projeto Atual

o download e execucao do projeto é simples:

```bash
### Clonando o repositorio local
$ git clone https://github.com/germano-carlos/api-cine-template.git

### ICaminhando a pasta clonada
$ cd /api-cine-template/Fontes/

### Limpando o cache
$ dotnet clean

### Restaurando pacotes
$ dotnet restore

```

# Criando Projeto

A criação de uma nova solução pode ser realizada pela própria IDE (Rider ou Visual Studio Code), ou se desejado realizar via dotnet cli, seguir a documentação:
- [Documentação .NET Cli](https://docs.microsoft.com/pt-br/dotnet/core/tools/dotnet-sln)

# Criando Novo Projeto de Testes

Para criar uma nova solução e um novo projeto de testes execute os seguintes comandos:

```bash
dotnet new sln -o unit-testing-using-dotnet-test
cd unit-testing-using-dotnet-test
dotnet new classlib -o PrimeService
ren .\PrimeService\Class1.cs PrimeService.cs
dotnet sln add ./PrimeService/PrimeService.csproj
dotnet new xunit -o PrimeService.Tests
dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
```

Maiores detalhes podem ser visto em: [Documentação Testes](https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-dotnet-test)
