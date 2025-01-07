-- Criacao da tabela STATUSLIVRO
CREATE TABLE STATUSLIVRO (
    ID INT PRIMARY KEY,
    STATUS NVARCHAR(50) NOT NULL
);

SELECT * FROM STATUSLIVRO;

-- Inserindo os valores de STATUS na tabela STATUSLIVRO
INSERT INTO STATUSLIVRO (ID, STATUS) VALUES
(1, 'Disponivel'),
(2, 'Emprestado'),
(3, 'Atrasado_Devolucao'),
(4, 'Uso_Local');

-- Criacao da tabela STATUSCLIENTE
CREATE TABLE STATUSCLIENTE (
    ID INT PRIMARY KEY,
    STATUS NVARCHAR(50) NOT NULL
);

-- Inserindo os valores de STATUS na tabela STATUSCLIENTE
INSERT INTO STATUSCLIENTE (ID, STATUS) VALUES
(1, 'Ativo'),
(2, 'Inativo'),
(3, 'Suspenso');

SELECT * FROM STATUSCLIENTE;

-- Criacao da tabela LIVROS
CREATE TABLE LIVROS (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    NOME NVARCHAR(50) NOT NULL,
    AUTOR NVARCHAR(50) NOT NULL,
    EDITORA NVARCHAR(50) NOT NULL,
    IDSTATUSLIVRO INT,
    FOREIGN KEY (IDSTATUSLIVRO) REFERENCES STATUSLIVRO(ID)
);

INSERT INTO LIVROS(ID, NOME, AUTOR, EDITORA, IDSTATUSLIVRO) VALUES (CONVERT(BINARY(36), '1b570dec-9817-4cae-a861-8fcbf296bde8'), 'Redes- guia pr�tico', 'Carlos Marimoto', 'Joia editora', 1);
INSERT INTO LIVROS(ID, NOME, AUTOR, EDITORA, IDSTATUSLIVRO) VALUES (CONVERT(BINARY(36), '2b580dKc-9815-4cae-a861-8fcbf296bde9'), 'Introdu��o C#', 'Jamaico Silva', 'Devs editora', 1);
INSERT INTO LIVROS(ID, NOME, AUTOR, EDITORA, IDSTATUSLIVRO) VALUES (CONVERT(BINARY(36), '3b590dUc-9818-4cae-a861-8fcbf296bde5'), 'Linux com Docker', 'Ana Moura', 'Editora Fowler', 1);

SELECT e1.ID, NOME, AUTOR, EDITORA, e2.STATUS FROM LIVROS e1
JOIN BibliotecaJoia.dbo.STATUSLIVRO e2 ON e2.ID = e1.IDSTATUSLIVRO;

-- Criacao da tabela CLIENTES
CREATE TABLE CLIENTES (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    NOME NVARCHAR(50) NOT NULL,
    CPF NVARCHAR(50) NOT NULL,
    EMAIL NVARCHAR(50) NOT NULL,
    TELEFONE NVARCHAR(50),
    IDSTATUSCLIENTE INT,
    FOREIGN KEY (IDSTATUSCLIENTE) REFERENCES STATUSCLIENTE(ID)
);

-- Inserindo registros na tabela CLIENTES
INSERT INTO CLIENTES (ID, NOME, CPF, EMAIL, TELEFONE, IDSTATUSCLIENTE) VALUES
(NEWID(), 'Joao Silva', '123.456.789-00', 'joao.silva@example.com', '(11) 91234-5678', 1),
(NEWID(), 'Maria Oliveira', '987.654.321-00', 'maria.oliveira@example.com', '(11) 98765-4321', 2),
(NEWID(), 'Carlos Pereira', '456.789.123-00', 'carlos.pereira@example.com', '(11) 99876-5432', 3);

SELECT * FROM CLIENTES;

SELECT e1.ID, NOME, CPF, EMAIL, TELEFONE, e2.STATUS FROM CLIENTES e1
JOIN BibliotecaJoia.dbo.STATUSCLIENTE e2 ON e2.ID = e1.IDSTATUSCLIENTE;

-- Criacao da tabela USUARIO
CREATE TABLE USUARIO (
    ID INT PRIMARY KEY IDENTITY(1,1),
    LOGIN NVARCHAR(50) NOT NULL,
    SENHA NVARCHAR(50) NOT NULL
);

-- Inserindo registros na tabela USUARIO
INSERT INTO USUARIO (LOGIN, SENHA) VALUES
('joao.silva', 'senha123'),
('maria.oliveira', 'senha456'),
('carlos.pereira', 'senha789');

SELECT * FROM USUARIO;

-- Criacao da tabela EMPRESTIMOLIVRO
CREATE TABLE EMPRESTIMOLIVRO (
    IDCLIENTE UNIQUEIDENTIFIER,
    IDLIVRO UNIQUEIDENTIFIER,
    IDUSUARIO INT,
    DATAEMPRESTIMO DATE NOT NULL,
    DATADEVOLUCAO DATE NOT NULL,
    DATADEVOLUCAOEFETIVA DATE,
    FOREIGN KEY (IDCLIENTE) REFERENCES CLIENTES(ID),
    FOREIGN KEY (IDLIVRO) REFERENCES LIVROS(ID),
    FOREIGN KEY (IDUSUARIO) REFERENCES USUARIO(ID),
    PRIMARY KEY (IDCLIENTE, IDLIVRO)  -- Chave primaria composta
);