⚔️ RPG Manager System - ASP.NET Core MVC
Uma aplicação web full-stack desenvolvida em C# utilizando o framework ASP.NET Core MVC para gerir um ecossistema completo de RPG. O sistema permite o gerenciamento de Heróis, Grupos (Parties), Itens, Monstros e Masmorras (Dungeons).

O foco deste projeto foi a implementação robusta de persistência de dados utilizando o Entity Framework Core com a abordagem Code-First, garantindo um mapeamento objeto-relacional (OR/M) eficiente.

🚀 Destaques da Arquitetura e Regras de Negócio:

Mapeamento Relacional (1:N): Estruturação completa de chaves estrangeiras entre entidades (ex: Heróis pertencem a um Grupo; Masmorras possuem múltiplos Monstros).

Validações no Backend: Implementação de regras de negócio customizadas, como o bloqueio automático de adição de heróis a um grupo (Party) caso o limite máximo de membros configurado seja excedido.

Data Annotations: Garantia de integridade dos dados diretamente nas Models (limites de caracteres, ranges de atributos como Vida/Ataque, e campos obrigatórios).

Views Dinâmicas: Geração de interfaces com Razor Pages fortemente tipadas.

🛠️ Tecnologias Utilizadas:

C# / .NET

ASP.NET Core MVC

Entity Framework Core (ORM)

SQL Server (Migrations)

HTML/CSS + Razor
