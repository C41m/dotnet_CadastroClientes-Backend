

# Cadastro Clientes v1 - Backend  

Projeto realizado com as tecnologias .Net 8.0 Core (ASP.NET Core, Entity Framework Core e Swagger) para desenvolvimento da API e React JS (Typescript, HTML, CSS e Bootstrap) para o front-end. Para banco de dados, usei SQL Server com tabelas devidamente relacionadas e a arquitetura de desenvolvimento � MVC.

A comunica��o entre o back-end e o front-end � feita atrav�s de requisi��es HTTP, utilizando o protocolo RESTful para a troca de dados.

## Funcionalidades da API
Esta API permite o gerenciamento de cidades e clientes, incluindo opera��es como ler, criar, atualizar e excluir informa��es destas.

## Cidades - Endpoints Dispon�veis
### GET /api/Cidade
	Retorna uma lista de todas as cidades cadastradas.
#### Respostas
- 200 OK: Retorna a lista de cidades.
- 400 Bad Request: Se os dados da solicita��o forem inv�lidos.
- 500 Internal Server Error: Se ocorrer um erro interno do servidor.
### GET /api/Cidade/{id}

Retorna os detalhes de uma cidade espec�fica com base no ID fornecido.

#### Par�metros

-   id (int): O ID da cidade desejada.

#### Respostas

-   200 OK: Retorna os detalhes da cidade.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se a cidade n�o for encontrada com o ID fornecido.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### GET /api/Cidade/estado/{estado}

Retorna uma lista de cidades com base no estado fornecido.

#### Par�metros

-   estado (string): A UF do estado desejado.

#### Respostas

-   200 OK: Retorna a lista de cidades para o estado fornecido.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se nenhuma cidade for encontrada para o estado.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### GET /api/Cidade/cidade/{cidade}

Retorna detalhes de uma cidade com base no nome.

#### Par�metros

- cidade (string): Uma parte ou o nome completo da cidade desejada.

#### Respostas

-   200 OK: Retorna os detalhes da cidade com o nome fornecido.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se a cidade n�o for encontrada com o nome fornecido.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### POST /api/Cidade

Cria uma nova cidade com os dados fornecidos.

#### Corpo da Solicita��o

Um objeto JSON contendo os seguintes campos:

-   Cidade (string): O nome da cidade.
-   Estado (string): A sigla do estado.

#### Respostas

-   200 OK: Retorna os detalhes da cidade rec�m-criada.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos ou se a cidade j� existir.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### PUT /api/Cidade

Atualiza os dados de uma cidade existente com base no ID.

#### Corpo da Solicita��o

Um objeto JSON contendo os seguintes campos:

-   Id (int): O ID da cidade a ser atualizada.
-   Cidade (string): O novo nome da cidade.
-   Estado (string): A nova UF do estado.

#### Respostas

-   200 OK: Retorna os detalhes da cidade atualizada.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos ou se a cidade n�o for encontrada.
-   404 Not Found: Se a cidade n�o for encontrada com o ID fornecido.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### DELETE /api/Cidade

Exclui uma cidade com base no ID.

#### Par�metros

-   id (int): O ID da cidade a ser exclu�da.

#### Respostas

-   200 OK: Retorna uma lista com as cidades restantes.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos, se a cidade n�o for encontrada ou se j� existir cliente com v�nculo nessa cidade.
-   404 Not Found: Se a cidade n�o for encontrada com o ID.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.
---
## Clientes- Endpoints Dispon�veis

### GET /api/Cliente

Retorna todos os clientes cadastrados.

#### Respostas

-   200 OK: Retorna uma lista de todos os clientes cadastrados.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.


### GET /api/Cliente/FindById/{id}

Retorna detalhes de um cliente com base em um ID.

#### Par�metros

-   id (int): O ID do cliente.

#### Respostas

-   200 OK: Retorna os detalhes do cliente correspondente ao ID.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se nenhum cliente corresponder ao ID.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### GET /api/Cliente/FindByName

Retorna uma lista de clientes com base em parte do nome e/ou sobrenome fornecido.

#### Par�metros

-   nome (string): Uma parte do nome do cliente.
-   sobrenome (string): Uma parte do sobrenome do cliente.

#### Respostas

-   200 OK: Retorna uma lista de clientes que correspondem � parte do nome e/ou sobrenome fornecidos.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se nenhum cliente corresponder � parte do nome e/ou sobrenome fornecidos.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.


### POST /api/Cliente

Cria um novo cliente com base nos dados fornecidos.

#### Corpo da Solicita��o
    {
	    "Nome": "string",
	    "Sobrenome": "string",
	    "Sexo": "string",
	    "DataNascimento": "DateTime",
	    "Ativo": "bool",
	    "CidadeId": "int"
    }

#### Respostas

-   200 OK: Retorna os detalhes do cliente rec�m-criado.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se a cidade associada ao cliente n�o for encontrada.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

----------

### PUT /api/Cliente

Atualiza os detalhes de um cliente com base nos dados.

#### Corpo da Solicita��o

	{
		"Id": "int",
		"Nome": "string",
		"Sobrenome": "string",
		"Sexo": "string",
		"DataNascimento": "DateTime",
		"Ativo": "bool",
		"CidadeId": "int"
	} 

#### Respostas

-   200 OK: Retorna os detalhes do cliente atualizado.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se o cliente ou a cidade associada ao cliente n�o forem encontrados.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

----------

### DELETE /api/Cliente

Exclui um cliente com base no ID.

#### Par�metros

-   id (int): O ID do cliente a ser exclu�do.

#### Respostas

-   200 OK: Retorna uma lista com todos os outros clientes restantes.
-   400 Bad Request: Se os dados da solicita��o forem inv�lidos.
-   404 Not Found: Se o cliente n�o for encontrado.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.
