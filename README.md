# Tarefa – Modelagem e Banco de Dados: Sistema de Gestão Aeroportuária Céu Azul

## Regra de negócio: Aeroporto Internacional Céu Azul

O Aeroporto Internacional Céu Azul é um dos principais centros de conexão aérea do país, operando centenas de voos diariamente. Com o aumento do volume de operações, a administração do aeroporto decidiu desenvolver um sistema interno para organizar e consultar informações sobre voos, passageiros e companhias aéreas.

O aeroporto opera em parceria com diversas **companhias aéreas**. Cada companhia possui um código IATA único de dois caracteres — como "LA" ou "G3" —, um nome e o país de origem. Uma companhia aérea pode operar vários voos a partir do aeroporto.

Os **voos** são a entidade central do sistema. Cada voo possui um código único — por exemplo, "LA3042" —, um aeroporto de origem, um aeroporto de destino, uma data e hora de partida e uma duração estimada em minutos. Todo voo deve estar obrigatoriamente vinculado a uma companhia aérea, sem a qual ele não pode ser cadastrado no sistema. Além disso, cada voo possui um status operacional, que pode ser: **No Horário**, **Atrasado** ou **Cancelado**.

Os **passageiros** que utilizam o aeroporto são cadastrados com nome completo, data de nascimento, CPF único e número de passaporte, que também deve ser único no sistema. Um passageiro pode embarcar em vários voos ao longo do tempo.

A associação entre um passageiro e um voo é registrada como um **embarque**. Ao confirmar o embarque, o sistema registra a classe de viagem escolhida pelo passageiro — que pode ser **Econômica**, **Executiva** ou **Primeira Classe** —, o número da poltrona e a data de emissão do bilhete. Um passageiro não pode ter dois embarques no mesmo voo.

O sistema precisa ser capaz de, a qualquer momento, listar todos os passageiros, voos e companhias aéreas cadastrados. Também deve ser possível buscar um passageiro pelo nome — mesmo que a busca seja parcial, o sistema deve retornar todos os passageiros cujo nome contenha o trecho digitado, sem distinção entre maiúsculas e minúsculas.

Uma funcionalidade essencial para a operação do aeroporto é o **Ranking de Ocupação por Voo**: dado o código de um voo, o sistema deve exibir quantos passageiros estão embarcados naquele voo, detalhando a quantidade por classe de embarque. Os grupos devem ser exibidos em ordem decrescente de quantidade de passageiros.

O sistema também deve oferecer um **Histórico de Voos por Passageiro**: ao selecionar um passageiro, o sistema exibe todos os voos em que ele possui embarque registrado, com o código do voo, destino, data de partida, classe em que viajou e o status operacional do voo. Os voos devem ser exibidos em ordem cronológica crescente pela data de partida.

Por fim, a administração precisa filtrar passageiros de um voo específico por classe de embarque: dado o código de um voo e uma classe, o sistema exibe todos os passageiros daquela classe naquele voo, ordenados alfabeticamente pelo nome.

---

## Objetivo

Desenvolver a estrutura de dados para o sistema de gestão aeroportuária, aplicando conceitos de:

- Modelagem de dados
- Banco de dados relacional

---

## Etapas da Atividade

### Etapa 1 – Modelagem de Dados

Você deverá:

- Identificar as entidades do sistema
- Definir atributos e tipos de dados
- Criar os relacionamentos entre as entidades

**Entrega obrigatória:**
- Diagrama ER

---

### Etapa 2 – Banco de Dados

Com base na modelagem:

- Criar o banco de dados relacional
- Criar tabelas com:
  - Chaves primárias
  - Chaves estrangeiras
  - Restrições de integridade

**Regras obrigatórias:**
- CPF e número de passaporte do passageiro devem ser únicos
- Código IATA da companhia aérea deve ser único
- Código do voo deve ser único
- Um passageiro não pode ter dois embarques no mesmo voo
- Todo voo deve estar vinculado a uma companhia aérea
- O status do voo deve ser restrito aos valores: No Horário, Atrasado ou Cancelado
- A classe de embarque deve ser restrita aos valores: Econômica, Executiva ou Primeira Classe

---

## Entrega

- Script SQL de criação do banco
- Diagrama ER
