# Blue Calculadora

Esse projeto consiste no desenvolvimento de uma aplicação frontend em Vue, backend consiste em uma webapi feita em .net7 juntamente com um worker fazendo uso de mensageria RabbitMQ e MySQL.

## 🚀 Começando

Essas instruções permitirão que você consiga executar a aplicação

### 📋 Pré-requisitos

Precisa ter conhecimentos em 
 ### Vue.js
 ### .net7
 ### RabbitMQ
 ### MySQL 
 ### Docker



### 🔧 Instalação

## Configurar RabbitMQ com Docker:

## Execute o seguinte comando para baixar e iniciar o container RabbitMQ:

```
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9.14-management
````

RabbitMQ estará disponível em http://localhost:15672. Use o nome de usuário e senha padrão guest para acessar o painel de gerenciamento.

## Configurar MySQL com Docker:

## Execute o seguinte comando para baixar e iniciar o container MySQL:

 ```
 docker run -d --name mysql -e MYSQL_ROOT_PASSWORD=admin -e MYSQL_DATABASE=Calculadora -e MYSQL_USER=admin -e MYSQL_PASSWORD=admin -p 3306:3306 mysql:latest
 ```

## Configurar WebAPI (Backend) com Docker:

## Execute o seguinte comando para iniciar a webapi:

Clone o repositório do backend:

```
git clone https://github.com/caiqueves/blue-calculadora/backend.git
```

Abra a pasta do projeto:

```
cd Backend\WebApi\Blue.Calculadora.Api
````

Crie um arquivo .env na raiz do projeto com as configurações do RabbitMQ e MySQL:
  ```
  RabbitMQConfig__HostName=rabbitmq
  RabbitMQConfig__Port=5672
  RabbitMQConfig__UserName=guest
  RabbitMQConfig__Password=guest
  
  MySQLConfig__HostName=mysql
  MySQLConfig__Port=3306
  MySQLConfig__UserName=admin
  MySQLConfig__Password=admin
  MySQLConfig__DataBase=Calculadora
  ```

Execute os seguintes comandos para criar e iniciar os containers:
  ```
  docker build -t webapi .
  docker run -d --name webapi -p 5001:80 --env-file .env webapi
  ````

A WebAPI estará disponível em http://localhost:5001.

## Configurar Worker (Backend) com Docker:

## Execute o seguinte comando para iniciar a worker:

Clone o repositório do backend:

```
git clone https://github.com/caiqueves/blue-calculadora/backend.git
```

Abra a pasta do projeto:

```
cd Backend\Worker\Blue.Calculadora.Worker
````

Crie um arquivo .env na raiz do projeto com as configurações do RabbitMQ e MySQL:
  ```
  RabbitMQConfig__HostName=rabbitmq
  RabbitMQConfig__Port=5672
  RabbitMQConfig__UserName=guest
  RabbitMQConfig__Password=guest
  
  MySQLConfig__HostName=mysql
  MySQLConfig__Port=3306
  MySQLConfig__UserName=admin
  MySQLConfig__Password=admin
  MySQLConfig__DataBase=Calculadora
  ```

Execute os seguintes comandos para criar e iniciar os containers:
  ```
  docker build -t worker .
  docker run -d --name worker -p 5001:80 --env-file .env worker
  ````

## Configurar FrontEnd:

## Execute o seguinte comando para iniciar o frontEnd:

Clone o repositório do backend:

```
https://github.com/caiqueves/blue-calculadora.git
```

Abra a pasta do projeto:

```
cd Frontend\bluecalculadora
````

Execute os seguintes comandos para iniciar aplicação
  ```
  npm run serve
  ````


## ✒️ Autores

Mencione todos aqueles que ajudaram a levantar o projeto desde o seu início

* **Caíque Neves** - *Trabalho Inicial* - [umdesenvolvedor](https://github.com/caiqueves)

## 🎁 Expressões de gratidão

* Conte a outras pessoas sobre este projeto 📢;
* Um agradecimento publicamente 🫂;
  
