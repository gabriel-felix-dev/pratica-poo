# Configuração do arquivo .sln quando o `using` não estiver importanto o `namespace`

## Descrição do problema: quando se criam vários projetos dentro de uma única pasta, o arquivo **.sln** deixa de ser atualizado com os caminhos dos diretórios dos projetos, levando assim a bug's que não permitem a importação do `namespace` de uma `class` dentro do arquivo **Program.cs**. 

### Usar o comando abaixo na pasta raiz do projeto onde o arquivo .sln está para configurar o caminho do projeto.

```
dotnet sln add nome-da-pasta/nome-da-pasta-do-projeto/nome-do-arquivo.csproj

dotnet sln add 03-encapsulamento/exercicio-01/exercicio-01.csproj
```

### OBS.: Se atentar ao nome, caminhos corretos dos diretórios e o local que o arquivo **.sln** está. Se necessário, use o comando `ls` no prompt de comando para lista os arquivos presentes na pasta.
