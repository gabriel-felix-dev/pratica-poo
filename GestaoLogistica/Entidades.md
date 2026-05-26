# Transportadora:

- codigo unico de 3 caracteres - "JDX"
- nome 
- estado de operação
- modaldiade de transporte - Enum: (Terrestre, aéreo ou fluvial)

# Clientes: 

- nome completo
- e-mail (unico)
- CPF (unico)
- telefone

* O cliente pode realizar varios pedidos ao longo do tempo

# Pedidos:

- codigo unico  - "PED-00142"
- descricao
- valor
- peso
- data criacao pedido
- status - Enum: (Pendente, Em Processamento ou Cancelado)

-> Todo pedido deve estar obrigatoriamente vinculado a um cliente, sem o qual ele não pode ser cadastrado

# Entrega: (Associação de Cliente e Pedido)

- datacoleta
- prazo estumado em dias
- endereco destino
- status entrega: Enum: (Coletado, Em Trânsito, Entregue ou Devolvido)

-> Um pedido não pode ter duas entregas ativas ao mesmo tempo.

# TODO -> Deixar salvo um validador de CPF, email, string, int, decimal, double, guid, data
