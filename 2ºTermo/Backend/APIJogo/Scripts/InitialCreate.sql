IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Jogador] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Senha] nvarchar(max) NULL,
    [DataNascimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Jogador] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Jogos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [DataLancamento] datetime2 NOT NULL,
    CONSTRAINT [PK_Jogos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [JogosJogador] (
    [Id] uniqueidentifier NOT NULL,
    [IdJogador] uniqueidentifier NOT NULL,
    [IdJogo] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_JogosJogador] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JogosJogador_Jogador_IdJogador] FOREIGN KEY ([IdJogador]) REFERENCES [Jogador] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_JogosJogador_Jogos_IdJogo] FOREIGN KEY ([IdJogo]) REFERENCES [Jogos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_JogosJogador_IdJogador] ON [JogosJogador] ([IdJogador]);

GO

CREATE INDEX [IX_JogosJogador_IdJogo] ON [JogosJogador] ([IdJogo]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200927034137_Initial', N'3.1.8');

GO

ALTER TABLE [JogosJogador] DROP CONSTRAINT [FK_JogosJogador_Jogador_IdJogador];

GO

ALTER TABLE [Jogador] DROP CONSTRAINT [PK_Jogador];

GO

EXEC sp_rename N'[Jogador]', N'Jogadores';

GO

ALTER TABLE [Jogadores] ADD CONSTRAINT [PK_Jogadores] PRIMARY KEY ([Id]);

GO

ALTER TABLE [JogosJogador] ADD CONSTRAINT [FK_JogosJogador_Jogadores_IdJogador] FOREIGN KEY ([IdJogador]) REFERENCES [Jogadores] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200927061425_UpdateTableJogador', N'3.1.8');

GO

