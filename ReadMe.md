**Visão Geral do Projeto**
O projeto tem como objetivo criar um sistema de cadastro de produtos e clientes, com as operações básicas de inserir, editar, visualizar e deletar. A aplicação conta com cinco páginas principais: login, lista de produtos, cadastro de produtos, lista de clientes e cadastro de clientes.
Utiliza a arquitetura MVC (Model-View-Controller) do ASP.NET, onde as entidades do sistema (produtos,usuarios e clientes) são representadas por modelos e as funcionalidades são implementadas em controladores.

 Configurar o banco de dados com o Entity Framework.
A comunicação com o banco de dados é realizada através do Entity Framework.Os scripts das tabelas estão na pasta Migrations.


**Tecnologias Utilizadas**
ASP.NET MVC
C# 
Entity Framework
HTML
CSS
Bootstrap
JavaScript - Jquery
SQL Server

**Página de Login**:
A página de login tem os campos de usuário, senha e confirmar. É feita a validação básica para o login,
e ao efetuar o login o usuário é redirecionado para a página que contém a opção de ir para a tela de produto e de cliente.
(Pode criar um novo usuario no Banco de dados e entrar com esse usuario caso necessario)

**Pagina de Usuarios**
Criei a pagina de usuarios para poder cadastrar novos usuarios no sistema, apos o cadastro ele ficara exibido na mesma pagina aonde podera editar ou excluir, e você podera logar com ele respectivamente.

**Pagina de  Produtos**:
A pagina de produtos vizualiza os produtos já adicionados.

**Cadastro de produtos**:
A Pagina de cadastro de produtos mostra os produtos já adicionados, e tem as opções de adicionar um novo produto, editar e deletar.

**Pagina de Clientes**:
A pagina de clientes vizualiza os clientes já adicionados.

**Cadastro do cliente**:
A Pagina de clientes  mostra os clientes já adicionados, e tem as opções de adicionar um novo cliente, editar e deletar.

*Para executar o projeto é necessário ter o ambiente do Visual Studio instalado e configurado para desenvolvimento em ASP.NET MVC com C#. Além disso, é necessário configurar a conexão com o banco de dados através do entity Framework (Se necessario crie um usuario atraves do BD para primeiro login)*.



O projeto está organizado de acordo com o padrão de arquitetura MVC, com as pastas Models, Views e Controllers para cada página. As classes e métodos foram nomeados de forma clara e objetiva, facilitando a manutenção e o entendimento do código.

No geral, o projeto atende às especificações solicitadas pela Softline Sistemas, oferecendo uma solução de acordo com meu conhecimento no momento, com operações básicas e funcionalidades bem definidas.

Utilizei das seguintes documentações para me auxiliar no desenvolvimento:
https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection
https://learn.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/accessing-your-models-data-from-a-controller
