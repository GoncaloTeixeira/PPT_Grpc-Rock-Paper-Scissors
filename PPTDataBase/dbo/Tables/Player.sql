CREATE TABLE [dbo].[Player] (
    [Nome]     VARCHAR (50) NOT NULL,
    [vitorias] INT          DEFAULT ((0)) NOT NULL,
    [empates]  INT          DEFAULT ((0)) NOT NULL,
    [derrotas] INT          DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Nome] ASC),
    UNIQUE NONCLUSTERED ([Nome] ASC)
);

