<div align="center">
<img align="center" width="24%" src="./.github/logo.png" />
<br>
<i>
    API usada para a comunica??o entre os servi?os e produtos da empresa Tup? - Mobile, Web e Desktop.
</i>
</div>

## Come?ando

### Instalando localmente projeto

```bash
# Clone o reposit?rio em sua m?quina
$ git clone https://github.com/BaseTech-Inc/Tupa-Server.git
```

### Configurando ambiente

- Para inicializar os [valores secretos](https://docs.microsoft.com/pt-br/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows) 
  ? nescess?rio executar o seguinte comando em **`WebAPI/`**:

    ```bash
        $ dotnet user-secrets init
    ```

    ? nescess?rio inserir os seguintes valores:

    ```bash
        # A SecretKey ? usada para gerar o token de acesso
        $ dotnet user-secrets set "JWT:SecretKeyy" "valor_aleat?rio"

        # O ClientId ? usada para validar o token da Google
        $ dotnet user-secrets set "Authentication:Google:ClientId" "ClientId"
    ```

    Para gerar um valor aleat?rio pode-se usar esse [site](https://www.uuidgenerator.net/), e para usar a autentica??o pelo Google pode usar esse [site](https://developers.google.com/workspace/guides/getstarted-overview).

- Se desejar usar o SQL Server, precisar? atualizar **`WebAPI/appsettings.json`** da seguinte maneira:

    ```json
      "UseInMemoryDatabase": false,
    ```

    Verifique se a string de conex?o DefaultConnection em **`WebAPI/appsettings.json`** 
    aponta para uma inst?ncia v?lida do SQL Server.

- Para criar as [migra??es](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) ? nescess?rio navegar at? **`Infrastructure/`**, abrir o terminal 
e executar o seguinte comando:

    ```bash
        $ dotnet ef migrations add "MigrationName" -s ../WebAPI/ -o ./Persistence/Migrations/
    ```

    Para aplicar as migra??es no banco de dados ? nescess?rio executar o seguinte comando:

    ```bash
        $ dotnet ef database update -s ../WebAPI/
    ```

## Arquitetura

Como esse software funciona internamente e como ele interage com depend?ncias 
externas - escritos em detalhes em [`ARCHITECTURE.md`](ARCHITECTURE.md).

<img src="https://github.githubassets.com/images/mona-whisper.gif" align="right" />

## Licen?a

Esse projeto est? sob licen?a. Veja o arquivo [`LICEN?A`](https://github.com/BaseTech-Inc/Tupa-Server/blob/master/LICENSE) para mais detalhes.