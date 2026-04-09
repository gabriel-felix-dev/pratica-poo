# Anotações vídeos aulas:

## Pontos para pesquisa:

- Enumerable e seu métodos - Exemplo: Count, Contains, Any
- Guid

## Conceitos:

### Encapsulamento: 

O encapsulamente garante que modificadores de acesso não alterem os atributos de uma classe diretamente. Com isso podemos garantir a segurança dos atributos da classe

Propriedade somente de leitura. Ela só pode ser preenchida a partir do construtor:

`public int Id { get; }` 

Propriedades com private set só podem ser alteradas dentro da classe. Fora dela só pode ser feito com métodos:

`public string Nome { get; private set; }`  

### Guid:

O Guid cria uma hash aleatória usando o Guid, que é um identificador único global. Ele gera uma string única a cada vez que é chamado. Ele cria uma hash aleatória única de 128 bits

`Guid guidSenha = Guid.NewGuid();`
