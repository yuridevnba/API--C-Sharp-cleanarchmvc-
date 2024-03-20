<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Descrição da API Clean Architecture ASP .NET Core</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 0 20px;
        }

        h1 {
            color: #333;
            text-align: center;
        }

        h2 {
            color: #555;
            margin-top: 30px;
        }

        p {
            color: #777;
        }

        ul {
            margin-left: 20px;
            color: #777;
        }

        li {
            margin-bottom: 10px;
        }
    </style>
</head>

<body>
    <div class="container">
        <h1>Descrição da API Clean Architecture ASP .NET Core</h1>

        <p>Este projeto é uma implementação prática dos conceitos da Clean Architecture aplicados a uma API ASP .NET Core. A Clean Architecture refere-se à organização do projeto de forma que seja fácil de entender e de modificar à medida que o projeto cresce, permitindo uma manutenção mais fácil e a adição de novas funcionalidades de forma simplificada.</p>

        <h2>Principais Características:</h2>

        <ul>
            <li><strong>Organização Estruturada:</strong> A aplicação é dividida em cinco projetos distintos, cada um com responsabilidades específicas: Domain, Application, Infrastructure, IoC e o projeto de apresentação (ASP .NET Core MVC).</li>
            <li><strong>Separação de Responsabilidades:</strong> Cada projeto possui responsabilidades bem definidas, permitindo uma melhor modularidade e reutilização de código.</li>
            <li><strong>Injeção de Dependência:</strong> Utiliza-se o padrão de Injeção de Dependência para gerenciar as dependências entre os componentes da aplicação, promovendo um acoplamento mais flexível.</li>
            <li><strong>Padrões de Design:</strong> Implementação de conceitos do Domain-Driven Design (DDD), bem como padrões Repository e CQRS, para uma melhor organização e manipulação dos dados.</li>
            <li><strong>Facilidade de Manutenção e Testabilidade:</strong> A aplicação é aderente às boas práticas da Clean Architecture, tornando a manutenção e a inclusão de novas funcionalidades mais simples e permitindo a aplicação de testes de forma eficiente.</li>
        </ul>

        <p>Este projeto serve como um exemplo prático de como desenvolver uma aplicação robusta e escalável utilizando os princípios da Clean Architecture no contexto do ASP .NET Core.</p>
    </div>
</body>

</html>

