

# Cadastro Clientes v1 - Backend  

Projeto realizado com as tecnologias .Net 8.0 Core (ASP.NET Core, Entity Framework Core e Swagger) para desenvolvimento da API e React JS (Typescript, HTML, CSS e Bootstrap) para o front-end. Para banco de dados, usei SQL Server com tabelas devidamente relacionadas e a arquitetura de desenvolvimento é MVC.

A comunicação entre o back-end e o front-end é feita através de requisições HTTP, utilizando o protocolo RESTful para a troca de dados.

## Funcionalidades da API
Esta API permite o gerenciamento de cidades e clientes, incluindo operações como ler, criar, atualizar e excluir informações destas.

## Cidades - Endpoints Disponíveis
### GET /api/Cidade
	Retorna uma lista de todas as cidades cadastradas.
#### Respostas
- 200 OK: Retorna a lista de cidades.
- 400 Bad Request: Se os dados da solicitação forem inválidos.
- 500 Internal Server Error: Se ocorrer um erro interno do servidor.
### GET /api/Cidade/{id}

Retorna os detalhes de uma cidade específica com base no ID fornecido.

#### Parâmetros

-   id (int): O ID da cidade desejada.

#### Respostas

-   200 OK: Retorna os detalhes da cidade.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se a cidade não for encontrada com o ID fornecido.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### GET /api/Cidade/estado/{estado}

Retorna uma lista de cidades com base no estado fornecido.

#### Parâmetros

-   estado (string): A UF do estado desejado.

#### Respostas

-   200 OK: Retorna a lista de cidades para o estado fornecido.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se nenhuma cidade for encontrada para o estado.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### GET /api/Cidade/cidade/{cidade}

Retorna detalhes de uma cidade com base no nome.

#### Parâmetros

- cidade (string): Uma parte ou o nome completo da cidade desejada.

#### Respostas

-   200 OK: Retorna os detalhes da cidade com o nome fornecido.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se a cidade não for encontrada com o nome fornecido.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### POST /api/Cidade

Cria uma nova cidade com os dados fornecidos.

#### Corpo da Solicitação

Um objeto JSON contendo os seguintes campos:

-   Cidade (string): O nome da cidade.
-   Estado (string): A sigla do estado.

#### Respostas

-   200 OK: Retorna os detalhes da cidade recém-criada.
-   400 Bad Request: Se os dados da solicitação forem inválidos ou se a cidade já existir.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### PUT /api/Cidade

Atualiza os dados de uma cidade existente com base no ID.

#### Corpo da Solicitação

Um objeto JSON contendo os seguintes campos:

-   Id (int): O ID da cidade a ser atualizada.
-   Cidade (string): O novo nome da cidade.
-   Estado (string): A nova UF do estado.

#### Respostas

-   200 OK: Retorna os detalhes da cidade atualizada.
-   400 Bad Request: Se os dados da solicitação forem inválidos ou se a cidade não for encontrada.
-   404 Not Found: Se a cidade não for encontrada com o ID fornecido.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### DELETE /api/Cidade

Exclui uma cidade com base no ID.

#### Parâmetros

-   id (int): O ID da cidade a ser excluída.

#### Respostas

-   200 OK: Retorna uma lista com as cidades restantes.
-   400 Bad Request: Se os dados da solicitação forem inválidos, se a cidade não for encontrada ou se já existir cliente com vínculo nessa cidade.
-   404 Not Found: Se a cidade não for encontrada com o ID.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.
---
## Clientes- Endpoints Disponíveis

### GET /api/Cliente

Retorna todos os clientes cadastrados.

#### Respostas

-   200 OK: Retorna uma lista de todos os clientes cadastrados.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.


### GET /api/Cliente/FindById/{id}

Retorna detalhes de um cliente com base em um ID.

#### Parâmetros

-   id (int): O ID do cliente.

#### Respostas

-   200 OK: Retorna os detalhes do cliente correspondente ao ID.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se nenhum cliente corresponder ao ID.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

### GET /api/Cliente/FindByName

Retorna uma lista de clientes com base em parte do nome e/ou sobrenome fornecido.

#### Parâmetros

-   nome (string): Uma parte do nome do cliente.
-   sobrenome (string): Uma parte do sobrenome do cliente.

#### Respostas

-   200 OK: Retorna uma lista de clientes que correspondem à parte do nome e/ou sobrenome fornecidos.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se nenhum cliente corresponder à parte do nome e/ou sobrenome fornecidos.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.


### POST /api/Cliente

Cria um novo cliente com base nos dados fornecidos.

#### Corpo da Solicitação
    {
	    "Nome": "string",
	    "Sobrenome": "string",
	    "Sexo": "string",
	    "DataNascimento": "DateTime",
	    "Ativo": "bool",
	    "CidadeId": "int"
    }

#### Respostas

-   200 OK: Retorna os detalhes do cliente recém-criado.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se a cidade associada ao cliente não for encontrada.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

----------

### PUT /api/Cliente

Atualiza os detalhes de um cliente com base nos dados.

#### Corpo da Solicitação

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
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se o cliente ou a cidade associada ao cliente não forem encontrados.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.

----------

### DELETE /api/Cliente

Exclui um cliente com base no ID.

#### Parâmetros

-   id (int): O ID do cliente a ser excluído.

#### Respostas

-   200 OK: Retorna uma lista com todos os outros clientes restantes.
-   400 Bad Request: Se os dados da solicitação forem inválidos.
-   404 Not Found: Se o cliente não for encontrado.
-   500 Internal Server Error: Se ocorrer um erro interno do servidor.
