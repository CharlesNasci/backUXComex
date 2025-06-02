"# backUXComex" 
CREATE DATABASE teste;

CREATE TABLE Produto ( ID BIGINT PRIMARY KEY IDENTITY(1,1), Nome VARCHAR(200) NOT NULL, Descricao VARCHAR(200) NOT NULL, Preco DECIMAL(18, 2) NOT NULL, QtdeEstoque int )

INSERT INTO Produto values ('Mouse', 'Mouse ergonômico e preciso para uso diário.', 95.10, 10), ('Teclado', 'Teclado confortável, silencioso e responsivo.', 59.99 , 5), ('Monitor', 'Monitor nítido, com cores vivas e alta definição.', 999.99, 2)

CREATE TABLE Cliente ( ID BIGINT PRIMARY KEY IDENTITY(1,1), Nome VARCHAR(200) NOT NULL, email VARCHAR(200) NOT NULL, telefone VARCHAR(14) NOT NULL, dataCadastro DATETIME )

INSERT INTO Produto values ('Charles', 'charles.nascimento.m@gmail.com', '(11)98288-8661', GETDATE()), ('Martin João Thomas Silva', 'martin.joao.silva@panfletosecia.com', '(82) 2676-8427', GETDATE()), ('Luiza Antonella Jesus', 'luizaantonellajesus@ime.unicamp.br', '(95) 2692-2681', GETDATE())

CREATE TABLE Status ( ID BIGINT PRIMARY KEY IDENTITY(1,1), Descricao VARCHAR(20) NOT NULL , ) INSERT INTO Status VALUES('Novo'), ('Processando'), ('Finalizado')

CREATE TABLE Pedido ( ID BIGINT PRIMARY KEY IDENTITY(1,1), ID_Cliente BIGINT NOT NULL , Data_Pedido DATETIME, Valor_Total DECIMAL(18,2), ID_Status BIGINT NOT NULL CONSTRAINT FK_Pedido_ID_Cliente FOREIGN KEY (ID_Cliente) REFERENCES Cliente(ID), CONSTRAINT FK_Pedido_ID_Status FOREIGN KEY (ID_Status) REFERENCES Status(ID), ) INSERT INTO Pedido values(1, GETDATE(), 100, 1)

CREATE TABLE Pedido_Item ( ID BIGINT PRIMARY KEY IDENTITY(1,1), ID_Pedido BIGINT NOT NULL , ID_Produto BIGINT NOT NULL, Quantidade INT, Preco_Unitario DECIMAL(18,2), CONSTRAINT FK_Pedido_Item_ID_Pedido FOREIGN KEY (ID_Pedido) REFERENCES Pedido(ID), CONSTRAINT FK_Pedido_Item_ID_Produto FOREIGN KEY (ID_Produto) REFERENCES Produto(ID), )

SELECT c.Nome, CONVERT(VARCHAR(10),Data_Pedido,103) AS 'Data Pedido', Valor_Total, s.Descricao FROM Pedido_Item item INNER JOIN Pedido p on p.ID = item.ID_Pedido INNER JOIN Produto prod on prod.ID = item.ID_Produto INNER JOIN Cliente c on c.ID = p.ID_Cliente INNER JOIN Status s on s.id = p.ID_Status

--CONSULTA PEDIDO ID SELECT item.id, p.ID as 'ID_Pedido', ID_Produto, prod.Nome Quantidade, Preco_Unitario FROM Pedido_Item item INNER JOIN Pedido p on p.ID = item.ID_Pedido INNER JOIN Produto prod on prod.ID = item.ID_Produto WHERE P.ID = 1
