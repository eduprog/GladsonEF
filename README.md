
# GladsonEF

Projeto exemplo contendo acesso via EF e Logs para uma POC


## Documentação da API

#### Retorna todos os itens

```http
  GET /Documents
```


#### Retorna um item

```http
  GET /Documento/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer |

#### Deleta item
```http
  DEL /Documento/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer |

Recebe dois números e retorna a sua soma.


## Autores

- [@eduprog](https://github.com/eduprog)


## Aprendizados

*  Testando EF 8 com Migrations para Sqlite;
* Usando serilog para gerar logs 
* usando middleware para gerar logs de Request e Response. Arquivos que são gerados na pasta de execução da api /logs
* Arquivo de dados Sqlite está na pasta raiz do projeto nome de acordo com appsetings.json


## Variáveis appsetings.json

```json 
"ConnectionStrings": {
  "DefaultConnection": "Server=GLadson-PC;Database=GLadson;User Id=sa;Password=123456;",
  "Sqlite": "Data Source=GladsonTeste.db"
},
"LoggerSettings": {
  "AppName": "GLadson - ConfigurarLog Aqui.",
  "WriteToFile": true,
  "StructuredConsoleLogging": false
},
"MiddlewareSettings": {
  "EnableHttpsLogging": true,
  "EnableLocalization": true
}``` 



