# Projeto Banco de Dados Cliente

# Nova implemntacao com melhorias e aplicação do Padrão Repository e injeção de Dependência - adicionado em 28/10/22

# Nova implementação adicionada em 20/10/22 - pasta NovaImplementacao

O presente projeto foi idealizado para exercitar, testar e aprimorar o aprendizado em C# dotNet, Web Api, e Web
Data do início: 01/10/2022

## Desafio de projeto
Para este projeto será necessário criar um Banco de Dados relacional onde será armazernado duas Tabelas: Tabela Clientes com os dados pessoais
mínimos: Nome, Cpf, Status - status representando se o cliente é ativo ou não; e Tabela contatos, para armazenar dados de enderaço, telefone e 
E-mail dos clientes.

## Contexto
Necessário construir um sistema gerenciador de Clientes, será possível cadastrar, visualizar os clientes inseridos, visualizar os dados mais os 
dados de contato do cliente, alterá-los e tornar um cliente inativo, por console e Web browser, utilizando uma Api.

Essa lista de tarefas precisa ter um CRUD, ou seja, deverá permitir a você obter os registros, criar, salvar e del


Se for testar, não esquecer de gerar migration bem como atualizar a propriedade minhaUri com o endereço do localhost e porta!

### ALTERAÇÕES NO PROJETO (20/10/2022)

Após essa primeira etapa, foi decidido que para melhorar o projeto seria mais interessante desenvolver um novo Banco de Dados, com três tabelas: Cliente, Endereço e Contato. 
Não houve maior investimento no Front End, com tratamento de entrada de dados pelo usuário, sendo essa uma implementação futura.


## Métodos esperados

É esperado que você crie o seus métodos conforme a seguir:


**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Cliente/{id}           | id        | N/A           |
| PUT    | /Cliente/{id}           | id        | N/A           |
| GET    | /Cliente/Listar         | N/A       | N/A           |
| GET    | /Endereço/ObterPor      |           |               |
|        |  ClienteId              | ClienteId |               |
| POST   | /Cliente                | ClienteID | N/A           |
| POST   | /Endereço               | EnderecoID| N/A           |




