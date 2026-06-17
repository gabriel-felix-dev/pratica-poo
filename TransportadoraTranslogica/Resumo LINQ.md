# LINQ em C# — Resumo de Estudo

> Baseado em sessão prática com o projeto TransportadoraTranslogica.  
> Exemplos usam as entidades reais do projeto: `Cliente`, `Carga`, `Viagem`, `Motorista`.

---

## 1. O que é LINQ?

**LINQ (Language Integrated Query)** é um conjunto de funcionalidades do C# que permite escrever consultas diretamente no código, de forma fortemente tipada. Opera sobre qualquer coleção que implemente `IEnumerable<T>` (listas, arrays, etc.) e também sobre bancos de dados via Entity Framework.

Existem duas formas de escrever LINQ:

| Forma | Também chamada de |
|---|---|
| **Sintaxe de método** | Method syntax / Fluent syntax |
| **Sintaxe de consulta** | Query syntax |

Ambas produzem o mesmo resultado — o compilador transforma a query syntax nos mesmos métodos da sintaxe de método.

---

## 2. Ordem de Execução — LINQ vs SQL

O SQL possui uma ordem lógica de execução diferente da ordem em que é escrito:

```sql
-- Ordem de ESCRITA no SQL:
SELECT Cliente.Segmento, COUNT(*) AS Total
FROM cargas
WHERE Status = 'Entregue'
GROUP BY Cliente.Segmento
HAVING COUNT(*) > 2
ORDER BY Total DESC
```

```
-- Ordem de EXECUÇÃO no SQL:
1. FROM
2. WHERE
3. GROUP BY
4. HAVING
5. SELECT
6. ORDER BY
```

O LINQ query syntax foi projetado para que **a ordem de escrita seja igual à ordem de execução**, corrigindo a inconsistência do SQL. A principal mudança é que o `select` vai para o **final**:

```
LINQ query syntax — escrita = execução:
1. from
2. join
3. where
4. let
5. group by / into
6. orderby
7. select  ← SEMPRE por último
```

---

## 3. Palavras-chave da Query Syntax

### 3.1 `from` — Define a fonte de dados

É obrigatório e sempre o primeiro. Equivale ao `FROM` do SQL.

**Query syntax:**
```csharp
from c in clientes
select c;
```

**Method syntax:**
```csharp
clientes.Select(c => c);
```

---

### 3.2 `join` — Relaciona duas coleções

Equivale ao `JOIN` do SQL. Une duas coleções por uma chave em comum.

**Query syntax:**
```csharp
from v in viagens
join m in motoristas on v.Motorista.Cpf equals m.Cpf
select new { v.Codigo, m.Nome };
```

**Method syntax:**
```csharp
viagens.Join(
    motoristas,
    v => v.Motorista.Cpf,
    m => m.Cpf,
    (v, m) => new { v.Codigo, m.Nome }
);
```

---

### 3.3 `where` — Filtra elementos

Equivale ao `WHERE` do SQL. Pode aparecer mais de uma vez na mesma query (ver seção 7).

**Query syntax:**
```csharp
from c in clientes
where c.Vip == true
select new { c.Nome, c.Cidade, c.Segmento };
```

**Method syntax:**
```csharp
clientes
    .Where(c => c.Vip == true)
    .Select(c => new { c.Nome, c.Cidade, c.Segmento });
```

---

### 3.4 `let` — Cria variáveis intermediárias

Não tem equivalente direto no SQL. Permite calcular um valor e reutilizá-lo na query sem repetir a expressão.

**Query syntax:**
```csharp
from c in cargas
let valorComTaxa = c.ValorFrete * 1.1m
where valorComTaxa > 100000
select new { c.Codigo, ValorFinal = valorComTaxa };
```

**Method syntax:**
```csharp
cargas
    .Select(c => new { c.Codigo, ValorComTaxa = c.ValorFrete * 1.1m })
    .Where(x => x.ValorComTaxa > 100000)
    .Select(x => new { x.Codigo, ValorFinal = x.ValorComTaxa });
```

> O `let` é uma vantagem da query syntax — na sintaxe de método são necessários dois `Select` para o mesmo efeito.

---

### 3.5 `group by` / `into` — Agrupa elementos

Equivale ao `GROUP BY` do SQL. O `into` captura o grupo em uma variável para continuar a query.

**Query syntax:**
```csharp
from c in cargas
group c by c.Cliente.Segmento into g
select new { Segmento = g.Key, Total = g.Count() };
```

**Method syntax:**
```csharp
cargas
    .GroupBy(c => c.Cliente.Segmento)
    .Select(g => new { Segmento = g.Key, Total = g.Count() });
```

---

### 3.6 `orderby` — Ordena o resultado

Equivale ao `ORDER BY` do SQL. Use `ascending` (padrão) ou `descending`.

**Query syntax:**
```csharp
from c in clientes
where c.Vip == true
orderby c.Nome ascending
select new { c.Nome, c.Cidade, c.Segmento };
```

**Method syntax:**
```csharp
clientes
    .Where(c => c.Vip == true)
    .OrderBy(c => c.Nome)
    .Select(c => new { c.Nome, c.Cidade, c.Segmento });
```

---

### 3.7 `select` — Projeta o resultado

É obrigatório e sempre o **último**. Equivale ao `SELECT` do SQL, mas ao contrário do SQL (onde `SELECT` aparece primeiro e executa por último), no LINQ ele fica no final — escrita e execução coincidem.

**Query syntax:**
```csharp
from c in clientes
where c.Vip == true
orderby c.Nome
select new { c.Nome, c.Cidade, c.Segmento };  // sempre por último
```

**Method syntax:**
```csharp
clientes
    .Where(c => c.Vip == true)
    .OrderBy(c => c.Nome)
    .Select(c => new { c.Nome, c.Cidade, c.Segmento });
```

> Quando o nome da propriedade projetada é igual ao da fonte, o lado esquerdo pode ser omitido: `Nome = c.Nome` vira apenas `c.Nome`.

### Evite projeção excessiva — projete apenas o que será usado

Ao projetar objetos aninhados no `Select`, carregue apenas os campos necessários, não o objeto inteiro:

```csharp
// Ruim — carrega o objeto Motorista completo (CPF, categoria, cidade...)
// mas só usa o Nome no foreach
viagens
    .Select(x => new { x.Codigo, x.Motorista, x.DataSaida })

foreach (var item in viagensPlanejadas)
    Console.WriteLine(item.Motorista.Nome); // só usa Nome

// Correto — projeta apenas o campo necessário
viagens
    .Select(x => new { x.Codigo, MotoristaNome = x.Motorista.Nome, x.DataSaida })

foreach (var item in viagensPlanejadas)
    Console.WriteLine(item.MotoristaNome); // direto ao ponto
```

> Projetar o objeto inteiro quando apenas um campo é usado desperdiça memória e polui o tipo anônimo com dados irrelevantes.

---

## 4. Method Syntax vs Query Syntax — Diferenças e Performance

### Performance

**Não há diferença de performance.** O compilador transforma toda query syntax em method syntax antes de compilar — o IL (código intermediário) gerado é idêntico para ambas.

```csharp
// Query syntax — o que você escreve
var clientesVip = from c in clientes
                  where c.Vip == true
                  orderby c.Nome
                  select new { c.Nome, c.Cidade, c.Segmento };

// O que o compilador gera — idêntico em performance
var clientesVip = clientes
    .Where(c => c.Vip == true)
    .OrderBy(c => c.Nome)       // OrderBy vem ANTES do Select
    .Select(c => new { c.Nome, c.Cidade, c.Segmento });
```

> A query syntax posiciona o `orderby` antes do `select`, e o compilador mantém essa ordem ao gerar o method syntax — por isso a ordem recomendada é `Where → OrderBy → Select`.

### Quando cada uma é mais vantajosa

| Situação | Vantagem |
|---|---|
| Operações com `group by` e `let` | Query syntax — mais legível |
| Operações encadeadas complexas | Method syntax — maior cobertura |
| Quem vem do SQL | Query syntax — sintaxe familiar |
| Uso geral no mercado C# | Method syntax — mais comum |

### Operações exclusivas da Method Syntax

A query syntax **não cobre todos os métodos do LINQ**. Vários só funcionam via method syntax:

```csharp
// Não existe equivalente em query syntax para:
motoristas.Count(m => m.Ativo);
motoristas.Any(m => m.Categoria == CategoriaCnhEnum.E);
motoristas.Sum(m => m.AnosExperiencia);
motoristas.Skip(2).Take(3);
motoristas.Distinct();
motoristas.FirstOrDefault(m => m.Ativo);
```

Por isso, na prática o mercado usa predominantemente **method syntax** — ela cobre 100% dos cenários, enquanto a query syntax cobre apenas um subconjunto.

---

## 5. Tipos Anônimos e `var`

O `Select` pode projetar um **tipo anônimo** — criado inline com `new { }`, sem nome definido.

```csharp
var clientesVip = clientes
    .Where(c => c.Vip == true)
    .Select(c => new { c.Nome, c.Cidade, c.Segmento });
//                     ^^^^^^^^^^^^^^^^^^^^^^^^^^^
//              tipo anônimo — não tem nome declarável
```

Por não ter nome, o `var` é **obrigatório**:

```csharp
// ERRO — não existe o tipo ???
List<???> clientesVip = clientes.Where(...).Select(c => new { c.Nome }).ToList();

// CORRETO
var clientesVip = clientes.Where(...).Select(c => new { c.Nome }).ToList();
```

Se precisar de um tipo nomeável, use `record` ou `class`:

```csharp
record ClienteVipDto(string Nome, string Cidade, string Segmento);

List<ClienteVipDto> clientesVip = clientes
    .Where(c => c.Vip)
    .Select(c => new ClienteVipDto(c.Nome, c.Cidade, c.Segmento))
    .OrderBy(c => c.Nome)
    .ToList();
```

---

## 6. `==` vs `.Equals()`

### Regra prática

| Tipo | Use |
|---|---|
| `bool`, `int`, `enum`, `struct` (value types) | `==` |
| `string` | `==` (foi sobrecarregado para comparar conteúdo) |
| Classes (reference types) | Depende — veja abaixo |

### Value types — sempre `==`

Para `bool`, `int`, `enum` e outros value types, ambos funcionam igual. O `==` é mais simples e é a convenção:

```csharp
// Enum
x.Status == StatusCargaEnum.Pendente        // correto — convencional
x.Status.Equals(StatusCargaEnum.Pendente)   // funciona, mas desnecessário

// Bool
x.Ativo                   // correto — bool não precisa de comparação
x.Ativo == true           // aceito
x.Ativo.Equals(true)      // funciona, mas desnecessário
```

### Reference types — cuidado com `==`

Para classes, `==` compara **referência** (se são o mesmo objeto na memória), não o conteúdo. `.Equals()` pode ser sobrescrito para comparar valores:

```csharp
var a = new Cliente("123", "TechNova", ...);
var b = new Cliente("123", "TechNova", ...);

a == b          // false — objetos diferentes na memória
a.Equals(b)     // depende — só true se a classe sobrescreveu Equals()
```

### O risco do `.Equals()` — NullReferenceException

O maior problema de usar `.Equals()` é que ele **quebra se o objeto for nulo**:

```csharp
Cliente cliente = null;

cliente == null           // true — seguro
cliente.Equals(null)      // NullReferenceException — não tem objeto para chamar o método
```

> No contexto do LINQ com `bool` e `enum` — como nos lambdas de `Where` — **sempre use `==`**.

---

## 7. Dois `where` — Equivalente ao WHERE + HAVING

**SQL:**
```sql
SELECT Cliente.Segmento, COUNT(*) AS Total
FROM cargas
WHERE Status = 'Entregue'        -- filtra linhas antes de agrupar
GROUP BY Cliente.Segmento
HAVING COUNT(*) > 2              -- filtra grupos depois de agrupar
```

**LINQ query syntax:**
```csharp
from c in cargas
where c.Status == StatusCargaEnum.Entregue   // WHERE
group c by c.Cliente.Segmento into g
where g.Count() > 2                          // HAVING
select new { Segmento = g.Key, Total = g.Count() };
```

**LINQ method syntax:**
```csharp
cargas
    .Where(c => c.Status == StatusCargaEnum.Entregue)
    .GroupBy(c => c.Cliente.Segmento)
    .Where(g => g.Count() > 2)
    .Select(g => new { Segmento = g.Key, Total = g.Count() });
```

> Filtrar antes do `GroupBy` é mais eficiente — reduz os elementos antes de agrupar.

---

## 8. Execução Adiada vs `ToList()`

Por padrão, o LINQ usa **execução adiada**: a query não executa quando é declarada, mas sim quando o resultado é iterado.

```csharp
// NÃO executa aqui — apenas define a consulta
var clientesVip = clientes.Where(c => c.Vip).OrderBy(c => c.Nome);

// Executa AQUI, ao iterar
foreach (var c in clientesVip)
    Console.WriteLine(c.Nome);
```

`ToList()` força a execução imediata e armazena o resultado em memória:

```csharp
// Executa imediatamente
var clientesVip = clientes.Where(c => c.Vip).OrderBy(c => c.Nome).ToList();
```

**Problema de não usar `ToList()` quando o resultado é usado mais de uma vez:**
```csharp
// A query executa DUAS vezes — ineficiente
var query = clientes.Where(c => c.Vip).OrderBy(c => c.Nome);
Console.WriteLine(query.Count());   // executa aqui
foreach (var c in query)            // executa aqui de novo
    Console.WriteLine(c.Nome);
```

**Solução:**
```csharp
// ToList() executa UMA vez e reutiliza
var clientesVip = clientes.Where(c => c.Vip).OrderBy(c => c.Nome).ToList();
Console.WriteLine(clientesVip.Count);   // propriedade da List — sem nova query
foreach (var c in clientesVip)          // itera a lista já materializada
    Console.WriteLine(c.Nome);
```

### Guia de decisão:

| Situação | Recomendação |
|---|---|
| Iterar o resultado uma única vez | Sem `ToList()` — menos memória |
| Usar o resultado múltiplas vezes | Com `ToList()` — evita re-execução |
| Passar para método que itera | Sem `ToList()` — use `IEnumerable<T>` |
| Precisar de `.Count` (propriedade) ou índice | Com `ToList()` |
| Query em banco de dados (Entity Framework) | Com `ToList()` — fecha a conexão |

---

## 9. Convenções de Nomenclatura em Lambdas

O nome do parâmetro lambda é livre, mas existem convenções amplamente adotadas no mercado que tornam o código mais legível e intuitivo.

### Convenções por contexto

| Parâmetro | Quando usar | Exemplo |
|---|---|---|
| Inicial minúscula do tipo (`c`, `m`, `v`) | Preferido — deixa claro o tipo iterado | `clientes.Where(c => c.Vip)` |
| `x` | Genérico — quando o tipo é óbvio pelo contexto | `lista.Where(x => x.Ativo)` |
| `g` | **Exclusivo para grupos** — resultado de `GroupBy` | `.GroupBy(...).Select(g => g.Key)` |

### Exemplo correto — parâmetro consistente

```csharp
// Ruim — 'g' misturado com 'x', e 'g' não representa um grupo aqui
cargas.Where(x => x.Status == StatusCargaEnum.Pendente)
      .OrderByDescending(x => x.ValorDeclarado)
      .Select(g => new { g.CodigoRastreio, g.Tipo });  // g é enganoso

// Bom — parâmetro consistente e semântico
cargas.Where(c => c.Status == StatusCargaEnum.Pendente)
      .OrderByDescending(c => c.ValorDeclarado)
      .Select(c => new { c.CodigoRastreio, c.Tipo });  // c = Carga
```

### Exemplo com `g` no uso correto — GroupBy

```csharp
cargas
    .GroupBy(c => c.Cliente.Segmento)   // c = Carga individual
    .Where(g => g.Count() > 2)          // g = grupo de Cargas
    .Select(g => new { Segmento = g.Key, Total = g.Count() });
```

> Use `g` **somente** após um `GroupBy` ou `group...into` — é a convenção universal para variável de grupo em LINQ.

---

## 10. Referência Rápida — SQL / Query Syntax / Method Syntax

| SQL | Query Syntax | Method Syntax |
|---|---|---|
| `FROM` | `from x in colecao` | ponto de partida da cadeia |
| `JOIN` | `join y in outra on x.Id equals y.Id` | `.Join(outra, ...)` |
| `WHERE` | `where condicao` | `.Where(x => condicao)` |
| — | `let var = expressao` | `.Select(x => new { x, Var = expr })` |
| `GROUP BY` | `group x by chave into g` | `.GroupBy(x => chave)` |
| `HAVING` | `where` após `group...into` | `.Where(g => ...)` após `.GroupBy(...)` |
| `ORDER BY ASC` | `orderby x.Campo` | `.OrderBy(x => x.Campo)` |
| `ORDER BY DESC` | `orderby x.Campo descending` | `.OrderByDescending(x => x.Campo)` |
| `SELECT` | `select new { ... }` ← sempre último | `.Select(x => new { ... })` |
| — | — | `.ToList()` — materializa o resultado |
