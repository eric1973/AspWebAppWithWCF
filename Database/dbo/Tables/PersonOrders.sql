CREATE TABLE [dbo].[PersonOrders] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [personId]    INT           NOT NULL,
    [description] VARCHAR (MAX) NOT NULL,
    [amount]      INT           NOT NULL,
    [notes]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_PersonOrders] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_PersonOrders_Person] FOREIGN KEY ([personId]) REFERENCES [dbo].[Person] ([id])
);

