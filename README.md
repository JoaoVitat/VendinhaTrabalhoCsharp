# Vendinha Plena

## Cenário
Este projeto consiste em uma aplicação desenvolvida para informatizar o controle de contas e "dívidas penduradas" de uma venda tradicional. O sistema visa substituir o controle manual por papel, facilitando o cadastro de clientes, acompanhamento de débitos acumulados e liquidação de pendências de forma ágil e segura.

## Requisitos Funcionais Implementados
### Clientes
- **CRUD Completo:** Permite o cadastro, recuperação, atualização e exclusão de clientes via aplicação.
- **Campos Obrigatórios:** Nome completo, CPF (com validação estrutural de formato válido) e Data de Nascimento.
- **Cálculo Automático de Idade:** A idade atualizada do cliente é calculada dinamicamente com base na data de nascimento fornecida.
- **E-mail de Contato:** Campo validado no momento do preenchimento.
- **Regra de Unicidade:** Bloqueio de CPFs duplicados no banco de dados (Apenas um cliente por CPF).

### Gerenciamento de Dívidas
- **Atributos de Dívidas:** Controle detalhado do Valor, Situação (Paga/Pendente), Data de Criação e Data de Pagamento.
- **Listagem por Cliente:** Visualização dedicada do histórico financeiro individual diretamente na interface.
- **Regra de Negócio Crucial:** Um cliente só pode possuir **uma única dívida ativa (em aberto)** por vez no sistema. Se houver débito pendente, novas inclusões são bloqueadas até a quitação.
- **Baixa de Débitos:** Opção simplificada para quitar a dívida atual e registrar a data exata do pagamento.

### Diferenciais do Painel de Controle
- **Ordenação Inteligente:** Listagem principal de clientes ordenada de forma decrescente (do cliente que mais deve para o que menos deve).
- **Totalizadores em Tempo Real:** Exibição da soma acumulada de todas as dívidas ativas de cada cliente direto na tela inicial.
- **Barra de Busca:** Filtro por texto integrado para localização imediata de clientes por nome.

---

## Tecnologias e Arquitetura Utilizadas
- **Interface Visual:** Windows Forms (.NET Desktop Application)
- **Linguagem:** C# (.NET 8.0)
- **Paradigma:** Programação Orientada a Objetos (POO) estruturada com separação de camadas (*Models*, *Services* e *Screens*).
- **Banco de Dados:** PostgreSQL
- **Driver de Conexão:** Npgsql

---

## Estrutura do Banco de Dados
O script abaixo foi estruturado para manter a integridade dos dados e aplicar chaves estrangeiras (`FOREIGN KEY`) conectando de forma relacional as dívidas aos respectivos registros de clientes:

```sql
-- Criação da Tabela de Clientes
CREATE TABLE cliente (
    idcliente INT NOT NULL,
    nome VARCHAR(150) NOT NULL,
    cpf VARCHAR(14) NOT NULL,
    datanascimento DATE NOT NULL,
    email VARCHAR(100),
    CONSTRAINT pk_cliente PRIMARY KEY (idcliente),
    CONSTRAINT un_cliente_cpf UNIQUE (cpf)
);

-- Criação da Tabela de Dívidas
CREATE TABLE divida (
    iddivida INT NOT NULL,
    Valor DECIMAL(10,2) NOT NULL,
    Situacao BOOL NOT NULL DEFAULT false,
    DatadeCriacao DATE NOT NULL,
    DataPagamento DATE,
    idCliente INT,
    CONSTRAINT pk_divida PRIMARY KEY (iddivida),
    CONSTRAINT fk_cliente_divida FOREIGN KEY (idCliente) REFERENCES public.cliente (idcliente) ON DELETE CASCADE
);
