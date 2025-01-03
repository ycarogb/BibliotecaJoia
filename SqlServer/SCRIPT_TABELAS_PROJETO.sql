/*
	'1b570dec-9817-4cae-a861-8fcbf296bde8', 'Redes- guia pr�tico', 'Carlos Marimoto', 'Joia editora'
*/


/*
	1	Disponivel
	2	Emprestado
	3	Atrado_Devolucao
	4	Uso_Local
*/

INSERT INTO STATUSLIVRO (STATUS) VALUES ('Disponivel');
INSERT INTO STATUSLIVRO (STATUS) VALUES ('Emprestado');
INSERT INTO STATUSLIVRO (STATUS) VALUES ('Atrado_Devolucao');
INSERT INTO STATUSLIVRO (STATUS) VALUES ('Uso_Local');

SELECT * FROM STATUSLIVRO;

CREATE TABLE LIVRO (
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	NOME VARCHAR(50), 
	AUTOR VARCHAR(50), 
	EDITORA VARCHAR(50), 
	STATUSLIVROID INT,

	CONSTRAINT FK_STATUSLIVRO FOREIGN KEY (STATUSLIVROID) 
        REFERENCES STATUSLIVRO(ID)   -- Foreign key constraint referencing STATUSLIVRO table

);

INSERT INTO LIVRO(ID, NOME, AUTOR, EDITORA, STATUSLIVROID) VALUES (CONVERT(BINARY(36), '1b570dec-9817-4cae-a861-8fcbf296bde8'), 'Redes- guia pr�tico', 'Carlos Marimoto', 'Joia editora', 1);
INSERT INTO LIVRO(ID, NOME, AUTOR, EDITORA, STATUSLIVROID) VALUES (CONVERT(BINARY(36), '2b580dKc-9815-4cae-a861-8fcbf296bde9'), 'Introdu��o C#', 'Jamaico Silva', 'Devs editora', 1);
INSERT INTO LIVRO(ID, NOME, AUTOR, EDITORA, STATUSLIVROID) VALUES (CONVERT(BINARY(36), '3b590dUc-9818-4cae-a861-8fcbf296bde5'), 'Linux com Docker', 'Ana Moura', 'Editora Fowler', 1);

SELECT * FROM LIVRO;


INSERT INTO STATUSCLIENTE(STATUS) VALUES ('Ativo');
INSERT INTO STATUSCLIENTE(STATUS) VALUES ('Inativo');
INSERT INTO STATUSCLIENTE(STATUS) VALUES ('Suspenso');

SELECT * FROM STATUSCLIENTE;

CREATE TABLE CLIENTE (
    ID INT PRIMARY KEY IDENTITY(1,1),  -- ID as primary key with auto-increment
    NOME VARCHAR(50) NOT NULL,       -- NOME column
    CPF CHAR(11) NOT NULL,             -- CPF column (assuming it's 11 characters)
    EMAIL VARCHAR(50) NOT NULL,      -- EMAIL column
    FONE VARCHAR(15),                  -- FONE column (optional, can be NULL)
    STATUSCLIENTEID INT,               -- STATUSCLIENTEID column
    CONSTRAINT FK_STATUSCLIENTE FOREIGN KEY (STATUSCLIENTEID) 
        REFERENCES STATUSCLIENTE(ID)   -- Foreign key constraint referencing STATUSCLIENTE table
);

SELECT * FROM CLIENTE;

SELECT * FROM EMPRESTIMOLIVRO;


SELECT * FROM LIVROS;