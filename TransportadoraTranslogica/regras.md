# Entidades: 

- Clientes 
- Cargas

## Especificações: 

- Clientes (destinatários das encomendas)
- Cargas (itens a serem transportados)

# Atributos Entidades:

## Cliente: 

- Nome (ou razão social)
- Telefone
- Documento Único - CPF ou CNPJ

## Cargas:

- Código de Identificação - Único - CG1001
- Peso em quilogramas
- Valor declarado
- Cliente Destinatário
- Status Operacional - Enum - Pendente, Em Trânsito, Entregue ou Cancelado.
- Tipo Específico: Carga Padrão, Carga Frágil, Carga Perigosa
- Tributo Extra
- Material de Embalagem
- Rastreamento de Segurança
- Tipo Carga Perigosa - Enum - Mercadorias inflamáveis, químicas ou radioativas
- Atributos Carga Perigosa - 
	- Classe Risco - Enum - Inflamável, Corrosivo
        - Número ONU - Único - 1203
- Frete


1. Carga Padrão: Cargas comuns que não necessitam de cuidados especiais ou taxas extras.

2. Carga Frágil: Encomendas delicadas que exigem cuidados adicionais. Possuem um atributo extra que registra o Material de Embalagem utilizado (ex: Isopor, Plástico Bolha ou Caixa de Madeira). Por serem sensíveis, necessitam obrigatoriamente de rastreamento de segurança.

3. Carga Perigosa: Mercadorias inflamáveis, químicas ou radioativas. Possuem dois atributos extras: a Classe de Risco (ex: Inflamável, Corrosivo) e o número de identificação internacional Número ONU (ex: 1203). Por questões de segurança, devem conter rastreamento obrigatório e instruções de manuseio específicas.


# Regras de tarifação: 

O cálculo do frete é individual de cada tipo de carga, definido por meio da sobrescrita de método:

Carga Padrão: O frete é calculado multiplicando o peso por uma taxa fixa de R$ 5,00 (Exemplo: Peso * 5.0).
Carga Frágil: O frete é calculado a partir do valor base de peso (Peso * 5.0) mais uma taxa de manuseio adicional de 15% sobre o valor declarado da mercadoria.
Carga Perigosa: O frete é calculado a partir do valor base de peso (Peso * 5.0) mais uma taxa fixa de seguro ambiental de R$ 150,00.

# Regras de Rastreamento: 

Apenas Carga Frágil e Carga Perigosa devem implementar a interface IRastreavel, que contém:

Propriedade: string CodigoRastreio { get; }
Método: string ObterInstrucoesSeguranca()
O comportamento do rastreamento deve retornar polimorficamente:

Carga Frágil:
O código de rastreio deve iniciar com "FR-" seguido pelo código da carga (ex: "FR-CG1001").
O método de instruções de segurança deve retornar: "MANUSEIO DELICADO - Carga frágil protegida com [Material de Embalagem]."
Carga Perigosa:
O código de rastreio deve iniciar com "PR-" seguido pelo código da carga (ex: "PR-CG1002").
O método de instruções de segurança deve retornar: "ATENÇÃO: Carga perigosa classe [Classe de Risco] (Número ONU: [Número ONU]). Requer equipe autorizada e EPIs adequados."

# Funcionalidades Obrigatórias

## Busca de Clientes

- Busca por nome ou razão social (parcial)
- Busca case-insensitive

## Relatório Geral de Cargas

- Exibir todas as cargas cadastradas
- Listar código da carga, tipo (Padrão, Frágil ou Perigosa), cliente destinatário e o valor do frete calculado individualmente por polimorfismo.

## Busca de Cargas por Cliente

- Dado o CPF ou CNPJ de um cliente, exibir todas as cargas vinculadas a ele.

## Painel de Rastreamento de Encomendas
- O sistema deve percorrer a lista única de cargas e filtrar apenas as cargas que implementam a interface.
- Para cada carga rastreável filtrada, o sistema deve imprimir o código da carga, o código de rastreio gerado e as instruções de segurança e manuseio retornadas pelo método.
- Cargas padrão não devem aparecer neste painel.
