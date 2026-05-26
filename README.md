# 📦 Sistema de Gestão Logística – EntregaJá
> Prova – Programação Orientada a Objetos | C# Console

---

## 📋 Regra de Negócio

A **EntregaJá** é uma plataforma de logística e marketplace que conecta vendedores, transportadoras e clientes para gerenciar o ciclo completo de pedidos e entregas. Com o crescimento das vendas online, a administração decidiu desenvolver um sistema interno para organizar e consultar informações sobre pedidos, entregas, clientes e transportadoras.

A plataforma opera em parceria com diversas **transportadoras**. Cada transportadora possui um código único de três caracteres — como `"JDX"` ou `"AZL"` —, um nome, o estado de operação e uma modalidade de transporte, que pode ser: **Terrestre**, **Aéreo** ou **Fluvial**.

Os **clientes** que utilizam a plataforma são cadastrados com nome completo, e-mail único, CPF único e telefone. Um cliente pode realizar vários pedidos ao longo do tempo.

Os **pedidos** são a entidade central do sistema. Cada pedido possui um código único — por exemplo, `"PED-00142"` —, uma descrição do produto, o valor total em reais, o peso em quilogramas e a data de criação. Todo pedido deve estar obrigatoriamente vinculado a um cliente, sem o qual ele não pode ser cadastrado. Além disso, cada pedido possui um status, que pode ser: **Pendente**, **Em Processamento** ou **Cancelado**.

A associação entre um pedido e uma transportadora é registrada como uma **entrega**. Ao registrar a entrega, o sistema armazena a data de coleta, o prazo estimado em dias, o endereço de destino e o status da entrega, que pode ser: **Coletado**, **Em Trânsito**, **Entregue** ou **Devolvido**. Um pedido não pode ter duas entregas ativas ao mesmo tempo.

O sistema precisa ser capaz de, a qualquer momento, listar todos os clientes, pedidos, transportadoras e entregas cadastrados. Também deve ser possível buscar um cliente pelo nome — mesmo que a busca seja parcial, o sistema deve retornar todos os clientes cujo nome contenha o trecho digitado, sem distinção entre maiúsculas e minúsculas.

Uma funcionalidade essencial é o **Ranking de Transportadoras por Entregas**: o sistema deve exibir todas as transportadoras ordenadas pela quantidade total de entregas realizadas, detalhando a quantidade por status de entrega. Os grupos devem ser exibidos em ordem decrescente de total de entregas.

O sistema também deve oferecer um **Histórico de Pedidos por Cliente**: ao selecionar um cliente, o sistema exibe todos os pedidos em que ele possui entrega registrada, com o código do pedido, descrição do produto, valor total, transportadora responsável, status da entrega e data de coleta. Os pedidos devem ser exibidos em ordem cronológica crescente pela data de coleta.

Por fim, a administração precisa filtrar entregas de uma transportadora específica por status: dado o código da transportadora e um status, o sistema exibe todas as entregas daquela transportadora com aquele status, ordenadas pela data de coleta crescente.

Todo o funcionamento do sistema se dá por meio de um menu interativo no console, que permanece ativo até que o usuário escolha explicitamente a opção de encerramento.

---

## 🎯 Objetivo

Desenvolver um sistema de gestão logística em console, aplicando conceitos de:

- Programação Orientada a Objetos (POO)

---

## 🗂️ Etapas da Atividade

### Etapa 1 – Desenvolvimento do Sistema (CRUD)

O sistema deve ser feito em **C# (Console)** e conter:

**CRUD completo para:**
- Clientes (Criar, Editar, Excluir, Listar)
- Transportadoras (Criar, Editar, Excluir, Listar)
- Pedidos (Criar, Editar, Excluir, Listar)
- Entregas (Criar, Editar, Excluir, Listar)

---

## ✅ Funcionalidades Obrigatórias

### Busca de Clientes
- Busca por nome (parcial)
- Busca case insensitive

---

### Ranking de Transportadoras por Entregas
- Exibir todas as transportadoras ordenadas pelo total de entregas
- Detalhar a quantidade por status de entrega
- Ordenar em ordem decrescente de total de entregas

---

### Histórico de Pedidos por Cliente
Para cada pedido em que o cliente possui entrega registrada, exibir:
- Código do pedido
- Descrição do produto
- Valor total
- Transportadora responsável
- Status da entrega
- Data de coleta
- Ordenar em ordem cronológica crescente pela data de coleta

---

### Filtro por Status de Entrega na Transportadora
- Dado o código de uma transportadora e um status, exibir todas as entregas com aquele status
- Ordenar por data de coleta crescente

---

## 🧩 Entidades

| Entidade | Atributos Principais | Observações |
|---|---|---|
| `Transportadora` | Código (3 chars), Nome, Estado, Modalidade | Código único; modalidade via enum |
| `Cliente` | Nome, E-mail, CPF, Telefone | CPF único; e-mail único |
| `Pedido` | Código, Descrição, Valor, Peso, Data, Status | Código único; vinculado a um cliente |
| `Entrega` | Data Coleta, Prazo, Endereço, Status | Associa Pedido + Transportadora |

---

## 🔢 Enumeradores

```csharp
public enum ModalidadeTransporteEnum
{
    Terrestre = 1,
    Aereo = 2,
    Fluvial = 3,
}

public enum StatusPedidoEnum
{
    Pendente = 1,
    EmProcessamento = 2,
    Cancelado = 3,
}

public enum StatusEntregaEnum
{
    Coletado = 1,
    EmTransito = 2,
    Entregue = 3,
    Devolvido = 4,
}
```

---

## ⚠️ Regras de Negócio

- Um pedido não pode ter duas entregas ativas ao mesmo tempo
- O código da transportadora deve ter exatamente 3 caracteres
- O CPF do cliente deve ter exatamente 11 dígitos e ser único no sistema
- O e-mail do cliente deve ser único no sistema
- O código do pedido deve ser único no sistema

---

## 🏗️ Estrutura de Arquivos

```
EntregaJa/
├── Program.cs
├── Models/
│   ├── Transportadora.cs
│   ├── Cliente.cs
│   ├── Pedido.cs
│   └── Entrega.cs
└── Enum/
    ├── ModalidadeTransporteEnum.cs
    ├── StatusPedidoEnum.cs
    └── StatusEntregaEnum.cs
```

---

## 💡 Dica de POO Puro

Para demonstrar domínio de Orientação a Objetos, a lógica de negócio deve estar dentro das próprias classes:

- `Transportadora` contém o método que filtra e gera o ranking de suas entregas
- `Cliente` contém o método que retorna seu histórico de pedidos
- `Program.cs` contém apenas `Console.ReadLine`, `Console.WriteLine` e chamadas aos métodos das classes

Isso demonstra que cada classe sabe fazer seu próprio trabalho — que é o princípio central do POO.

---

## 🚀 Como Executar

```bash
dotnet run
```

---

## 📦 Entrega

- Código fonte completo
- O sistema deve compilar e executar corretamente
