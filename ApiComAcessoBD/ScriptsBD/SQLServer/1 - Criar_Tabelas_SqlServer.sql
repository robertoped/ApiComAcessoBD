--Restaurar para o padrão
USE [ComercioOnline];
GO

--A ideia aqui é mostrar um pouquinho de um passo a passo para criar as tabelas do Banco de Dados.
--Muitas vezes na organização, o desenvolvedor também é responsável por criar as tabelas para sua tela ou sistema,
--depois de tudo feito é necessário enviar os scripts para o(s) DBA(s) analisarem e por fim executar no banco de produção.

--Vale reforçar que nesse primeiro modelo de banco de dados para o projeto ApiComAcessoBD a MER pode ser melhorada e vai,
--quero deixar o sistema simples, mas ao mesmo tempo um pouco rico com informações para os iniciantes entenderem como EFCore,
--consegue salvar atráves de uma requisição em várias tabelas ao mesmo tempo, saindo dos exemplos, insere ou atualiza apenas um objeto.

--###################################################################
--############## Remove as tabelas para criar novamente #############
--###################################################################

IF OBJECT_ID(N'DBO.PessoaEndereco', N'U') IS NOT NULL
	DROP TABLE PessoaEndereco;
GO

IF OBJECT_ID(N'DBO.PessoaTelefone', N'U') IS NOT NULL
	DROP TABLE PessoaTelefone;
GO

IF OBJECT_ID(N'DBO.TipoTelefone', N'U') IS NOT NULL
	DROP TABLE TipoTelefone;
GO

IF OBJECT_ID(N'DBO.PessoaJuridica', N'U') IS NOT NULL
	DROP TABLE PessoaJuridica;
GO

IF OBJECT_ID(N'DBO.PessoaFisica', N'U') IS NOT NULL
	DROP TABLE PessoaFisica;
GO

IF OBJECT_ID(N'DBO.NivelFormacao', N'U') IS NOT NULL
	DROP TABLE NivelFormacao;
GO

IF OBJECT_ID(N'DBO.EstadoCivil', N'U') IS NOT NULL
	DROP TABLE EstadoCivil;
GO

IF OBJECT_ID(N'DBO.UnidadeFederativa', N'U') IS NOT NULL
	DROP TABLE UnidadeFederativa;
GO

IF OBJECT_ID(N'DBO.Pessoa', N'U') IS NOT NULL
	DROP TABLE Pessoa;
GO

IF OBJECT_ID(N'DBO.TipoPessoa', N'U') IS NOT NULL
	DROP TABLE TipoPessoa;
GO

IF OBJECT_ID(N'DBO.TipoRegime', N'U') IS NOT NULL
	DROP TABLE TipoRegime;
GO
--###################################################################
--###################3## Cria as tabelas para o #####################
--###################################################################

CREATE TABLE PessoaEndereco (
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdPessoa INT NOT NULL,
	Cep VARCHAR(8) NOT NULL,
    Logradouro VARCHAR(100) NOT NULL,
	Numero VARCHAR(10) NOT NULL,
	Complemento VARCHAR(30) NULL,
	Bairro VARCHAR(50) NOT NULL,
	IdUnidadeFederativa SMALLINT NOT NULL,
	Cidade VARCHAR(50) NOT NULL,
	Principal BIT NOT NULL DEFAULT(0),
	Entrega BIT NOT NULL DEFAULT(0),
	Cobranca BIT NOT NULL DEFAULT(0),
	Correspondencia BIT NOT NULL DEFAULT(0)
);
GO

CREATE TABLE TipoTelefone (
	Id SMALLINT PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(13) NOT NULL,
	Ativo BIT DEFAULT(1) NOT NULL
);
GO

CREATE TABLE PessoaTelefone (
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdPessoa INT NOT NULL,
    IdTipoTelefone SMALLINT NOT NULL,
	Numero VARCHAR(15) NOT NULL
);
GO

CREATE TABLE PessoaFisica (
	IdPessoa INT PRIMARY KEY,
	Nome VARCHAR(150) NOT NULL,
	Cpf VARCHAR(11) NOT NULL UNIQUE,
	--IdDocumentoIdentificacao SMALLINT NOT NULL,
	IdNivelFormacao SMALLINT NOT NULL,
	IdEstadoCivil SMALLINT NOT NULL,
	--IdGenero SMALLINT NULL,
	--IdRaca SMALLINT NULL,
	--IdNacionalidade SMALLINT NULL,
	IdNaturalidade SMALLINT NOT NULL,
	DataNascimento DATE NOT NULL,
	Filiacao1 VARCHAR(150) NULL,
	Filiacao2 VARCHAR(150) NULL
);
GO

CREATE TABLE PessoaJuridica (
	IdPessoa INT PRIMARY KEY,
	RazaoSocial VARCHAR(150) NOT NULL,
	NomeFantasia VARCHAR(100) NULL,
    Cnpj VARCHAR(14) NOT NULL UNIQUE,
	InscricaoEstadual VARCHAR(45) NOT NULL,
	InscricaoMunicipal VARCHAR(45) NOT NULL,
	DataFundacao DATE NOT NULL,
	IdTipoRegime SMALLINT NOT NULL,
	Crt CHAR(1) NULL
);
GO

CREATE TABLE EstadoCivil (
    Id SMALLINT PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(13) NOT NULL,
	Ativo BIT DEFAULT(1) NOT NULL
);
GO

CREATE TABLE NivelFormacao (
    Id SMALLINT PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(13) NOT NULL UNIQUE,
	Ativo BIT DEFAULT(1) NOT NULL
);
GO

CREATE TABLE UnidadeFederativa (
    Id SMALLINT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(19) NOT NULL UNIQUE,
	Capital VARCHAR(14) NOT NULL UNIQUE,
	Ativo BIT DEFAULT(1) NOT NULL
);
GO

CREATE TABLE Pessoa (
    Id INT PRIMARY KEY IDENTITY(1,1),
	IdTipoPessoa SMALLINT NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE,
	DataCadastro DATETIME NOT NULL,
	--Cliente BIT DEFAULT(0) NOT NULL,
	--Fornecedor BIT DEFAULT(0) NOT NULL,
	Ativo BIT DEFAULT(1) NOT NULL,
);
GO

CREATE TABLE TipoPessoa (
	Id SMALLINT PRIMARY KEY IDENTITY(1,1),
    Descricao VARCHAR(15) NOT NULL UNIQUE
);
GO

CREATE TABLE TipoRegime (
	Id SMALLINT PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(16) NOT NULL UNIQUE
);
GO

--###################################################################
--########## Populando algumas tabelas padrões do sistema ###########
--###################################################################

INSERT INTO TipoTelefone (Descricao) VALUES ('Celular');
INSERT INTO TipoTelefone (Descricao) VALUES ('Trabalho');
INSERT INTO TipoTelefone (Descricao) VALUES ('Casa');
INSERT INTO TipoTelefone (Descricao) VALUES ('Principal');
INSERT INTO TipoTelefone (Descricao) VALUES ('Fax trabalho');
INSERT INTO TipoTelefone (Descricao) VALUES ('Fax casa');
INSERT INTO TipoTelefone (Descricao) VALUES ('Pager');
INSERT INTO TipoTelefone (Descricao) VALUES ('Outros');

GO

INSERT INTO EstadoCivil (Descricao) VALUES ('Solteiro(a)');
INSERT INTO EstadoCivil (Descricao) VALUES ('Casado(a)');
INSERT INTO EstadoCivil (Descricao) VALUES ('Separado(a)');
INSERT INTO EstadoCivil (Descricao) VALUES ('Divorciado(a)');
INSERT INTO EstadoCivil (Descricao) VALUES ('Viúvo(a)');
GO

INSERT INTO NivelFormacao (Descricao) VALUES ('Ensino Médio');
INSERT INTO NivelFormacao (Descricao) VALUES ('Curso Técnico');
INSERT INTO NivelFormacao (Descricao) VALUES ('Graduação');
INSERT INTO NivelFormacao (Descricao) VALUES ('Pós Graduação');
INSERT INTO NivelFormacao (Descricao) VALUES ('Mestrado');
INSERT INTO NivelFormacao (Descricao) VALUES ('Doutorado');
GO

INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Acre', 'Rio Branco');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Alagoas', 'Maceió');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Amapá', 'Macapá');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Amazonas', 'Manaus');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Bahia', 'Salvador');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Ceará', 'Fortaleza');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Espírito Santo', 'Vitória');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Goiás', 'Goiânia');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Maranhão', 'São Luís');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Mato Grosso', 'Cuiabá');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Mato Grosso do Sul', 'Campo Grande');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Minas Gerais', 'Belo Horizonte');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Pará', 'Belém');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Paraíba', 'João Pessoa');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Paraná', 'Curitiba');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Pernambuco', 'Recife');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Piauí', 'Teresina');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Rio de Janeiro', 'Rio de Janeiro');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Rio Grande do Norte', 'Natal');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Rio Grande do Sul', 'Porto Alegre');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Rondônia', 'Porto Velho');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Roraima', 'Boa Vista');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Santa Catarina', 'Florianópolis');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('São Paulo', 'São Paulo');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Sergipe', 'Aracaju');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Tocantins', 'Palmas');
INSERT INTO UnidadeFederativa (Nome, Capital) VALUES ('Distrito Federal', 'Brasília');
GO

INSERT INTO TipoPessoa (Descricao) VALUES ('Pessoa Física');
INSERT INTO TipoPessoa (Descricao) VALUES ('Pessoa Jurídica');
GO

INSERT INTO TipoRegime(Descricao) VALUES ('Lucro Presumido');
INSERT INTO TipoRegime (Descricao) VALUES ('Lucro Real');
INSERT INTO TipoRegime (Descricao) VALUES ('Simples Nacional');
GO

--###################################################################
--############ Definindo relacionamento entre as tabelas ############
--###################################################################

--PessoaEndereco X Pessoa
ALTER TABLE [dbo].[PessoaEndereco]  WITH CHECK ADD  CONSTRAINT [FK_PessoaEndereco_Pessoa] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO

--PessoaTelefone X Pessoa
ALTER TABLE [dbo].[PessoaTelefone]  WITH CHECK ADD  CONSTRAINT [FK_PessoaTelefone_Pessoa] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO

--Pessoa  X TipoPessoa
ALTER TABLE [dbo].[Pessoa]  WITH CHECK ADD  CONSTRAINT [FK_Pessoa_TipoPessoa] FOREIGN KEY([IdTipoPessoa])
REFERENCES [dbo].[TipoPessoa] ([Id])
GO

--PessoaFisica  X Pessoa
ALTER TABLE [dbo].[PessoaFisica]  WITH CHECK ADD  CONSTRAINT [FK_PessoaFisica_Pessoa] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO

--PessoaJuridica  X Pessoa
ALTER TABLE [dbo].[PessoaJuridica]  WITH CHECK ADD  CONSTRAINT [FK_PessoaJuridica_Pessoa] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO

--PessoaFisica  X NivelFormacao
ALTER TABLE [dbo].[PessoaFisica]  WITH CHECK ADD  CONSTRAINT [FK_PessoaFisica_NivelFormacao] FOREIGN KEY([IdNivelFormacao])
REFERENCES [dbo].[NivelFormacao] ([Id])
GO

--PessoaFisica  X EstadoCivil
ALTER TABLE [dbo].[PessoaFisica]  WITH CHECK ADD  CONSTRAINT [FK_PessoaFisica_EstadoCivil] FOREIGN KEY([IdEstadoCivil])
REFERENCES [dbo].[EstadoCivil] ([Id])
GO

--PessoaFisica  X UnidadeFederativa
ALTER TABLE [dbo].[PessoaFisica]  WITH CHECK ADD  CONSTRAINT [FK_PessoaFisica_UnidadeFederativa] FOREIGN KEY([IdNaturalidade])
REFERENCES [dbo].[UnidadeFederativa] ([Id])
GO

--PessoaTelefone X TipoTelefone
ALTER TABLE [dbo].[PessoaTelefone]  WITH CHECK ADD  CONSTRAINT [FK_PessoaTelefone_TipoTelefone] FOREIGN KEY([IdTipoTelefone])
REFERENCES [dbo].[TipoTelefone] ([Id])
GO

--PessoaJuridica  X TipoRegime
ALTER TABLE [dbo].[PessoaJuridica]  WITH CHECK ADD  CONSTRAINT [FK_PessoaJuridica_TipoRegime] FOREIGN KEY([IdTipoRegime])
REFERENCES [dbo].[TipoRegime] ([Id])
GO