# Requisito de Sistema — Loja Virtual
Documento de Especificação Funcional | Versão 1.0

## 1. Visão Geral
O sistema tem como objetivo gerenciar as operações básicas de uma loja virtual, permitindo o controle do catálogo de produtos, o cadastro de clientes e o processamento de pedidos. Toda a lógica de negócio deve ser implementada na camada de domínio da aplicação, garantindo integridade dos dados independentemente da interface utilizada.

## 2. Cadastro de Categorias
O sistema deve permitir o cadastro de categorias para organizar os produtos do catálogo. Cada categoria possui um nome obrigatório, com no mínimo 2 e no máximo 60 caracteres, e não podem existir duas categorias com o mesmo nome, desconsiderando diferenças entre maiúsculas e minúsculas. Toda categoria recém-cadastrada deve iniciar em estado ativo.

A listagem de categorias deve retornar apenas as categorias ativas, exibindo junto a cada uma a quantidade de produtos ativos vinculados. A consulta individual deve retornar os dados da categoria acrescidos da lista de seus produtos ativos. A atualização deve permitir apenas a alteração do nome, revalidando a unicidade antes de persistir.

A exclusão de uma categoria é proibida enquanto existirem produtos ativos vinculados a ela, devendo o sistema retornar uma mensagem explicativa nesse caso. Quando não houver produtos ativos vinculados, a exclusão deve ser lógica, ou seja, o sistema deve apenas marcar a categoria como inativa, sem removê-la fisicamente do banco de dados.

## 3. Cadastro de Produtos
O sistema deve permitir o cadastro de produtos associados a uma categoria existente. Cada produto possui nome obrigatório entre 3 e 100 caracteres, preço unitário obrigatório maior que zero, quantidade em estoque obrigatória maior ou igual a zero e uma categoria de vínculo obrigatória. Todo produto recém-cadastrado deve iniciar em estado ativo.

No momento do cadastro, o sistema deve verificar se a categoria informada existe e está ativa. Caso contrário, o cadastro deve ser rejeitado com mensagem clara ao usuário.
A listagem de produtos deve retornar apenas os produtos ativos e deve suportar filtragem por categoria. A consulta individual deve retornar os dados completos do produto, incluindo o nome da categoria à qual pertence. 

A atualização deve permitir a alteração de nome, preço e quantidade em estoque. O vínculo com a categoria é definido no momento do cadastro e não pode ser alterado posteriormente.

A exclusão de um produto é sempre lógica — o sistema deve apenas marcar o produto como inativo. A inativação é proibida enquanto o produto possuir pedidos com status "Aguardando" ou "Processando", devendo o sistema informar ao usuário o motivo do bloqueio.

## 4. Cadastro de Clientes
O sistema deve permitir o cadastro de clientes que realização compras na loja. Cada cliente possui nome completo obrigatório entre 5 e 100 caracteres, endereço de e-mail obrigatório em formato válido e CPF obrigatório em formato válido. Tanto o e-mail quanto o CPF devem ser únicos no sistema — não podem existir dois clientes cadastrados com os mesmos valores para esses campos. Todo cliente recém-cadastrado deve iniciar em estado ativo.

A listagem deve retornar apenas clientes ativos. A consulta individual deve retornar os dados do cliente acrescidos da quantidade total de pedidos realizados por ele. A atualização deve permitir a alteração de nome e e-mail. O CPF é definido no cadastro e não pode ser alterado em nenhuma circunstância.

A exclusão de um cliente é lógica. Ela é proibida enquanto o cliente possuir pedidos com status "Aguardando" ou "Processando". Não havendo pedidos nesses status, o sistema deve inativar o cliente sem removê-lo fisicamente.

## 5. Pedidos e Itens de Pedido

### 5.1 Estrutura do Pedido
Um pedido representa uma intenção de compra realizada por um cliente. Ele é composto por um ou mais itens, cada item referenciando um produto, uma quantidade e o preço unitário vigente no momento da compra. O preço registrado no item é copiado do produto no instante da criação do pedido e não pode ser alterado posteriormente, garantindo que variações futuras no preço do produto não afetem pedidos já registrados. 

O subtotal de cada item é calculado automaticamente pela multiplicação da quantidade pelo preço registrado na venda. O valor total do pedido é a soma dos subtotais de todos os itens e nunca deve ser informado manualmente — qualquer tentativa de fornecê-lo externamente deve ser ignorada ou rejeitada.

A data de criação do pedido é gerada automaticamente pelo sistema no momento do cadastro e é imutável. Todo pedido nasce com status "Aguardando".

### 5.2 Criação do Pedido
Para que um pedido seja criado com sucesso, o cliente informado deve estar ativo no sistema. Além disso, para cada item do pedido, o sistema deve verificar se a quantidade disponível em estoque é suficiente para atender à quantidade solicitada. 

Caso qualquer item apresente estoque insuficiente, o pedido inteiro deve ser rejeitado — o sistema não deve criar pedidos parciais. 

A mensagem de erro deve identificar o produto com problema, informando a quantidade disponível e a quantidade solicitada.

### 5.3 Movimentação de Estoque
O estoque não é debitado no momento da criação do pedido. O débito ocorre exclusivamente quando o status do pedido avança para "Processando". 

Enquanto o pedido permanecer em "Aguardando", a quantidade em estoque dos produtos permanece inalterada.

Quando um pedido com status "Processando" for cancelado, o sistema deve devolver ao estoque de cada produto a quantidade que havia sido debitada. O cancelamento de pedidos ainda em "Aguardando" não gera nenhuma movimentação de estoque.

### 5.4 Ciclo de Vida do Pedido
O status de um pedido segue uma sequência rígida de transições. A partir do status "Aguardando", o pedido pode avançar para "Processando" ou ser movido para "Cancelado". A partir de "Processando", o pedido pode avançar para "Entregue" ou ser movido para "Cancelado". Os status "Entregue" e "Cancelado" são estados finais — nenhuma transição é permitida a partir deles. Qualquer tentativa de realizar uma transição não prevista deve ser rejeitada com mensagem explicativa.

A atualização do status é a única operação de edição permitida sobre um pedido. Nenhum outro campo pode ser alterado após a criação. A exclusão física de pedidos é terminantemente proibida — pedidos encerrados ou indesejados devem ser cancelados via mudança de status.

## 6. Arquitetura Esperada
A aplicação deve ser organizada em camadas bem definidas. A camada de domínio deve conter as entidades, enumerações e exceções de negócio. A camada de aplicação deve conter os serviços responsáveis por orquestrar os fluxos. A camada de infraestrutura deve conter as implementações de repositório. A camada de apresentação, implementada como um console, deve apenas delegar chamadas aos serviços, sem conter lógica de negócio.

Cada repositório deve ser acessado exclusivamente por meio de sua interface. As regras de transição de status do pedido devem estar encapsuladas dentro da própria entidade, não nos serviços. Nenhuma entidade deve poder ser instanciada em estado inválido — os construtores devem garantir a presença e a validade dos dados obrigatórios desde o primeiro momento.