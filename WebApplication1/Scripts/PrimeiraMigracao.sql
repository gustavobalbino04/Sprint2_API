IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [Status] nvarchar(max) NULL,
    [MyProperty] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Preco] real NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PedidoItems] (
    [Id] uniqueidentifier NOT NULL,
    [IdPedido] uniqueidentifier NOT NULL,
    [IdProduto] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PedidoItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidoItems_Pedidos_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidoItems_Produtos_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PedidoItems_IdPedido] ON [PedidoItems] ([IdPedido]);

GO

CREATE INDEX [IX_PedidoItems_IdProduto] ON [PedidoItems] ([IdProduto]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201024222857_InitialCreate', N'3.1.9');

GO

ALTER TABLE [PedidoItems] ADD [Quantidade] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201025205100_PedidosItens', N'3.1.9');

GO

