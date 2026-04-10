# Fluxo de como o projeto funcionará:

Program ---------- UI
UI --------------- Service
Service ---------- Repository => SQL/List


# Conceitos

## Fluxo READ:

### Program - Inicio o fluxo. 

- Chama a service 
- Service chama Repository 
- Repository devolve para a Service
- Service devolve algo para a Program
- Program chama a UI passando o que ela recebeu como parâmetro

### Menu - UI - Não sabe que a Service existe. 