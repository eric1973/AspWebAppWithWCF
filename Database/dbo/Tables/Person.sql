CREATE TABLE [dbo].[Person] (
    [id]      INT           NOT NULL,
    [name]    VARCHAR (MAX) NULL,
    [address] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([id] ASC)
);

